using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mvcproject.Models;

namespace mvcproject.Controllers
{
    public class MyAccountController : Controller
    {
        public IActionResult Index()
        {
            ViewData["ProductManu"] = DataStore.Instance.Get(DataStore.MANUFACTURER);

            ViewBag.ProductOffer = DataStore.Instance.Get(DataStore.PRODUCT_OFFER);

            ViewData["ProductCategory"] = DataStore.Instance.Get(DataStore.PRODUCT_CATEGORY);

            ViewBag.ListProducts = DataStore.Instance.Get(DataStore.PRODUCT);

            StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;

            ViewData["count_cart"] = context.Count_Cart();

            ViewData["sum_money"] = context.Sum_Cart();

            if (HttpContext.Session.GetString("email")!= null)
            {
                Customer _c = new Customer();

                _c = context.Get_C_Order(HttpContext.Session.GetString("email").ToString());

                ViewBag.Customer = _c;

                ViewData["email"] = DataStore.Instance.Get_Session(HttpContext.Session.GetString("email"));

                Customer customer = new Customer();
                string customer_email = ViewData["email"].ToString();
                customer = context.Get_C_Order(customer_email);
                ViewBag.Customer = customer;

                List<MyOrder> myorder = context.Get_Order(customer.Customer_id.ToString());
                ViewBag.MyOrder = myorder;

                return View();
            }
            else
            {
                ViewData["email"] = DataStore.Instance.Get_Session(DataStore.GET_EMAIL);

                return Redirect("/Login/Index");
            }

        }
        public IActionResult SidebarAccount()
        {
            return View();
        }
        public IActionResult MyOrder()
        {
            if (HttpContext.Session.GetString("email") != null)
                ViewData["email"] = DataStore.Instance.Get_Session(HttpContext.Session.GetString("email"));
            else
                ViewData["email"] = DataStore.Instance.Get_Session(DataStore.GET_EMAIL);
            StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;
            ViewData["ProductCategory"] = context.GetP_cates();

            ViewData["count_cart"] = context.Count_Cart();

            ViewData["sum_money"] = context.Sum_Cart();

            //Get mot customer de truyen data cho sidebar
            Customer customer = new Customer();
            string customer_email = ViewData["email"].ToString();
            customer = context.Get_C_Order(customer_email);
            ViewBag.Customer = customer;

            List<MyOrder> myorder = context.Get_Order(customer.Customer_id.ToString());
            ViewBag.MyOrder = myorder;

            return View();
        }
        public IActionResult OfflinePayment()
        {
            if (HttpContext.Session.GetString("email") != null)
                ViewData["email"] = DataStore.Instance.Get_Session(HttpContext.Session.GetString("email"));
            else
                ViewData["email"] = DataStore.Instance.Get_Session(DataStore.GET_EMAIL);

            StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;
            ViewData["ProductCategory"] = context.GetP_cates();

            ViewData["count_cart"] = context.Count_Cart();

            ViewData["sum_money"] = context.Sum_Cart();

            //Get mot customer de truyen data cho sidebar
            Customer customer = new Customer();
            string customer_email = ViewData["email"].ToString();
            customer = context.Get_C_Order(customer_email);
            ViewBag.Customer = customer;

            List<MyOrder> myorder = context.Get_Order(customer.Customer_id.ToString());
            ViewBag.MyOrder = myorder;

            return View();
        }
        public IActionResult EditInformation()
        {
            if (HttpContext.Session.GetString("email") != null)
                ViewData["email"] = DataStore.Instance.Get_Session(HttpContext.Session.GetString("email"));
            else
                ViewData["email"] = DataStore.Instance.Get_Session(DataStore.GET_EMAIL);

            StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;
            ViewData["ProductCategory"] = context.GetP_cates();

            ViewData["count_cart"] = context.Count_Cart();

            ViewData["sum_money"] = context.Sum_Cart();

            //Get mot customer de truyen data cho sidebar
            Customer customer = new Customer();
            string customer_email = ViewData["email"].ToString();
            customer = context.Get_C_Order(customer_email);
            ViewBag.Customer = customer;

            List<MyOrder> myorder = context.Get_Order(customer.Customer_id.ToString());
            ViewBag.MyOrder = myorder;

            return View();
        }
        public IActionResult EditInformation_Send(Customer customer)
        {
            if (HttpContext.Session.GetString("email") != null)
                ViewData["email"] = DataStore.Instance.Get_Session(HttpContext.Session.GetString("email"));
            else
                ViewData["email"] = DataStore.Instance.Get_Session(DataStore.GET_EMAIL);

            StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;
            ViewData["ProductCategory"] = context.GetP_cates();

            ViewData["count_cart"] = context.Count_Cart();

            ViewData["sum_money"] = context.Sum_Cart();

            string customer_email = ViewData["email"].ToString();
            customer = context.Get_C_Order(customer_email);
            ViewBag.Customer = customer;

            List<MyOrder> myorder = context.Get_Order(customer.Customer_id.ToString());
            ViewBag.MyOrder = myorder;

            //Get mot customer de truyen data cho sidebar
            if (context.Update_Customer(customer))
            {
                ViewBag.Customer = customer;
                ViewBag.Noti = 1;
            }
            else
            {
                ViewBag.Noti = 0;
            }
            return Redirect("/MyAccount/EditInformation");
        }
        public IActionResult ChangePassword()
        {
            if (HttpContext.Session.GetString("email") != null)
                ViewData["email"] = DataStore.Instance.Get_Session(HttpContext.Session.GetString("email"));
            else
                ViewData["email"] = DataStore.Instance.Get_Session(DataStore.GET_EMAIL);
            StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;
            ViewData["ProductCategory"] = context.GetP_cates();

            ViewData["count_cart"] = context.Count_Cart();

            ViewData["sum_money"] = context.Sum_Cart();

            //Get mot customer de truyen data cho sidebar
            Customer customer = new Customer();
            string customer_email = ViewData["email"].ToString();
            customer = context.Get_C_Order(customer_email);
            ViewBag.Customer = customer;

            List<MyOrder> myorder = context.Get_Order(customer.Customer_id.ToString());
            ViewBag.MyOrder = myorder;

            return View();
        }
        public IActionResult Confirm_ChangePassword(Customer c, string new_pass, string new_pass_again)
        {
            if (HttpContext.Session.GetString("email") != null)
                ViewData["email"] = DataStore.Instance.Get_Session(HttpContext.Session.GetString("email"));
            else
                ViewData["email"] = DataStore.Instance.Get_Session(DataStore.GET_EMAIL);
            StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;
            ViewData["ProductCategory"] = context.GetP_cates();

            ViewData["count_cart"] = context.Count_Cart();

            ViewData["sum_money"] = context.Sum_Cart();

            //Get mot customer de truyen data cho sidebar
            Customer customer = new Customer();
            string customer_email = ViewData["email"].ToString();
            customer = context.Get_C_Order(customer_email);
            ViewBag.Customer = customer;

            List<MyOrder> myorder = context.Get_Order(customer.Customer_id.ToString());
            ViewBag.MyOrder = myorder;
            bool check_pass = context.Check_pass(customer_email, c.Customer_pass);

            if (check_pass && (new_pass == new_pass_again))
            {
                bool update_pass = context.Update_Pass(customer_email, new_pass);
                if (update_pass)
                {
                    ViewData["Confirm_ChangePassword"] = 1;
                }
            }
            else ViewData["Confirm_ChangePassword"] = 0;

            return Redirect("/MyAccount/MyOrder");
        }
        public IActionResult DeleteAccount()
        {
            if (HttpContext.Session.GetString("email") != null)
                ViewData["email"] = DataStore.Instance.Get_Session(HttpContext.Session.GetString("email"));
            else
                ViewData["email"] = DataStore.Instance.Get_Session(DataStore.GET_EMAIL);
            StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;
            ViewData["ProductCategory"] = context.GetP_cates();

            ViewData["count_cart"] = context.Count_Cart();

            ViewData["sum_money"] = context.Sum_Cart();

            //Get mot customer de truyen data cho sidebar
            Customer customer = new Customer();
            string customer_email = ViewData["email"].ToString();
            customer = context.Get_C_Order(customer_email);
            ViewBag.Customer = customer;

            List<MyOrder> myorder = context.Get_Order(customer.Customer_id.ToString());
            ViewBag.MyOrder = myorder;

            if (context.Delete_Customer(customer_email))
            {
                return Redirect("/MyAccount/Logout");
            }
            else return Redirect("/MyAccount/MyOrder");
        }
        public IActionResult MyOrder_Confirm(int order_id)
        {
            if (HttpContext.Session.GetString("email") != null)
                ViewData["email"] = DataStore.Instance.Get_Session(HttpContext.Session.GetString("email"));
            else
                ViewData["email"] = DataStore.Instance.Get_Session(DataStore.GET_EMAIL);
            StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;
            ViewData["ProductCategory"] = context.GetP_cates();

            ViewData["count_cart"] = context.Count_Cart();

            ViewData["sum_money"] = context.Sum_Cart();

            //Get mot customer de truyen data cho sidebar
            Customer customer = new Customer();
            string customer_email = ViewData["email"].ToString();
            customer = context.Get_C_Order(customer_email);
            ViewBag.Customer = customer;

            List<MyOrder> myorder = context.Get_Order(customer.Customer_id.ToString());
            ViewBag.MyOrder = myorder;

            return View();
        }

