using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using mvcproject.Models;
using System.Web;
using Microsoft.AspNetCore.Http;
using System.Collections.Specialized;

namespace mvcproject.Controllers
{
    public class CartController : Controller
    {
        
        public IActionResult Index()
        {
            ViewData["ProductManu"] = DataStore.Instance.Get(DataStore.MANUFACTURER);

            ViewBag.ProductOffer = DataStore.Instance.Get(DataStore.PRODUCT_OFFER);

            ViewData["ProductCategory"] = DataStore.Instance.Get(DataStore.PRODUCT_CATEGORY);

            //ViewBag.ListProducts = DataStore.Instance.Get(DataStore.PRODUCT);

            ViewData["email"] = DataStore.Instance.Get_Session(HttpContext.Session.GetString("email"));

            return View();
        }
        List<Cart> list = new List<Cart>();
        
        public IActionResult AddToCart(Cart c)
        {
            ViewData["ProductManu"] = DataStore.Instance.Get(DataStore.MANUFACTURER);

            ViewBag.ProductOffer = DataStore.Instance.Get(DataStore.PRODUCT_OFFER);

            ViewData["ProductCategory"] = DataStore.Instance.Get(DataStore.PRODUCT_CATEGORY);

            ViewData["email"] = DataStore.Instance.Get_Session(HttpContext.Session.GetString("email"));

            StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;

            Product _d = context.GetProducts_Detail(c.Product_id.ToString());

            if (HttpContext.Session.GetString("email") != null) {
                ViewData["email"] = DataStore.Instance.Get_Session(HttpContext.Session.GetString("email"));
                if (_d != null)
                {
                    ViewData["chk_cart"] = 1;
                }
                else
                {
                    ViewData["chk_cart"] = 0;
                }
                
            }
            else
            {
                ViewData["email"] = DataStore.Instance.Get_Session(DataStore.GET_EMAIL);
                if (_d != null)
                {
                    ViewData["chk_cart"] = 1;
                }
                else
                {
                    ViewData["chk_cart"] = 0;
                }
            }

            //Cart _c = new Cart(d.Product_id, GetReadIpUser(), qty, size);
            /*int count = context.Add_Cart(_c);
            if (count > 0)
                ViewData["chk_cart"] = "Them vao gio hang thanh cong";*/

            return View();
        }

    }
}
