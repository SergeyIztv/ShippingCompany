using System;
using System.Collections.Generic;
using System.Linq;
using ShippingCompany.domain.entities;
using ShippingCompany.Exceptions;

namespace ShippingCompany.data.crud;

public class ShipTypeOfCargoCrud: BaseCrud<ShipTypeOfCargo>
{
    public ShipTypeOfCargoCrud(): base(){}
    public List<ShipTypeOfCargo> ReadByShipId(long shipId)
    {
        try
        {
            return _entities
                .Where(stoc => stoc.ShipId == shipId)
                .ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
}