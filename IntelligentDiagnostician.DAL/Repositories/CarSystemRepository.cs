﻿using IntelligentDiagnostician.BL.Repositories;
using IntelligentDiagnostician.BL.ResourceParameters;
using IntelligentDiagnostician.DAL.Context;
using IntelligentDiagnostician.DataModels.Models;
using Microsoft.EntityFrameworkCore;

namespace IntelligentDiagnostician.DAL.Repositories;

internal class CarSystemRepository : BaseRepository<CarSystem>, ICarSystemRepository
{
    public CarSystemRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task<CarSystem?> GetByIdAsync(int id)
    {
        
        return await DbContext.CarSystems
            .Include(cs => cs.Sensors)
            .FirstOrDefaultAsync(cs => cs.Id == id);
    }
    public async Task<bool> IsNameUnique(string carSystemName)
    {
        return await DbContext.CarSystems
            .AnyAsync(cs => cs.CarSystemName == carSystemName);
    }
    public async Task<bool> IsNameUnique(int id, string carSystemName)
    {
        return await DbContext.CarSystems
            .Where(cs => cs.Id != id)
            .AnyAsync(cs => cs.CarSystemName == carSystemName);
    }

    public async Task<bool> CarSystemExistsAsync(int id)
    {
        return await DbContext.CarSystems.AnyAsync(cs => cs.Id == id);
    }


    public async Task<IEnumerable<CarSystem>> GetAllAsync(CarSystemsResourceParameters resourceParameters)
    {
        // check if both filters and search query are present
        if(string.IsNullOrWhiteSpace(resourceParameters.SearchQuery)
           && string.IsNullOrWhiteSpace(resourceParameters.CarSystemName))
            return await GetAllAsync();
        
        var collection = DbContext.CarSystems as IQueryable<CarSystem>;
        if (!string.IsNullOrWhiteSpace(resourceParameters.SearchQuery))
        {
            var searchQuery = resourceParameters.SearchQuery.Trim();
            collection = collection.Where(cs => cs.CarSystemName.Contains(searchQuery));
        }
        
        if (!string.IsNullOrWhiteSpace(resourceParameters.CarSystemName))
        {
            var name = resourceParameters.CarSystemName.Trim();
            collection = collection.Where(cs => cs.CarSystemName == name);
        }
        
        return await collection.ToListAsync();
    }
}
