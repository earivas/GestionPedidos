using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionPedidos.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public int OrganitationID { get; set; }

        [StringLength(10, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres)", MinimumLength = 1)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string CategoryCode { get; set; }

        [StringLength(60, ErrorMessage = "El campo {0} debe estar entre {2} y {1} caracteres)", MinimumLength = 1)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string  CategoryDescription { get; set; }

        public DateTime CreationDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        public virtual Product Products { get; set; }
    }
}