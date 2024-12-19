using System.ComponentModel.DataAnnotations.Schema;
using ShippingCompany.domain.enums;

namespace ShippingCompany.domain.entities
{
    [Table("ClientCompany")]
    public class ClientCompany
    {
        [Column("Id")]
        public long Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("HouseNumber")]
        public string HouseNumber { get; set; } // Номер дома
        [Column("OfficeNumber")]
        public string OfficeNumber { get; set; } // Номер офиса
        [Column("IndividualTaxplayerNumber")]
        public int IndividualTaxpayerNumber { get; set; } // ИНН
        [Column("TownId")]
        public long? TownId { get; set; } // Id города
        [Column("StreetId")]
        public long? StreetId { get; set; } // Id улицы
        [Column("BankId")]
        public long? BankId { get; set; } // Id банка

        // Навигационные свойства
        public virtual Town Town { get; set; } // Отношение с Town
        public virtual Street Street { get; set; } // Отношение с Street
        public virtual Bank Bank { get; set; } // Отношение с Bank

        // Пустой конструктор
        public ClientCompany() {}

        // Конструктор с параметрами
        public ClientCompany(string name, long? townId,
            long? streetId, string houseNumber, string officeNumber,
            long? bankId, int individualTaxpayerNumber)
        {
            this.Name = name;
            this.TownId = townId;
            this.StreetId = streetId;
            this.HouseNumber = houseNumber;
            this.OfficeNumber = officeNumber;
            this.BankId = bankId;
            this.IndividualTaxpayerNumber = individualTaxpayerNumber;
        }
    }
}