using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShippingCompany.domain.entities;

[Table("CargoShipment")]
public class CargoShipment
{
    [Key]
    public long Id { get; set; }
    [Column("CargoId")]
    public long CargoId { get; set; } // Id груза
    [Column("ShipmentId")]
    public long ShipmentId { get; set; } // Id партии груза
    
    // Навигационные свойства
    public virtual Cargo? Cargo { get; set; }
    public virtual Shipment? Shipment { get; set; }
    
    // Пустой конструктор
    public CargoShipment(){}

    public CargoShipment(long cargoId, long shipmentId)
    {
        this.CargoId = cargoId;
        this.ShipmentId = shipmentId;
    }
}