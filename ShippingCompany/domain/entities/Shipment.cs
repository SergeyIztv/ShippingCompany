using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShippingCompany.domain.entities
{
    // Партия груза
    [Table("Shipment")]
    public class Shipment 
    {
        [Column("Id")]
        public long Id { get; set; } // ID
        [Column("CustomsBatchNumber")]
        public string CustomsBatchNumber { get; set; } // Таможенный номер партии
        [Column("CustomsDeclarationNumber")]
        public string CustomsDeclarationNumber { get; set; } // Номер таможенной декларации
        [Column("DepartureDate", TypeName = "date")]
        public DateTime? DepartureDate { get; set; } // Дата отбытия
        [Column("ArrivalDate", TypeName = "date")]
        public DateTime? ArrivalDate { get; set; } // Дата прибытия
        [Column("SendingCompanyId")]
        public long? SendingCompanyId { get; set; } // Id компании отправителя
        [Column("ReceivingCompanyId")]
        public long? ReceivingCompanyId { get; set; } // Id компании получателя
        [Column("VoyageId")]
        public long? VoyageId { get; set; } // Id рейса
        [Column("SourcePortId")]
        public long? SourcePortId { get; set; } // Id порта отправления
        [Column("DestinationPortId")]
        public long? DestinationPortId { get; set; } // Id порта назначения

        // Навигационные свойства
        public virtual ClientCompany SendingCompany { get; set; } // Организация отправитель
        public virtual ClientCompany ReceivingCompany { get; set; } // Организация получатель
        public virtual Voyage Voyage { get; set; } // Рейс
        public virtual Port SourcePort { get; set; } // Порт отправления
        public virtual Port DestinationPort { get; set; } // Порт назначения
        
        
        
        // Пустой конструктор
        public Shipment() {}

        // Конструктор с параметрами
        public Shipment(long? sendingCompanyId,
            long? receivingCompanyId, long? voyageId,
            long? destinationPortId, long? sourcePortId, 
            string customsBatchNumber, string customsDeclarationNumber, 
            DateTime? departureDate, DateTime? arrivalDate)
        {
            this.SendingCompanyId = sendingCompanyId;
            this.ReceivingCompanyId = receivingCompanyId;
            this.VoyageId = voyageId;
            this.DestinationPortId = destinationPortId;
            this.SourcePortId = sourcePortId;
            this.CustomsBatchNumber = customsBatchNumber;
            this.CustomsDeclarationNumber = customsDeclarationNumber;
            this.DepartureDate = departureDate;
            this.ArrivalDate = arrivalDate;
        }
    }
}
