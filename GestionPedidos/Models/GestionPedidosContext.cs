using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GestionPedidos.Models
{
    public class GestionPedidosContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public GestionPedidosContext() : base("name=GestionPedidosContext")
        {
        }

        public System.Data.Entity.DbSet<GestionPedidos.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<GestionPedidos.Models.BranchOffice> BranchOffices { get; set; }

        public System.Data.Entity.DbSet<GestionPedidos.Models.Bonified> Bonifieds { get; set; }

        public System.Data.Entity.DbSet<GestionPedidos.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<GestionPedidos.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<GestionPedidos.Models.SalesMan> SalesMen { get; set; }

        public System.Data.Entity.DbSet<GestionPedidos.Models.PriceListMaster> PriceListMasters { get; set; }

        public System.Data.Entity.DbSet<GestionPedidos.Models.PriceListDetail> PriceListDetails { get; set; }

        public System.Data.Entity.DbSet<GestionPedidos.Models.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<GestionPedidos.Models.OrderDetail> OrderDetails { get; set; }

        public System.Data.Entity.DbSet<GestionPedidos.Models.SalesChannel> SalesChannels { get; set; }

        public System.Data.Entity.DbSet<GestionPedidos.Models.CustomerType> CustomerTypes { get; set; }
    }
}
