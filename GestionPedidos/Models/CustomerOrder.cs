using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionPedidos.Models
{
    public class CustomerOrder: Customer


    {
        [Display (Name = "Fecha Orden")]
       // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        public int OrderNumber { get; set; }

        public int BranchOfficeID { get; set; }
    
        //   public int BranchOfficeID { get; set; }


    }
}