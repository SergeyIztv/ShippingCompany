namespace ShippingCompany.domain.entities;

public class ShipTypeOfCargo
{
    public long Id { get; set; }
    public long ShipId { get; set; } // Id судна
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