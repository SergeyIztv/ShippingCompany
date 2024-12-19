using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ShippingCompany.domain.enums;

namespace ShippingCompany.domain.entities
{
    [Table("Ship")]
    public class Ship
    {
        [Column("Id")]
        public long Id { get; set; } // ID судна
        [Column("Name")]
        public string Name { get; set; } // Название судна
        [Column("RegistrationNumber")]
        public string RegistrationNumber { get; set; } // Регистрационный номер судна
        [Column("FullNameOfCaptain")]
        public string FullNameOfCaptain { get; set; } // ФИО капитана
        [Column("ShipType")]
        public ShipTypes? ShipType { get; set; } // Тип судна
        [Column("Tonnage")]
        public int Tonnage { get; set; } // Грузоподъемность
        [Column("YearOfBuilt")]
        public int YearOfBuilt { get; set; } // Год постройки
        [Column("PhotoPath")]
        public string PhotoPath { get; set; } // Путь к файлу фотографии судна
        [Column("PortId")]
        public long? PortId { get; set; } // ID порта

        // Навигационное свойство
        public Port Port { get; set; } // Объект Port
        
        // Навигационное свойство для доступа к связанным ShipTypeOfCargo
        public virtual ICollection<ShipTypeOfCargo> ShipTypeOfCargos { get; set; } = new List<ShipTypeOfCargo>();

        // Пустой конструктор
        public Ship() {}

        // Конструктор с параметрами
        public Ship(string registrationNumber, string name,
            string fullNameOfCaptain, ShipTypes shipType,
            int tonnage, int yearOfBuilt, string photoPath, long? portId)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.FullNameOfCaptain = fullNameOfCaptain;
            this.ShipType = shipType;
            this.Tonnage = tonnage;
            this.YearOfBuilt = yearOfBuilt;
            this.PhotoPath = photoPath;
            this.PortId = portId; // Сохранение идентификатора порта
        }
    }
}