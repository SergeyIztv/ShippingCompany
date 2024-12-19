using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShippingCompany.domain.entities
{
    [Table("Cargo")]
    public class Cargo
    {
        [Column("Id")]
        public long Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("TypeOfCargoId")]
        public long? TypeOfCargoId { get; set; } // Id тип груза
        [Column("UnitOfMeasurementId")]
        public long? UnitOfMeasurementId { get; set; } // Id единицы измерения
        [Column("DeclaredCargo")]
        public float DeclaredCargo { get; set; } // Заявленная величина груза
        [Column("InsuredCargo")]
        public float InsuredCargo { get; set; } // Застрахованная величина груза

        // Навигационные свойства
        public virtual TypeOfCargo TypeOfCargo { get; set; } // Отношение с TypeOfCargo
        public virtual UnitOfMeasurement UnitOfMeasurement { get; set; } // Отношение с UnitOfMeasurement
        
        // Навигационное свойство для доступа к связанным CargoShipments
        public virtual ICollection<CargoShipment> CargoShipments { get; set; } = new List<CargoShipment>();

        // Пустой конструктор
        public Cargo() {}

        // Конструктор с параметрами
        public Cargo(string name, long? typeOfCargoId, long? unitOfMeasurementId,
            float declaredCargo, float insuredCargo)
        {
            this.Name = name; // Необходимо исправить здесь
            this.TypeOfCargoId = typeOfCargoId;
            this.UnitOfMeasurementId = unitOfMeasurementId;
            this.DeclaredCargo = declaredCargo;
            this.InsuredCargo = insuredCargo;
        }
    }
}