using GestionPedidos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionPedidos.Controllers
{
    public class SalesOrderController : Controller
    {
        private GestionPedidosContext db = new GestionPedidosContext();
        // GET: SalesOrder
        public ActionResult NewOrder()
        {
            OrderView orderView = new OrderView();
            orderView.Customer = new CustomerOrder();
            orderView.Products = new List<ProductOrder>();

            var listC = db.Customers.ToList();
            ViewBag.CustomerID = new SelectList(listC, "CustomerID", "CustomerName");

            Session["OrderView"] = orderView;

            var listB = db.BranchOffices.ToList();
            ViewBag.BranchOfficeID = new SelectList(listB, "BranchOfficeID", "BranchOfficeID");
            return View(orderView);
        }
        [HttpPost]

        public ActionResult NewOrder(OrderView orderView)
        {
            orderView = Session["OrderView"] as OrderView;
            // Lo que se ingreso por pantalla
            int customerID = int.Parse(Request["CustomerID"]);
            var dateOrder = DateTime.Parse(Request["Customer.OrderDate"]);  // Customer.OrderDate

            int lastOrderID = 0;

            using (var transaction = db.Database.BeginTransaction())
            {

                try
                {

                    Order newOrder = new Order
                    {
                        CustomerID = customerID,
                        OrderDate = dateOrder

                    };
                    db.Orders.Add(newOrder);
                    db.SaveChanges();

                    lastOrderID = db.Orders.ToList().Select(o => o.OrderID).Max();
                    // Validar si el producto es Bonificado

                    foreach (ProductOrder item in orderView.Products)
                    {

                        // ***  Validar que MinOrder y QtyBon nop sean null
                        var MinOrder = db.Bonifieds.Where(b => b.CustomerID == customerID && b.ProductID == item.ProductID).Select(b => b.MinimunOrderQty).Sum();
                        var QtyBon = db.Bonifieds.Where(b => b.CustomerID == customerID && b.ProductID == item.ProductID).Select(b => b.BonifiedQty).Sum();
                        double Factor = (double)QtyBon / (double)MinOrder;

                     //   int lastOrderID = db.Orders.ToList().Select(o => o.OrderID).Max();
                     //   orderID = db.Orders.ToList().Select(o => o.OrderID).Max();
                        var detail = new OrderDetail()
                        {
                            OrderID = lastOrderID,
                            ProductID = item.ProductID,
                            OrderQty = item.OrderQty,
                            UnitPrice = item.UnitPrice,
                            // BonifiedQty = item.OrderQty * Factor//decimal.Parse(Factor)

                        };

                        db.OrderDetails.Add(detail);
                        db.SaveChanges();
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    ViewBag.Error = "ERROR:  " + ex.Message;
                    orderView = Session["OrderView"] as OrderView;
              //      var listC = db.Customers.ToList();
                    ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName");
                    ViewBag.BranchOfficeID = new SelectList(db.BranchOffices, "BranchOfficeID", "BranchOfficeAddress");
                    return View(orderView);
                }
               
            }

            ViewBag.Message = string.Format("La orden: {0}, grabada correctamente", lastOrderID);
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerName");
            ViewBag.BranchOfficeID = new SelectList(db.BranchOffices, "BranchOfficeID", "BranchOfficeAddress");
            return View(orderView);

        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            var listP = db.Products.ToList();
            ViewBag.ProductID = new SelectList(listP, "ProductID", "ProductDescription");

            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(ProductOrder productOrder)
        {
            var orderView = Session["OrderView"] as OrderView;
            var ProductID = int.Parse(Request["ProductID"]);
            //buscar el producto
            var product = db.Products.Find(ProductID);
            productOrder = new ProductOrder();
            {
                productOrder.ProductID = product.ProductID;
                productOrder.ProductDescription = product.ProductDescription;
                productOrder.UnitPrice = product.UnitPrice;
                productOrder.OrderQty = int.Parse(Request["OrderQty"]);


            };

            orderView.Products.Add(productOrder);

            var listC = db.Customers.ToList();
            ViewBag.CustomerID = new SelectList(listC, "CustomerID", "CustomerName");
            var listP = db.Products.ToList();
            ViewBag.ProductID = new SelectList(listP, "ProductID", "ProductDescription");
            ViewBag.BranchOfficeID = new SelectList(db.BranchOffices, "BranchOfficeID", "BranchOfficeAddress");
            return View("NewOrder", orderView);
        }
    }
}