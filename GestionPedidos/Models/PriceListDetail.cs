﻿using System;
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

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int ProductID { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Display(Name = "Unit Price")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public decimal UnitPrice{ get; set; }

        public bool Status { get; set; }

        public virtual PriceListMaster PriceListMasters { get; set; }
        public virtual Product Products { get; set; }

    }
}