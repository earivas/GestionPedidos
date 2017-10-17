using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionPedidos.Models
{
    public class OrderStatus

    {
        [Key]
        public int OrderStatusID { get; set; }
        public int OrderID { get; set; }


    }
}