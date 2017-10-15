using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionPedidos.Models
{
    public class BranchOffice
    {
        [Key]
        public int BranchOfficeID { get; set; }
        public int CustomerID { get; set; }
        public string BranchOfficeAddress { get; set; }
    }
}