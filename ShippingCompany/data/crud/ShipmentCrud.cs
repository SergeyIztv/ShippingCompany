using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShippingCompany.domain.entities;
using System.Linq;

namespace ShippingCompany.data.crud;

public class ShipmentCrud: BaseCrud<Shipment>
{
    public ShipmentCrud()
    {
                
    }
    public List<Shipment> ReadByVoyageId(long voyageId)
    {
        try
        {
            return _entities
                .Where(stoc => stoc.VoyageId == voyageId)
                .ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public void UpdateRange(ObservableCollection<Shipment> shipments)
    {
        foreach (var shipment in shipments)
        {
            _context.Entry(shipment).State = EntityState.Modified;
        }
        _context.SaveChanges();
    }
}