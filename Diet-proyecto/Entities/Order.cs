﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Diet_proyecto.Enum;

namespace Diet_proyecto.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int TotalPrice { get; set; }  //suma de todos los itemOrder
        public Status StatusType { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public Client Client { get; set; }
        public ICollection<Client> Clients { get; set; } = new List<Client>();

        public Order()
        {
            StatusType = Status.Inactive;
            PaymentStatus = PaymentStatus.Unpaid;
        }
    }
}
