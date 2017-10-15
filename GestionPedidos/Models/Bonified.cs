using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionPedidos.Models
{
    public class Bonified
    {
        [Key]
        public int BonifiedID { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        public int MinimunOrderQty { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        public int BonifiedQty { get; set; }

        public bool status { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime BonifiedActivationDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime BonifiedFinishDate { get; set; }

        public decimal Factor { get { return BonifiedQty / MinimunOrderQty; } }

        public DateTime CreationDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public virtual Customer Customers { get; set; }
        public virtual Product Products { get; set;   }

    }
}