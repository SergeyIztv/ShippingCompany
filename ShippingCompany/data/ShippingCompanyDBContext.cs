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
    
    public DbSet<Ship> Ship { get; set; }
    public DbSet<Bank> Bank { get; set; }
    public DbSet<Cargo> Cargo { get; set; }
    public DbSet<ClientCompany> ClientCompany { get; set; }
    public DbSet<Port> Port { get; set; }
    public DbSet<Shipment> Shipment { get; set; }
    public DbSet<Street> Street { get; set; }
    public DbSet<Town> Town { get; set; }
    public DbSet<TypeOfCargo> TypeOfCargo { get; set; }
    public DbSet<UnitOfMeasurement> UnitOfMeasurement { get; set; }
    public DbSet<Voyage> Voyages { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<MenuItem> MenuItem { get; set; }
    public DbSet<ShipTypeOfCargo> ShipTypeOfCargo { get; set; }
    public DbSet<UserMenuItem> UserMenuItem { get; set; }
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
                .UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        }
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Настройка двух связей один ко многим
        modelBuilder.Entity<Shipment>()
            .HasOne(s => s.ReceivingCompany)
            .WithMany()
            .HasForeignKey(s => s.ReceivingCompanyId)
            .OnDelete(DeleteBehavior.Restrict); // Настройка поведения удаления, если требуется

        modelBuilder.Entity<Shipment>()
            .HasOne(s => s.SendingCompany)
            .WithMany()
            .HasForeignKey(s => s.SendingCompanyId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // Настройка связи многие ко многим для сущностей Ship и TypeOfCargo
        modelBuilder.Entity<ShipTypeOfCargo>()
            .HasKey(cs => new { cs.ShipId, cs.TypeOfCargoId }); // Композитный ключ
        
        modelBuilder.Entity<ShipTypeOfCargo>()
            .HasOne(cs => cs.Ship)
            .WithMany(c => c.ShipTypeOfCargos)
            .HasForeignKey(cs => cs.ShipId);
        
        modelBuilder.Entity<ShipTypeOfCargo>()
            .HasOne(cs => cs.TypeOfCargo)
            .WithMany(s => s.ShipTypeOfCargos)
            .HasForeignKey(cs => cs.TypeOfCargoId);
        
        // Настройка связи многие ко многим для сущностей Voyage и Port
        modelBuilder.Entity<VoyagePort>()
            .HasKey(vp => new { vp.VoyageId, vp.PortId }); // Композитный ключ
    
        modelBuilder.Entity<VoyagePort>()
            .HasOne(vp => vp.Voyage)
            .WithMany(v => v.VoyagePorts)
            .HasForeignKey(vp => vp.VoyageId); // Связь с таблицей Voyage
    
        modelBuilder.Entity<VoyagePort>()
            .HasOne(vp => vp.Port)
            .WithMany(p => p.VoyagePorts)
            .HasForeignKey(vp => vp.PortId); // Связь с таблицей Port
        
        // Настройка связи многие ко многим для сущностей User и MenuItem
        modelBuilder.Entity<UserMenuItem>()
            .HasKey(cs => new { cs.UserId, cs.MenuItemId }); 
        
        modelBuilder.Entity<UserMenuItem>()
            .HasOne(cs => cs.User)
            .WithMany(c => c.UserMenuItems)
            .HasForeignKey(cs => cs.UserId);
        
        modelBuilder.Entity<UserMenuItem>()
            .HasOne(cs => cs.MenuItem)
            .WithMany(s => s.UserMenuItems)
            .HasForeignKey(cs => cs.MenuItemId);
    }
    
    
    
}