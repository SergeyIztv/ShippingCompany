using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using ShippingCompany.domain.entities;

namespace ShippingCompany.data.crud;

public class UnitOfMeasurementCrud: BaseCrud<UnitOfMeasurement>
{
    public UnitOfMeasurementCrud()
    {
                
    }
    public UnitOfMeasurement ReadByName(string name)
    {
        return _entities.SingleOrDefault(u => u.Name == name);
    }
}