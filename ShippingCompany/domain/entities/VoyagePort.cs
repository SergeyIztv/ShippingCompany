namespace ShippingCompany.domain.entities;

public class VoyagePort
{
    public long Id { get; set; }
    public long VoyageId { get; set; } // Id рейса
    public long PortId { get; set; } // Id порта
    
    // Навигационные свойства
    public Voyage Voyage { get; set; } // Рейс
    public Port Port { get; set; } // Порт
    
    // Пустой конструктор
    public VoyagePort() { }

    public VoyagePort(long voyageId, long portId)
    {
        this.VoyageId = voyageId;
        this.PortId = portId;
    }
}