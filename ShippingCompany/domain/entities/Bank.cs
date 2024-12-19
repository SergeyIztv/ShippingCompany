using System.ComponentModel.DataAnnotations.Schema;

namespace ShippingCompany.domain.entities{
    [Table("Bank")]
    public class Bank
    {
        [Column("Id")]
        public long Id { get; private set; }
        [Column("Name")]
        public string Name { get; set; }

        // Пустой конструктор
        public Bank() {}
        
        public Bank(string name)
        {
            this.Name = name;
        }
    }
}