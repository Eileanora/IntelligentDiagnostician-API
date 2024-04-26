﻿using IntelligentDiagnostician.BL.DTOs.ReadingDTOs;
using IntelligentDiagnostician.BL.Utils.Facades.ReadingManagerFacade;
using FluentValidation;
using IntelligentDiagnostician.BL.ResourceParameters;
using IntelligentDiagnostician.BL.Utils.Converter;

namespace IntelligentDiagnostician.BL.Manager.ReadingManager;

public class ReadingManager : IReadingManager
{
    private readonly IReadingManagerFacade _readingManagerFacade;
    public ReadingManager(IReadingManagerFacade readingManagerFacade)
    {
        _readingManagerFacade = readingManagerFacade;
    }
    public async Task CreateAsync(
        int sensorId, Guid userId, float value)
    {
        var readingForCreationDto = new ReadingForCreationDto
        {
            SensorId = sensorId,
            UserId = userId,
            Value = value
        };
        var validationResult = await _readingManagerFacade.CreationValidator.ValidateAsync(
            readingForCreationDto,
            options => options.IncludeRuleSets("Business"));

        if (!validationResult.IsValid)
            return;

        var newReading = readingForCreationDto.ToReading();
        await _readingManagerFacade.ReadingRepository.CreateAsync(newReading);
        await _readingManagerFacade.UnitOfWork.SaveAsync();
    }

    public async Task<PagedList<ReadingDto>> GetAllAsync(
        int sensorId,
        ReadingResourceParameters resourceParameters)
    {
        var currentUserId = _readingManagerFacade
            .CurrentUserService.GetCurrentUser().UserId;
        
        if (currentUserId == Guid.Empty)
            throw new UnauthorizedAccessException("User is not authorized to access this resource");
        
        var userId = currentUserId.ToString();
        
        var readings =  await _readingManagerFacade
            .ReadingRepository
            .GetAllAsync(sensorId, userId, resourceParameters);
        return readings.ToListDto();
    }
}
