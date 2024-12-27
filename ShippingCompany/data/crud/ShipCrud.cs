using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShippingCompany.domain.entities;
using System.Linq;

namespace ShippingCompany.data.crud;

public class ShipCrud: BaseCrud<Ship>
{
    public ShipCrud()
    {
                
    }
    public Ship ReadByName(string name)
    {
        return _entities.SingleOrDefault(u => u.Name == name);
    }
}