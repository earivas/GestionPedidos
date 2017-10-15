using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionPedidos.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }

        public string CustomerAddress { get; set;  }

        public int PaymentTerm { get; set; }

        public int PriceListID { get; set; }

        public int CanalID { get; set; }
        public int SalesManID { get; set; }
        public int CustomerTypeID { get; set; }

        public DateTime CreationDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

    }
}