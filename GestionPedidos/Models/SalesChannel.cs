using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionPedidos.Models
{
    public class SalesChannel
    {
        [Key]
        public int SalesChennelID { get; set; }
   
        public string SalesChannelName { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}