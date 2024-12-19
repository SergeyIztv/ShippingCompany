using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShippingCompany.domain.entities{
    [Table("Port")]
    public class Port
    {
        [Column("Id")]
        public long Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }

        // Навигационное свойство для доступа к связанным VoyagePort
        public virtual ICollection<VoyagePort> VoyagePorts { get; set; } = new List<VoyagePort>();
        
        // Пустой конструктор
        public Port(){}
        
        public Port(string name)
        {
            this.Name = name;
        }
    }
}