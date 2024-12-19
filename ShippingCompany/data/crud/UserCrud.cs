using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShippingCompany.domain.entities;
using ShippingCompany.Domain.Entities;

namespace ShippingCompany.data.crud;

public class UserCrud: BaseCrud<User>
{
        public UserCrud() :base()
        {
                
        }

        public User ReadByLogin(string login)
        {
                return _entities.SingleOrDefault(u => u.Login == login);
        }
}