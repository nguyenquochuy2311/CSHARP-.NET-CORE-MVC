using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvcproject.Models;
using mvcproject.Utilities;
using MySql.Data.MySqlClient;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace mvcproject.Controllers
{
    public class LogoutController : Controller
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

            HttpContext.Session.SetString("email", "");

            ViewData["email"] = DataStore.Instance.Get_Session(DataStore.GET_EMAIL);

            return Redirect("/Home/Index");
        }
    }
}
