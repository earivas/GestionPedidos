using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionPedidos.Models
{
    public class Organitation
    {
        [Key]
        public int OrganitationID { get; set; }
        public int OrganitationCode { get; set; }
        public string OrganitationName { get; set; }
        public string organitationAddress { get; set; }
    }
}