using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShippingCompany.domain.entities;
[Table("VoyagePort")]
public class VoyagePort
{
    [Key]
    public long Id { get; set; }
    [Column("VoyageId")]
    public long VoyageId { get; set; } // Id рейса
    [Column("PortId")]
    public long PortId { get; set; } // Id порта
    
    // Навигационные свойства
    public virtual Voyage Voyage { get; set; } // Рейс
    public virtual Port Port { get; set; } // Порт
    
    // Пустой конструктор
    public VoyagePort() { }

    public VoyagePort(long voyageId, long portId)
    {
        this.VoyageId = voyageId;
        this.PortId = portId;
    }
}