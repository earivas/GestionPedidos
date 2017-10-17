using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionPedidos.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        //public int OrganitationID { get; set; }
        //[StringLength(20,ErrorMessage ="El campo {0} debe estar entre {2} y {1} caracteres)", MinimumLength = 1)]
        //[Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string ProductReference { get; set; }

        [StringLength(100, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres)", MinimumLength = 1)]
        [Required (ErrorMessage = "El campo {0} es obligatorio")]
        public string ProductDescription  { get; set; }

        public int CategoryID { get; set; }

   //     public int PriceListID { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Display(Name = "Unit Price")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public decimal UnitPrice { get; set; }
        public bool Status { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }

        public string CreateBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        // public ICollection<Category> Category {get; set;}

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual Category Category { get; set; }

    }
}