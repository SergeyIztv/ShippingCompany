using System;
using ShippingCompany.Domain.Entities;

namespace ShippingCompany.domain.entities;

public class CurrentUser
{
    private static readonly Lazy<CurrentUser> _instance = new Lazy<CurrentUser>(() => new CurrentUser());
    
    private CurrentUser() {}
    
    public static CurrentUser Instance => _instance.Value;
    
    public virtual User User { get; set; }

    public void Clear()
    {
        User = null;
    }

    public bool IsLoggedIn()
    {
        return User != null;
    }
}