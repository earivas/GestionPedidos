using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionPedidos.Models
{
    public class CustomerType
    {
        [Key]
        public int CustomerTypeID { get; set; }
        public string CustomerTypeName { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}