        public IActionResult MyOrder_Confirm_Send(int order_id, Payments payments)
        {
            if (HttpContext.Session.GetString("email") != null)
                ViewData["email"] = DataStore.Instance.Get_Session(HttpContext.Session.GetString("email"));
            else
                ViewData["email"] = DataStore.Instance.Get_Session(DataStore.GET_EMAIL);
            StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;
            ViewData["ProductCategory"] = context.GetP_cates();

            ViewData["count_cart"] = context.Count_Cart();

            ViewData["sum_money"] = context.Sum_Cart();

            //Get mot customer de truyen data cho sidebar
            Customer customer = new Customer();
            string customer_email = ViewData["email"].ToString();
            customer = context.Get_C_Order(customer_email);
            ViewBag.Customer = customer;

            List<MyOrder> myorder = context.Get_Order(customer.Customer_id.ToString());
            ViewBag.MyOrder = myorder;

            bool add = context.Add_Payment(payments);
            if (add)
            {
                bool update = context.Update_Customer_Order_Completed(order_id);
                if (update)
                {
                    bool delete = context.Delete_Pending_Order(payments.Invoice_no);
                    if (delete)
                    {
                        ViewData["MyOrder_Confirm_Send"] = 1;
                    }
                }
            }
            else ViewData["MyOrder_Confirm_Send"] = 0;

            return Redirect("/MyAccount/MyOrder");
        }
    }
}
