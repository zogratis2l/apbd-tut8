using Microsoft.EntityFrameworkCore;
using tut7.Models;

namespace tut7.Data;

public class DataBaseContext : DbContext
{
    public DbSet<PC> PCs { get; set; }
    public DbSet<Component> Components { get; set; }
    public DbSet<ComponentType> ComponentTypes { get; set; }
    public DbSet<ComponentManufacturer> ComponentManufacturers { get; set; }
    public DbSet<PCComponent> PCComponents { get; set; }

    public DataBaseContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
         modelBuilder.Entity<ComponentManufacturer>().HasData(
        new ComponentManufacturer
        {
            Id = 1,
            Abbreviation = "INT",
            FullName = "Intel",
            FoundationDate = new DateOnly(1968, 7, 18)
        },
        new ComponentManufacturer
        {
            Id = 2,
            Abbreviation = "AMD",
            FullName = "Advanced Micro Devices",
            FoundationDate = new DateOnly(1969, 5, 1)
        },
        new ComponentManufacturer
        {
            Id = 3,
            Abbreviation = "NV",
            FullName = "NVIDIA",
            FoundationDate = new DateOnly(1993, 4, 5)
        }
    );

    modelBuilder.Entity<ComponentType>().HasData(
        new ComponentType
        {
            Id = 1,
            Abbreviation = "CPU",
            Name = "Processor"
        },
        new ComponentType
        {
            Id = 2,
            Abbreviation = "GPU",
            Name = "Graphics Card"
        },
        new ComponentType
        {
            Id = 3,
            Abbreviation = "RAM",
            Name = "Memory"
        }
    );

    modelBuilder.Entity<Component>().HasData(
        new Component
        {
            Code = "I5-14600K",
            Name = "Intel Core i5 14600K",
            Description = "14th generation Intel processor",
            ComponentManufacturersId = 1,
            ComponentTypesId = 1
        },
        new Component
        {
            Code = "RTX4080",
            Name = "RTX 4080",
            Description = "NVIDIA graphics card",
            ComponentManufacturersId = 3,
            ComponentTypesId = 2
        },
        new Component
        {
            Code = "DDR5-32",
            Name = "DDR5 32GB",
            Description = "32GB DDR5 RAM kit",
            ComponentManufacturersId = 2,
            ComponentTypesId = 3
        }
    );

    modelBuilder.Entity<PC>().HasData(
        new PC
        {
            Id = 1,
            Name = "Gaming Beast",
            Weight = 12.5f,
            Warranty = 36,
            CreatedAt = new DateTime(2025, 1, 10),
            Stock = 5
        },
        new PC
        {
            Id = 2,
            Name = "Office Pro",
            Weight = 8.2f,
            Warranty = 24,
            CreatedAt = new DateTime(2025, 2, 15),
            Stock = 12
        },
        new PC
        {
            Id = 3,
            Name = "Mini Home",
            Weight = 4.7f,
            Warranty = 12,
            CreatedAt = new DateTime(2025, 3, 20),
            Stock = 7
        }
    );

    modelBuilder.Entity<PCComponent>().HasData(
        new PCComponent
        {
            PCId = 1,
            ComponentCode = "I5-14600K",
            Amount = 1
        },
        new PCComponent
        {
            PCId = 1,
            ComponentCode = "RTX4080",
            Amount = 1
        },
        new PCComponent
        {
            PCId = 1,
            ComponentCode = "DDR5-32",
            Amount = 2
        },

        new PCComponent
        {
            PCId = 2,
            ComponentCode = "I5-14600K",
            Amount = 1
        },
        new PCComponent
        {
            PCId = 2,
            ComponentCode = "DDR5-32",
            Amount = 1
        },

        new PCComponent
        {
            PCId = 3,
            ComponentCode = "DDR5-32",
            Amount = 1
        }
    );
}
        
        
        
}

    
