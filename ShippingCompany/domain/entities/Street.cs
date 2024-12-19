using System.ComponentModel.DataAnnotations.Schema;

namespace ShippingCompany.domain.entities{
    [Table("Street")]
    public class Street
    {
        [Column("Id")]
        public long Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }

        // Пустой конструктор
        public Street(){}
        
        public Street(string name)
        {
            this.Name = name;
        }
    }
}