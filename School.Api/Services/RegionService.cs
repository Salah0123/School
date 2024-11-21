using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using School.Api.DTOs;
using School.Api.Entities;
using School.Api.Persistence;
using System.Reflection.Metadata.Ecma335;

namespace School.Api.Services
{
    public class RegionService : IRegionService
    {
        private readonly ApplicationDbContext _context;

        public RegionService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Region> CreateAsync(Region entity)
        {
            await _context.Regions.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<string?> DeleteAsync(string id)
        {
            var region = await _context.Regions.FindAsync(id);
            if (region == null)
                return "Region Not Found";

            _context.Regions.Remove(region);

            await _context.SaveChangesAsync();

            return "Deleted Successfully";
        }

        public async Task<ICollection<Region>> GetAllAsync()
        {
            var regions = await _context.Regions.ToListAsync();
            return regions;
        }

        public Task<(Region?, string?)> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<(Region?, string?)> UpdateAsync(string id, AddRegionDTO entity)
        {
            var region = await _context.Regions.FindAsync(id);
            if (region == null)
                return (null, "Region Not Found");
            region.RegionName = entity.RegionName;
            region.UpdatedOn = DateTime.Now;
            await _context.SaveChangesAsync();

            return (region, "Region Updated");
            
        }
    }
}