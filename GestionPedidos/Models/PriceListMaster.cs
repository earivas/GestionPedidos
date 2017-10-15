using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionPedidos.Models
{
    public class PriceListMaster
    {
        [Key]
        public int PriceListID { get; set; }
        public string PriceListName { get; set; }

        public DateTime PriceListDateActivation { get; set; }
        public DateTime PriceListFinishDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool Status { get; set; }
    }
}