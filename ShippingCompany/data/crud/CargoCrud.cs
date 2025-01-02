using System;
using System.Linq;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShippingCompany.domain.entities;

namespace ShippingCompany.data.crud;

public class CargoCrud: BaseCrud<Cargo>
{
    public CargoCrud()
    {
        
    }
    /// <summary>
    /// Найти грузы по идентификатору партии груза (ShipmentId).
    /// </summary>
    /// <param name="shipmentId">Идентификатор партии груза.</param>
    /// <returns>ObservableCollection найденных грузов.</returns>
    public ObservableCollection<Cargo> ReadByShipmentId(long shipmentId)
    {
        try
        {
            var cargos = _context.Cargo
                .Where(cargo => cargo.ShipmentId == shipmentId)
                .ToList();

            // Преобразуем в ObservableCollection
            return new ObservableCollection<Cargo>(cargos);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Ошибка при поиске грузов по ShipmentId = {shipmentId}: {e.Message}");
            throw;
        }
    }

}