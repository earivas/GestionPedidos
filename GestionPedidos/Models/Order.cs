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
     //   public int SalesManID { get; set; }

      //  [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[DataType(DataType.DateTime)]
        //public DateTime CreationDate { get; set; }

        //public string CreateBy { get; set; }

        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[DataType(DataType.DateTime)]
        //public DateTime ModifiedDate { get; set; }

        //public string ModifiedBy { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}