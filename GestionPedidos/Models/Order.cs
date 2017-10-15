using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionPedidos.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        public int OrderNumber { get; set; }

        public int CustomerID { get; set; }

        public int BranchOfficeID { get; set; }
        public int SalesManID { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; }

        public DateTime CreationDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}