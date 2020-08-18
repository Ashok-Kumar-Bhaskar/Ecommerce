
using ECommerce.HelperClasses;
using ECommerce.Models;
using ECommerce.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace ECommerce.DBOperations
{
  public class DataOperations
  {
    private ECommerceEntities db = new ECommerceEntities();
    public List<CartViewModel> GetCartDetails(string username)
    {
      try
      {
        List<CartViewModel> cartList = new List<CartViewModel>();
        var ListOfProductsForCartPage = (from u in db.Users.Where(f => f.Username == username)
                                         join c in db.Carts.Where(g => g.CartStatus_ID == 45004) on u.User_ID equals c.User_ID
                                         join cs in db.CartStatus on c.CartStatus_ID equals cs.CartStatus_ID
                                         join item in db.Items on c.Cart_ID equals item.Cart_ID
                                         join i in db.Inventories on item.Commodity_ID equals i.Commodity_ID
                                         join p in db.Products.Where(e => e.IsDeleted == false) on i.Product_ID equals p.Product_ID

                                         select new
                                         {
                                           c.User_ID,
                                           c.Cart_ID,
                                           c.Date,
                                           item.Commodity_ID,
                                           item.Quantity,
                                           i.Price,
                                           cs.Description,
                                           i.Stock,
                                           c.CartStatus_ID,
                                           p.ProductName,
                                           p.Brand,
                                           p.Color,
                                           p.Variance,
                                           u.Username
                                         });
        foreach (var list in ListOfProductsForCartPage)
        {
          CartViewModel cartvm = new CartViewModel();
          cartvm.User_ID = list.User_ID;
          cartvm.Cart_ID = list.Cart_ID;
          cartvm.Commodity_ID = list.Commodity_ID;
          cartvm.Quantity = list.Quantity;
          cartvm.Price = list.Price;
          cartvm.CartStatus_ID = list.CartStatus_ID;
          cartvm.CartDescription = list.Description;
          cartvm.ProductName = list.ProductName;
          cartvm.Brand = list.Brand;
          cartvm.Variance = list.Variance;
          cartvm.Color = list.Color;
          cartvm.Total = list.Price * list.Quantity;
          cartvm.Username = list.Username;
          cartList.Add(cartvm);
        }
        return cartList;
      }

      catch(Exception e)
      {
        LogFile.WriteLog(e);
        return null;
      }
    }

    public List<UserViewModel> GetUserDetails(long id)
    {
      try
      {
        List<UserViewModel> userList = new List<UserViewModel>();
        var uList = (from u in db.Users.Where(f => f.User_ID==id && f.IsDeleted==false) join
                        c in db.Carts.Where(e=> e.CartStatus_ID == 45004) on u.User_ID equals c.User_ID 

                        select new
                        {
                          u.User_ID,
                          u.FirstName,
                          u.LastName,
                          u.Email,
                          u.Username,
                          u.Password,
                          u.DefaultContact,
                          u.Role,
                          c.Cart_ID
                        });

        foreach(var list in uList)
        {
          UserViewModel user = new UserViewModel();
          user.User_ID = list.User_ID;
          user.FirstName = list.FirstName;
          user.LastName = list.LastName;
          user.Email = list.Email;
          user.Username = list.Username;
          user.Password = list.Password;
          user.DefaultContact = list.DefaultContact;
          user.Role = list.Role;
          user.Cart_ID = list.Cart_ID;
          userList.Add(user);
        }

        return userList;
      }

      catch (Exception e)
      {
        LogFile.WriteLog(e);
        return null;
      }
    }

    public List<OrdersViewModel> GetOrderDetails(long cartid)
    {
      try
      {
        List<OrdersViewModel> ordersList = new List<OrdersViewModel>();
        var oList = (from o in db.Orders join
        c in db.Carts.Where(e => e.Cart_ID == cartid) on o.Cart_ID equals c.Cart_ID join
        i in db.Items on c.Cart_ID equals i.Cart_ID join
        inv in db.Inventories on i.Commodity_ID equals inv.Commodity_ID join
        pr in db.Products on inv.Product_ID equals pr.Product_ID join
        u in db.Users on o.User_ID equals u.User_ID join
        s in db.Shipments on o.Shipment_ID equals s.Shipment_ID join
        p in db.Payments on o.Payment_ID equals p.Payment_ID join
        pm in db.PaymentModes on p.PaymentMode_ID equals pm.PaymentMode_ID

                          select new
                          {
                            o.Orders_ID,
                            o.User_ID,
                            o.Date,
                            o.Shipment_ID,
                            o.Payment_ID,
                            c.Cart_ID,
                            i.Items_ID,
                            i.Commodity_ID,
                            i.Amount,
                            i.Quantity,
                            pr.ProductName,
                            pr.Brand,
                            pr.Variance,
                            pr.Color,
                            u.FirstName,
                            u.LastName,
                            s.AgentName,
                            pm.Mode

                          });

        foreach (var list in oList)
        {
          OrdersViewModel ovm = new OrdersViewModel();
          ovm.Cart_ID = list.Cart_ID;
          ovm.Orders_ID = list.Orders_ID;
          ovm.User_ID = list.User_ID;
          ovm.ShipmentAgent = list.AgentName;
          ovm.PaymentMode = list.Mode;
          ovm.Payment_ID = list.Payment_ID;
          ovm.Items_ID = list.Items_ID;
          ovm.Commodity_ID = list.Commodity_ID;
          ovm.Price = (decimal)list.Amount;
          ovm.Quantity = list.Quantity;
          ovm.ProductName = list.ProductName;
          ovm.Brand = list.Brand;
          ovm.Color = list.Color;
          ovm.Variance = list.Variance;
          ordersList.Add(ovm);
        }

        return ordersList;
      }

      catch (Exception e)
      {
        LogFile.WriteLog(e);
        return null;
      }
    }

    public List<InvoiceViewModel> GetInvoiceDetails(long id)
    {
      try
      {
        List<InvoiceViewModel> invoiceList = new List<InvoiceViewModel>();
        var iList = (from inv in db.Invoices.Where(e => e.Orders_ID == id) join
                           o in db.Orders on inv.Orders_ID equals o.Orders_ID join
                           c in db.Carts on o.Cart_ID equals c.Cart_ID join
                           i in db.Items on c.Cart_ID equals i.Cart_ID join
                           u in db.Users on o.User_ID equals u.User_ID join
                           s in db.Shipments on o.Shipment_ID equals s.Shipment_ID join
                           p in db.Payments on o.Payment_ID equals p.Payment_ID join
                           pm in db.PaymentModes on p.PaymentMode_ID equals pm.PaymentMode_ID 
                           
                
                          select new
                          {
                            o.Orders_ID, o.User_ID, o.Date, o.DeliveryDate, o.Payment_ID, c.Cart_ID, i.Items_ID, i.Commodity_ID,
                            i.Amount, i.Quantity, Name = (u.FirstName + " " + u.LastName), s.AgentName, pm.Mode, p.Paid,
                            inv.Invoice_Number, 
                          });

        
        foreach (var list in iList)
        {
          InvoiceViewModel ivm = new InvoiceViewModel();
          ivm.Cart_ID = list.Cart_ID;
          ivm.Orders_ID = list.Orders_ID;
          ivm.User_ID = list.User_ID;
          ivm.DeliveryAgentName = list.AgentName;
          ivm.PaymentMode = list.Mode;
          ivm.Payment_ID = list.Payment_ID;
          ivm.Items_ID = list.Items_ID;
          ivm.Commodity_ID = list.Commodity_ID;
          ivm.Amount = (decimal)list.Amount;
          ivm.Quantity = list.Quantity;
          ivm.Name = list.Name;
          ivm.InvoiceNumber = list.Invoice_Number;
          ivm.DeliveryDate = (DateTime)list.DeliveryDate;
          ivm.OrdersDate = (DateTime)list.Date;
          ivm.Paid = list.Paid;
          invoiceList.Add(ivm);
        }

        return invoiceList;
      }

      catch (Exception e)
      {
        LogFile.WriteLog(e);
        return null;
      }
    }

    public List<ProductViewModel> GetProductsForHomePage()
    {
      try
      {
        List<ProductViewModel> productList = new List<ProductViewModel>();
        var ListOfProductsForProductPage = (from i in db.Inventories
                                            join p in db.Products on i.Product_ID equals p.Product_ID
                                            join s in db.Sellers on i.Seller_ID equals s.Seller_ID
                                            join c in db.Categories on p.Category_ID equals c.Category_ID
                  
                                            select new
                                    {
                                      p.Product_ID, p.ProductName, p.Image, p.Brand, p.Color, p.Variance, s.SellerName, 
                                      i.Commodity_ID, i.Price, i.Stock, c.CategoryName
                                    });
        foreach (var list in ListOfProductsForProductPage)
        {
          ProductViewModel productvm = new ProductViewModel();
          productvm.Product_ID = list.Product_ID;
          productvm.ProductName = list.ProductName;
          productvm.Image = list.Image;
          productvm.Brand = list.Brand;
          productvm.Color = list.Color;
          productvm.Variance = list.Variance;
          productvm.SellerName = list.SellerName;
          productvm.Commodity_ID = list.Commodity_ID;
          productvm.Price = list.Price;
          productvm.Stock = list.Stock;
          productvm.CategoryName = list.CategoryName;
          productList.Add(productvm);
        }

        return productList;
      }

      catch (Exception e)
      {
        LogFile.WriteLog(e);
        return null;
      }
    }

    public List<ProductViewModel> GetProductsForEachCategory(Category category)
    {
      try
      {
        List<ProductViewModel> productList = new List<ProductViewModel>();
        var pList = (from p in db.Products.Where(f => f.IsDeleted == false) join
                   c in db.Categories.Where(e => e.Category_ID == category.Category_ID) on p.Category_ID equals c.Category_ID join
                     i in db.Inventories on p.Product_ID equals i.Product_ID join
                     s in db.Sellers on i.Seller_ID equals s.Seller_ID

                   select new
                   {
                     p.Product_ID,
                     p.Category_ID,
                     p.Color,
                     p.Description,
                     p.IsDeleted,
                     p.ReorderQuantity,
                     p.Variance,
                     p.ProductName,
                     p.Image,
                     p.Brand,
                     i.Price,
                     c.CategoryName,
                     s.SellerName,
                     i.Commodity_ID,
                     i.Stock
                   });

        foreach (var list in pList)
        {
          ProductViewModel productvm = new ProductViewModel();
          productvm.Product_ID = list.Product_ID;
          productvm.ProductName = list.ProductName;
          productvm.Image = list.Image;
          productvm.Brand = list.Brand;
          productvm.CategoryName = list.CategoryName;
          productvm.Color = list.Color;
          productvm.Commodity_ID = list.Commodity_ID;
          productvm.Description = list.Description;
          productvm.Price = list.Price;
          productvm.SellerName = list.SellerName;
          productvm.Stock = list.Stock;
          productvm.isDeleted = list.IsDeleted;
          productvm.Category_ID = list.Category_ID;
          productvm.Variance = list.Variance;
          productvm.ReorderQuantity = list.ReorderQuantity;
          productList.Add(productvm);
        }

        return productList.ToList();
      }

      catch (Exception e)
      {
        LogFile.WriteLog(e);
        return null;
      }
    }

  }
}