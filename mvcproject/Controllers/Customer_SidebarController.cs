using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.AspNetCore.Http;
using mvcproject.Models;

namespace mvcproject.Controllers
{
    public class Customer_SidebarController : Controller
    {
        public IActionResult Index(string id)
        {
            ViewData["ProductManu"] = DataStore.Instance.Get(DataStore.MANUFACTURER);

            ViewBag.ProductOffer = DataStore.Instance.Get(DataStore.PRODUCT_OFFER);

            ViewData["ProductCategory"] = DataStore.Instance.Get(DataStore.PRODUCT_CATEGORY);

            ViewBag.ListProducts = DataStore.Instance.Get(DataStore.PRODUCT);

            ViewData["email"] = DataStore.Instance.Get_Session(HttpContext.Session.GetString("email"));

            if(HttpContext.Session.GetString("email")!= "")
            {
                Customer _c = new Customer();

                StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;

                _c = context.Get_C_Order(id);

                ViewBag.Customer = _c;

                ViewData["email"] = DataStore.Instance.Get_Session(HttpContext.Session.GetString("email"));
            }

            return View();
        }
    }
}
