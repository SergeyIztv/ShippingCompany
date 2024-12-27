using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShippingCompany.domain.entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Logging;
using ShippingCompany.Domain.Entities;

namespace ShippingCompany.data;
#nullable enable

public class ShippingCompanyDbContext: DbContext
{
    private static ShippingCompanyDbContext? _instance;
    
    public DbSet<Ship> Ships { get; set; }
    public DbSet<Bank> Banks { get; set; }
    public DbSet<Cargo> Cargos { get; set; }
    public DbSet<ClientCompany> ClientCompanies { get; set; }
    public DbSet<Port> Ports { get; set; }
    public DbSet<Shipment> Shipments { get; set; }
    public DbSet<Street> Streets { get; set; }
    public DbSet<Town> Towns { get; set; }
    public DbSet<TypeOfCargo> TypeOfCargos { get; set; }
    public DbSet<UnitOfMeasurement> UnitOfMeasurements { get; set; }
    public DbSet<Voyage> Voyages { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<ShipTypeOfCargo> ShipTypeOfCargos { get; set; }
    public DbSet<UserMenuItem> UserMenuItems { get; set; }
    public DbSet<VoyagePort> VoyagePorts { get; set; }
    public ShippingCompanyDbContext() { }

    private ShippingCompanyDbContext(
        DbContextOptions<ShippingCompanyDbContext> options,
        IConfiguration configuration) : base(options)
    {
        
    }

    /// <summary>
    /// Получает экземпляр контекста базы данных.
    /// </summary>
    /// <returns>
    /// Возвращает экземпляр класса <see cref="ShippingCompanyDbContext"/>.
    /// Если экземпляр ещё не создан, он будет инициализирован с использованием конфигурации
    /// из файла <c>appsettings.json</c>.
    /// </returns>
    /// <remarks>
    /// Данный метод реализует паттерн проектирования Singleton. 
    /// При первом вызове метода настраивается конфигурация подключения к базе данных 
    /// с использованием библиотеки <c>Npgsql</c> для работы с PostgreSQL. 
    /// Если файл конфигурации отсутствует или не содержит нужного подключения, 
    /// будет выброшено исключение.
    /// </remarks>
    public static ShippingCompanyDbContext GetInstance()
    {
        if (_instance == null)
        {
            // Настройка конфигурации
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false,
                    reloadOnChange: true)
                .Build();
            var optionsBuilder = new DbContextOptionsBuilder<ShippingCompanyDbContext>();
            
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            _instance = new ShippingCompanyDbContext(optionsBuilder.Options, configuration);
        }
        return _instance;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            
            optionsBuilder.UseLazyLoadingProxies()
                .UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
                .LogTo(Console.WriteLine, LogLevel.Information);;
        }
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Настройка связи многие ко многим для сущностей Ship и TypeOfCargo
        modelBuilder.Entity<ShipTypeOfCargo>()
            .HasKey(cs => new { cs.ShipId, cs.TypeOfCargoId }); // Композитный ключ
        
        modelBuilder.Entity<ShipTypeOfCargo>()
            .HasOne(cs => cs.Ship)
            .WithMany(c => c.ShipTypeOfCargos)
            .HasForeignKey(cs => cs.TypeOfCargoId);
        
        modelBuilder.Entity<ShipTypeOfCargo>()
            .HasOne(cs => cs.TypeOfCargo)
            .WithMany(s => s.ShipTypeOfCargos)
            .HasForeignKey(cs => cs.ShipId);
        
        // Настройка связи многие ко многим для сущностей Voyage и Port
        modelBuilder.Entity<VoyagePort>()
            .HasKey(cs => new { cs.VoyageId, cs.PortId });
        
        modelBuilder.Entity<VoyagePort>()
            .HasOne(cs => cs.Voyage)
            .WithMany(c => c.VoyagePorts)
            .HasForeignKey(cs => cs.PortId);
        
        modelBuilder.Entity<VoyagePort>()
            .HasOne(cs => cs.Port)
            .WithMany(s => s.VoyagePorts)
            .HasForeignKey(cs => cs.VoyageId);
        
        // Настройка связи многие ко многим для сущностей User и MenuItem
        modelBuilder.Entity<UserMenuItem>()
            .HasKey(cs => new { cs.UserId, cs.MenuItemId }); 
        
        modelBuilder.Entity<UserMenuItem>()
            .HasOne(cs => cs.User)
            .WithMany(c => c.UserMenuItems)
            .HasForeignKey(cs => cs.MenuItemId);
        
        modelBuilder.Entity<UserMenuItem>()
            .HasOne(cs => cs.MenuItem)
            .WithMany(s => s.UserMenuItems)
            .HasForeignKey(cs => cs.UserId);
    }
    
    
    
}