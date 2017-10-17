using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionPedidos.Models
{
    public class ProductOrder:Product
    {
        public int OrderQty { get; set; }
        public decimal Partial { get { return UnitPrice  * OrderQty; } }

      
    }
}