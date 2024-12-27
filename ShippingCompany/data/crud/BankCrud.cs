using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using ShippingCompany.domain.entities;

namespace ShippingCompany.data.crud;

public class BankCrud: BaseCrud<Bank>
{
    public BankCrud()
    {
                
    }
    public Bank ReadByName(string name)
    {
        return _entities.SingleOrDefault(u => u.Name == name);
    }
}