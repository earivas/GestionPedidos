using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionPedidos.Models
{
    public class PriceListDetail
    {
        [Key]
        public int PositionID { get; set; }
        public int PriceListID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice{ get; set; }
        public bool Status { get; set; }

    }
}