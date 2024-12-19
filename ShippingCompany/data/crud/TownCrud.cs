
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShippingCompany.domain.entities;

namespace ShippingCompany.data.crud;

public class TownCrud: BaseCrud<Town>
{
    public TownCrud(): base()
    {
                
    }
    public Town ReadByName(string name)
    {
        return _entities.SingleOrDefault(u => u.Name == name);
    }
}