using System.ComponentModel.DataAnnotations.Schema;

namespace ShippingCompany.domain.entities{
    [Table("UnitOfMeasurement")]
    public class UnitOfMeasurement
    {
        [Column("Id")]
        public long Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }

        // Пустой конструктор
        public UnitOfMeasurement(){}
        
        public UnitOfMeasurement(string name)
        {
            this.Name = name;
        }
    }
}