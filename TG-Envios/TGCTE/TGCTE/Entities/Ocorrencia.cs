using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TGCTE.Entities
{
    public class Ocorrencia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int codigo { get; set; }
        public DateTime? dataEnvio { get; set; }
        public string status { get; set; }
        public DateTime? dataImportacao { get; set; }
        public int? numeroTentativasEnvio { get; set; }
        public string orderNumber { get; set; }
        public string carrierCode { get; set; }
        public string sellerId { get; set; }
        public string carrierDocumentNumber { get; set; }
        public string vehicleRegistrationPlate { get; set; }
        public string driverName { get; set; }
        public string driverPhone { get; set; }
        public string extraInfo { get; set; }
        public string eventDateTime { get; set; }
        public string trackingSource { get; set; }
        public string eventType { get; set; }
        public string recipientName { get; set; }
        public string recipientRelationship { get; set; }
        public string vendorDocumentNumber { get; set; }
        public string invoiceNumber { get; set; }
        public string invoiceSerialNumber { get; set; }
        public string invoiceControlNumber { get; set; }
        public int isDeliveryAddressFound { get; set; }
        public int isBestPhoneUsed { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public DateTime? media { get; set; }
        public string extraPhone { get; set; }
        public string carrierEventCode { get; set; }
        public string carrierEventDescription { get; set; }
    }

}
