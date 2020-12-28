using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mvcproject.Models;
using MySql.Data.MySqlClient;
using System.Web;


namespace mvcproject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.ListSliders1 = DataStore.Instance.Get(DataStore.SLIDER1);

            ViewBag.ListSLiders = DataStore.Instance.Get(DataStore.SLIDER);

            ViewBag.ListBoxes = DataStore.Instance.Get(DataStore.BOX);

            ViewData["ProductManu"] = DataStore.Instance.Get(DataStore.MANUFACTURER);

            //ViewBag.ProductOffer = DataStore.Instance.Get(DataStore.PRODUCT_OFFER);

            ViewData["ProductCategory"] = DataStore.Instance.Get(DataStore.PRODUCT_CATEGORY);

            ViewBag.ListProducts = DataStore.Instance.Get(DataStore.PRODUCT);

            StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;

            ViewData["count_cart"] = context.Count_Cart();

            ViewData["sum_money"] = context.Sum_Cart();

            if (HttpContext.Session.GetString("email") != null)
            {
                ViewData["email"] = DataStore.Instance.Get_Session(HttpContext.Session.GetString("email"));
                if (HttpContext.Session.GetInt32("chk_login") == 1)
                {
                    HttpContext.Session.Remove("chk_login");
                    ViewData["chk_login"] = "Dang nhap thanh cong";
                }
                if(HttpContext.Session.GetInt32("chk_order")==1)
                {
                    HttpContext.Session.Remove("chk_order");
                    ViewData["chk_order"] = "Don dat hang da duoc gui di, xin cam on";
                }
                return View();
            }           
            else
            {
                ViewData["email"] = DataStore.Instance.Get_Session(DataStore.GET_EMAIL);
            }           

            return View();

        }
    }
}
