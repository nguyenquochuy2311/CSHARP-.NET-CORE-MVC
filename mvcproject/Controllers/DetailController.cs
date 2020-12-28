using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvcproject.Models;
using System.Dynamic;
using MySql.Data.MySqlClient;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace mvcproject.Controllers
{
    public class DetailController : Controller
    {
        public IActionResult Index(string pro_id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;

            Product _p = context.GetProducts_Detail(pro_id);

            ViewData["Product_Detail"] = _p;

            ViewData["ProductManu"]= DataStore.Instance.Get(DataStore.MANUFACTURER);

            ViewData["ProductCategory"] = DataStore.Instance.Get(DataStore.PRODUCT_CATEGORY);

            ViewBag.ListProducts = DataStore.Instance.Get(DataStore.PRODUCT);

            ViewBag.ProductOffer = DataStore.Instance.Get(DataStore.PRODUCT_OFFER);

            if (HttpContext.Session.GetString("email") != null)
                ViewData["email"] = DataStore.Instance.Get_Session(HttpContext.Session.GetString("email"));
            else
                ViewData["email"] = DataStore.Instance.Get_Session(DataStore.GET_EMAIL);

            if(HttpContext.Session.GetInt32("check_addcart")!=null)
            {
                if (HttpContext.Session.GetInt32("check_addcart") == 1)
                {
                    ViewData["check_addcart"] = 1;
                }
                else
                {
                    ViewData["check_addcart"] = 0;
                }
                HttpContext.Session.Remove("check_addcart");
            }

            ViewData["count_cart"] = context.Count_Cart();

            ViewData["sum_money"] = context.Sum_Cart();

            return View();
        }
    }
}
