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
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            ViewData["ProductManu"] = DataStore.Instance.Get(DataStore.MANUFACTURER);

            ViewBag.ProductOffer = DataStore.Instance.Get(DataStore.PRODUCT_OFFER);

            ViewData["ProductCategory"] = DataStore.Instance.Get(DataStore.PRODUCT_CATEGORY);

            ViewBag.ListProducts = DataStore.Instance.Get(DataStore.PRODUCT);

            StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;

            if (HttpContext.Session.GetString("email") != null)
                ViewData["email"] = DataStore.Instance.Get_Session(HttpContext.Session.GetString("email"));
            else
                ViewData["email"] = DataStore.Instance.Get_Session(DataStore.GET_EMAIL);

            ViewData["count_cart"] = context.Count_Cart();

            ViewData["sum_money"] = context.Sum_Cart();

            return View();
        }
    }
}
