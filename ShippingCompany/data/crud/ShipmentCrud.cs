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
    
    /// <summary>
    /// Найти партии груза по идентификаторам отправляющей и получающей компаний.
    /// </summary>
    /// <param name="companyId">Идентификатор отправляющей компании.</param>
    /// <returns>ObservableCollection найденных партий грузов.</returns>
    public ObservableCollection<Shipment> ReadByCompanyIds(long companyId)
    {
        try
        {
            var shipments = _entities
                .Where(shipment => shipment.SendingCompanyId == companyId &&
                                   shipment.ReceivingCompanyId == companyId)
                .ToList();

            // Преобразуем в ObservableCollection
            return new ObservableCollection<Shipment>(shipments);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка при поиске грузов по компаниям: {e.Message}");
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