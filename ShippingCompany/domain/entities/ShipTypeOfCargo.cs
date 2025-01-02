using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ShippingCompany.Domain.Entities;
namespace ShippingCompany.domain.entities;

public class ShipTypeOfCargo
{
    [Key]
    public long Id { get; set; }
    [Column("ShipId")]
    public long ShipId { get; set; } // Id судна
    [Column("TypeOfCargoId")]
    public long TypeOfCargoId { get; set; } // Id типа груза
    
    // Навигационные свойства
    public virtual Ship Ship { get; set; } // Судно
    public virtual TypeOfCargo TypeOfCargo { get; set; } // Тип груза
    
    // Пустой конструктор
    public ShipTypeOfCargo(){}

    public ShipTypeOfCargo(long shipId, long typeOfCargoId)
    {
        this.ShipId = shipId;
        this.TypeOfCargoId = typeOfCargoId;
    }
}