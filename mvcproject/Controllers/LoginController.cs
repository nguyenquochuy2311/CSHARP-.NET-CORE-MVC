using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mvcproject.Models;
using mvcproject.Utilities;
using MySql.Data.MySqlClient;
using System.Web;

namespace mvcproject.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ListSliders1 = DataStore.Instance.Get(DataStore.SLIDER1);

            ViewBag.ListSLiders = DataStore.Instance.Get(DataStore.SLIDER);

            ViewBag.ListBoxes = DataStore.Instance.Get(DataStore.BOX);

            ViewData["ProductManu"] = DataStore.Instance.Get(DataStore.MANUFACTURER);

            ViewBag.ProductOffer = DataStore.Instance.Get(DataStore.PRODUCT_OFFER);

            ViewData["ProductCategory"] = DataStore.Instance.Get(DataStore.PRODUCT_CATEGORY);

            ViewBag.ListProducts = DataStore.Instance.Get(DataStore.PRODUCT);

            StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;

            ViewData["count_cart"] = context.Count_Cart();

            ViewData["sum_money"] = context.Sum_Cart();

            if (HttpContext.Session.GetString("email") != null)
            {
                ViewData["email"] = DataStore.Instance.Get_Session(HttpContext.Session.GetString("email"));              
            }
            else
            {
                ViewData["email"] = DataStore.Instance.Get_Session(DataStore.GET_EMAIL);
                if(HttpContext.Session.GetInt32("chk_login")==0)
                {
                    HttpContext.Session.Remove("chk_login");
                    ViewData["chk_login"] = "Email hoac mat khau khong dung";       
                }
                return View();
            }
            return View();     
        }
        public IActionResult Check(Customer c)
        {
            ViewBag.ListSliders1 = DataStore.Instance.Get(DataStore.SLIDER1);

            ViewBag.ListSLiders = DataStore.Instance.Get(DataStore.SLIDER);

            ViewBag.ListBoxes = DataStore.Instance.Get(DataStore.BOX);

            ViewData["ProductManu"] = DataStore.Instance.Get(DataStore.MANUFACTURER);

            ViewBag.ProductOffer = DataStore.Instance.Get(DataStore.PRODUCT_OFFER);

            ViewData["ProductCategory"] = DataStore.Instance.Get(DataStore.PRODUCT_CATEGORY);

            ViewBag.ListProducts = DataStore.Instance.Get(DataStore.PRODUCT);

            StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;

            ViewData["count_cart"] = context.Count_Cart();

            ViewData["sum_money"] = context.Sum_Cart();

            int count = context.Count_Customer(c.Customer_email, c.Customer_pass);

            if (count == 0)
            {
                HttpContext.Session.SetInt32("chk_login", 0);

                ViewData["email"] = DataStore.Instance.Get(DataStore.GET_EMAIL);

                return Redirect("/Login/Index");
            }
            else
            {
                Customer _c = context.GetCustomer_Login(c.Customer_email, c.Customer_pass);

                HttpContext.Session.SetInt32("chk_login", 1);

                HttpContext.Session.SetString("email", c.Customer_email.ToString());

                ViewData["email"] = DataStore.Instance.Get_Session(c.Customer_email.ToString());

                return Redirect("/Home/Index");
            }

            
        }
    }
}
