using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using ShippingCompany.domain.enums;

namespace ShippingCompany.domain.entities
{
    [Table("Ship")]
    public class Ship : INotifyPropertyChanged
    {
        private string _name;
        private string _registrationNumber;
        private string _fullNameOfCaptain;
        private ShipTypes? _shipType;
        private int _tonnage;
        private int _yearOfBuilt;
        private string _photoPath;
        private long? _portId;
        private Port _port;

        [Column("Id")]
        public long Id { get; set; }

        [Column("Name")]
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        [Column("RegistrationNumber")]
        public string RegistrationNumber
        {
            get => _registrationNumber;
            set
            {
                if (_registrationNumber != value)
                {
                    _registrationNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        [Column("FullNameOfCaptain")]
        public string FullNameOfCaptain
        {
            get => _fullNameOfCaptain;
            set
            {
                if (_fullNameOfCaptain != value)
                {
                    _fullNameOfCaptain = value;
                    OnPropertyChanged();
                }
            }
        }

        [Column("ShipType")]
        public ShipTypes? ShipType
        {
            get => _shipType;
            set
            {
                if (_shipType != value)
                {
                    _shipType = value;
                    OnPropertyChanged();
                }
            }
        }

        [Column("Tonnage")]
        public int Tonnage
        {
            get => _tonnage;
            set
            {
                if (_tonnage != value)
                {
                    _tonnage = value;
                    OnPropertyChanged();
                }
            }
        }

        [Column("YearOfBuilt")]
        public int YearOfBuilt
        {
            get => _yearOfBuilt;
            set
            {
                if (_yearOfBuilt != value)
                {
                    _yearOfBuilt = value;
                    OnPropertyChanged();
                }
            }
        }

        [Column("PhotoPath")]
        public string PhotoPath
        {
            get => _photoPath;
            set
            {
                if (_photoPath != value)
                {
                    _photoPath = value;
                    OnPropertyChanged();
                }
            }
        }

        [Column("PortId")]
        public long? PortId
        {
            get => _portId;
            set
            {
                if (_portId != value)
                {
                    _portId = value;
                    OnPropertyChanged();
                }
            }
        }

        // Навигационное свойство
        public virtual Port Port
        {
            get => _port;
            set
            {
                if (_port != value)
                {
                    _port = value;
                    OnPropertyChanged();
                }
            }
        }

        // Навигационное свойство для доступа к связанным ShipTypeOfCargo
        public virtual ICollection<ShipTypeOfCargo> ShipTypeOfCargos { get; set; } = new List<ShipTypeOfCargo>();

        // Пустой конструктор
        public Ship() { }

        // Конструктор с параметрами
        public Ship(string registrationNumber, string name,
            string fullNameOfCaptain, ShipTypes shipType,
            int tonnage, int yearOfBuilt, string photoPath, long? portId)
        {
            Name = name;
            RegistrationNumber = registrationNumber;
            FullNameOfCaptain = fullNameOfCaptain;
            ShipType = shipType;
            Tonnage = tonnage;
            YearOfBuilt = yearOfBuilt;
            PhotoPath = photoPath;
            PortId = portId;
        }

        // Реализация интерфейса INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
