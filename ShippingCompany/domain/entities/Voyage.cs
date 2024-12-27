using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShippingCompany.domain.entities
{
    [Table("Voyage")]
    public class Voyage
    {
        [Column("Id")]
        public long Id { get; set; }
        [Column("DepartureDate")]
        public DateTime? DepartureDate { get; set; } // Дата убытия
        [Column("ArrivalDate")]
        public DateTime? ArrivalDate { get; set; } // Дата прибытия
        [Column("ShipId")]
        public long? ShipId { get; set; } // Идентификатор судна
        [Column("DestinatinPortId")]
        public long? DestinationPortId { get; set; } // Идентификатор порта назначения
        [Column("SourcePortId")]
        public long? SourcePortId { get; set; } // Идентификатор порта отправления
        
        // Навигационные свойства
        public Ship Ship { get; set; } // Судно
        public Port DestinationPort { get; set; } // Порт назначения
        public Port SourcePort { get; set; } // Порт отправления
        
        // Навигационное свойство для доступа к связанным VoyagePort
        public virtual ICollection<VoyagePort> VoyagePorts { get; set; } = new List<VoyagePort>();
        
        // Пустой конструктор
        public Voyage(){}

        // Конструктор с параметрами
        public Voyage(DateTime? departureDate, DateTime? arrivalDate, long? shipId, long? destinationPortId, long? sourcePortId)
        {
            DepartureDate = departureDate;
            ArrivalDate = arrivalDate;
            ShipId = shipId;
            DestinationPortId = destinationPortId;
            SourcePortId = sourcePortId;
        }
    }
}