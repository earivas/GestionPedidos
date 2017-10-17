using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionPedidos.Models
{
    public class OrderDetail
    {
        [Key]
        public int PositionID { get; set; }
        public int OrderID { get; set; }

        public int ProductID { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public int OrderQty { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal UnitPrice { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public int BonifiedQty { get; set; }
        public decimal Partial { get { return UnitPrice * OrderQty; } }
        public virtual Product Products { get; set; }

    }
}