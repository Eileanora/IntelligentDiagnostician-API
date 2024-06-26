﻿using AutoDiag.BL.Repositories;
using AutoDiag.BL.ResourceParameters;
using AutoDiag.DAL.Context;
using AutoDiag.DAL.Helpers;
using AutoDiag.DataModels.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoDiag.DAL.Repositories;

internal class SensorRepository(AppDbContext context, ISortHelper<Sensor> sortHelper)
    : BaseRepository<Sensor>(context), ISensorRepository
{

    public async Task<IEnumerable<Sensor>> GetAllAsync(int systemId)
    {
        return await DbContext.Sensors
            .AsNoTracking()
            .Where(s => s.CarSystemId == systemId)
            .Include(s => s.CarSystem)
            .ToListAsync();
    }
    
    public async Task<PagedList<Sensor>> GetAllAsync(
        int systemId,
        SensorsResourceParameters resourceParameters)
    {
        var collection = DbContext.Sensors as IQueryable<Sensor>;
        collection = collection.Where(s => s.CarSystemId == systemId);
        
        if (!string.IsNullOrWhiteSpace(resourceParameters.SearchQuery))
        {
            var searchQuery = resourceParameters.SearchQuery.Trim();
            collection = collection.Where(s => s.SensorName.Contains(searchQuery));
        }
        
        if (!string.IsNullOrWhiteSpace(resourceParameters.SensorName))
        {
            var name = resourceParameters.SensorName.Trim();
            collection = collection.Where(s => s.SensorName == name);
        }
        
        var sortedList = sortHelper.ApplySort(collection, resourceParameters.OrderBy);
        
        return await CreateAsync(
            sortedList,
            resourceParameters.PageNumber,
            resourceParameters.PageSize);
    }
    public async Task<Sensor?> GetByIdAsync(int id)
    {
        return await DbContext.Sensors
            .Include(s => s.CarSystem)
            .FirstOrDefaultAsync(s => s.Id == id);
    }
    public async Task<bool> SensorExistsAsync(int id)
    {
        return await DbContext.Sensors.AnyAsync(s => s.Id == id);
    }

    public async Task<bool> IsNameUniqueAsync(int carSystemId, string sensorName)
    {
        return await DbContext.Sensors
            .AnyAsync(s => s.CarSystemId == carSystemId && s.SensorName == sensorName);
    }
    public async Task<bool> IsIdUniqueAsync(int id)
    {
        return await DbContext.Sensors
            .AnyAsync(s => s.Id == id);
    }
    public async Task<Sensor?> GetByNameAsync(string sensorName)
    {
        return await DbContext.Sensors
            .FirstOrDefaultAsync(s => s.SensorName == sensorName);
    }
}
