using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShippingCompany.domain.entities{
    [Table("TypeOfCargo")]
    public class TypeOfCargo
    {
        [Column("Id")]
        public long Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        
        // Навигационное свойство для доступа к связанным ShipTypeOfCargo
        public virtual ICollection<ShipTypeOfCargo> ShipTypeOfCargos { get; set; } = new List<ShipTypeOfCargo>();

        // Пустой конструктор
        public TypeOfCargo(){}
        
        public TypeOfCargo(string name)
        {
            this.Name = name;
        }
    }
}