using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using tut7.Data;
using tut7.DTOs;
using tut7.Exceptions;
using tut7.Models;

namespace tut7.Service;

public class DbService : IDbService
{
    private readonly DataBaseContext _context;
    
    public DbService(DataBaseContext context)
    {
        _context = context;
    }

    public async Task<List<GetAllPCsDTO>> GetAllPCs()
    {
        var result =  await _context.PCs.Select(pc => new GetAllPCsDTO()
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock
        }).ToListAsync();


        return result;
    }

    public async Task<GetPCDTO> GetPC(int id)
    {
        var result = await _context.PCs.Select(p => new GetPCDTO()
        {
            Id = p.Id,
            Name = p.Name,
            Weight = p.Weight,
            Warranty = p.Warranty,
            CreatedAt = p.CreatedAt,
            Stock = p.Stock,
            Components = p.PCComponents.Select(p => new GetComponentsDTO() {
            Amount = p.Amount,
            Component = new GetComponentInfoDTO()
            {
                Code = p.Component.Code,
                Name = p.Component.Name,
                Description = p.Component.Description,
                Manufacturer = new GetManufacturerDTO()
                {
                    Id = p.Component.ComponentManufacturer.Id,
                    Abbreviation = p.Component.ComponentManufacturer.Abbreviation,
                    FullName = p.Component.ComponentManufacturer.FullName,
                    FoundationDate = p.Component.ComponentManufacturer.FoundationDate
                },
                Type = new GetTypeDTO()
                {
                    Id = p.Component.ComponentType.Id,
                    Abbreviation = p.Component.ComponentType.Abbreviation,
                    Name = p.Component.ComponentType.Name
                }
            }
        }).ToList()
        }).FirstOrDefaultAsync(p => p.Id == id);
        
        if (result is null)
            throw new NotFoundException();
        
        return result;
       
    }


    public async Task<PC> CreatePC(CreatePCDTO dto)
    {
        var pc = new PC()
        {
            Name = dto.Name,
            Weight = dto.Weight,
            Warranty = dto.Warranty,
            CreatedAt = DateTime.Now,
            Stock = dto.Stock
        };
        _context.PCs.Add(pc);
        await _context.SaveChangesAsync();
        return pc;
    }

    public async Task UpdatePC(UpdatePCDTO dto, int id)
    {
        var pc = await _context.PCs.FirstOrDefaultAsync(p => p.Id == id);

        if (pc is null)
        {
            throw new NotFoundException();
        }
        
        pc.Name = dto.Name;
        pc.Weight = dto.Weight;
        pc.Warranty = dto.Warranty;
        pc.CreatedAt = dto.CreatedAt;
        pc.Stock = dto.Stock;
        
        await _context.SaveChangesAsync();
        
    }
    
    
    public async Task DeletePC(int id)
    {
        var pc = await _context.PCs.FirstOrDefaultAsync(p => p.Id == id);

        if (pc is null)
        {
            throw new NotFoundException();
        }
        
        _context.PCs.Remove(pc);
        await _context.SaveChangesAsync();
    }
}