using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;
using ShippingCompany.domain.entities;

namespace ShippingCompany.data.crud;

public class VoyageCrud: BaseCrud<Voyage>
{
    public VoyageCrud()
    {

    }
}