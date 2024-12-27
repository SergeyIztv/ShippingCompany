using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using ShippingCompany.domain.entities;

namespace ShippingCompany.data.crud;

public class StreetCrud: BaseCrud<Street>
{
    public StreetCrud()
    {
                
    }
    public Street ReadByName(string name)
    {
        return _entities.SingleOrDefault(u => u.Name == name);
    }
}