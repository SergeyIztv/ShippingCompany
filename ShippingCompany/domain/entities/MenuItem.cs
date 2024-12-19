using System.Collections.Generic;

namespace ShippingCompany.domain.entities;

public class MenuItem
{
    public long Id { get; set; }
    public long? ParentItemId { get; set; } // Id родительского пункта
    public string Name { get; set; } // Имя пункта меню
    public string NameOfDll { get; set; } // Имя DLL
    public string NameOfFunction { get; set; } // Имя функции
    public long SequenceNumber { get; set; } // Порядок - последовательность отображения пункта меню
    
    // Навигационное свойство
    public virtual MenuItem ParentItem { get; set; }
    
    // Навигационное свойство для доступа к связанным UserMenuItem
    public virtual ICollection<UserMenuItem> UserMenuItems { get; set; } = new List<UserMenuItem>();

    // Пустой конструктор
    public MenuItem(){}
    
    public MenuItem(long? parentItemId, string name, string nameOfDll, string nameOfFunction,
        long sequenceNumber)
    {
        this.ParentItemId = parentItemId;
        this.Name = name;
        this.NameOfDll = nameOfDll;
        this.NameOfFunction = nameOfFunction;
        this.SequenceNumber = sequenceNumber;
    }
}