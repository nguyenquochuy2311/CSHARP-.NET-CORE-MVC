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


            if (HttpContext.Session.GetString("email")!= null)
            {
                Customer _c = new Customer();

                StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;

                _c = context.Get_C_Order(HttpContext.Session.GetString("email").ToString());

                ViewBag.Customer = _c;

                ViewData["email"] = DataStore.Instance.Get_Session(HttpContext.Session.GetString("email"));

                return View();
            }
            else
            {
                ViewData["email"] = DataStore.Instance.Get_Session(DataStore.GET_EMAIL);

                HttpContext.Session.SetString("email", "");

                return Redirect("/Login/Index");
            }


        }
    }
}
