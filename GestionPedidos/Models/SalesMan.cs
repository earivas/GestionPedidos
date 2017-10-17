using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionPedidos.Models
{
    public class SalesMan
    {
        [Key]
        public int SalesManID { get; set; }
        public string SalesManCode { get; set; }

        public string SalesManName { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}