using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Controls;
using ShippingCompany.Domain.Entities;

namespace ShippingCompany.domain.entities;

[Table("UserMenuItem")]
public class UserMenuItem
{
    [Column("Id")]
    public long Id { get; set; }
    [Column("UserId")]
    public long UserId { get; set; } // Id пользователя
    [Column("MenuItemId")]
    public long MenuItemId { get; set; } // Id пункта меню
    
    // Права пользователя на доступ и обработку данных: читать, добавлять, редактировать удалять.
    // TRUE - разрешено, FALSE - запрещено
    [Column("CanRead")]
    public bool CanRead { get; set; } // Читать
    [Column("CanWrite")]
    public bool CanWrite { get; set; } // Добавлять
    [Column("CanEdit")]
    public bool CanEdit { get; set; } // Редактировать
    [Column("CanDelete")]
    public bool CanDelete { get; set; } // Удалять
    
    // Навигационные свойства
    public User User { get; set; }
    public MenuItem MenuItem { get; set; }
    
    // Пустой конструктор
    public UserMenuItem(){}

    public UserMenuItem(long userId, long menuItemId, bool canRead, bool canWrite, bool canEdit, bool canDelete)
    {
        this.UserId = userId;
        this.MenuItemId = menuItemId;
        this.CanRead = canRead;
        this.CanWrite = canWrite;
        this.CanEdit = canEdit;
        this.CanDelete = canDelete;
    }
}