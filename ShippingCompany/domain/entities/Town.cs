using System.ComponentModel.DataAnnotations.Schema;

namespace ShippingCompany.domain.entities{
    [Table("Town")]
    public class Town
    {
        [Column("Id")]
        public long Id{get;set;}
        [Column("Name")]
        public string Name{get;set;}

        // Пустой конструктор
        public Town(){}
        
        public Town(string name)
        {
            this.Name = name;
        }
    }
}