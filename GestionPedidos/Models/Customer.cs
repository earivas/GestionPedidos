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
        public int SalesChennelID { get; set; }
        public int SalesManID { get; set; }
        public int CustomerTypeID { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }
        public string CreateBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual SalesChannel SalesChannel { get; set; }
        public virtual SalesMan SalesMen { get; set; }
        public virtual CustomerType CustomerType { get; set; }
        public virtual ICollection<BranchOffice> BranchOffice { get; set; }

    }
}