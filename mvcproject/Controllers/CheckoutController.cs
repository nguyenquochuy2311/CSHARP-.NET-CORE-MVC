using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using mvcproject.Models;
using System.Web;
using Microsoft.AspNetCore.Http;
using System.Collections.Specialized;

namespace mvcproject.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            ViewData["ProductManu"] = DataStore.Instance.Get(DataStore.MANUFACTURER);

            ViewBag.ProductOffer = DataStore.Instance.Get(DataStore.PRODUCT_OFFER);

            ViewData["ProductCategory"] = DataStore.Instance.Get(DataStore.PRODUCT_CATEGORY);

            //ViewBag.ListProducts = DataStore.Instance.Get(DataStore.PRODUCT);

            //ViewData["email"] = DataStore.Instance.Get_Session(HttpContext.Session.GetString("email"));

            StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;

            ViewData["count_cart"] = context.Count_Cart();

            ViewData["items_cart"] = context.GetProduct_Cart();

            ViewData["sum_money"] = context.Sum_Cart();

            if (HttpContext.Session.GetString("email") != null)
            {
                ViewData["email"] = DataStore.Instance.Get_Session(HttpContext.Session.GetString("email"));

                if (HttpContext.Session.GetInt32("chk_order") == 0)
                {
                    HttpContext.Session.Remove("chk_order");
                    ViewData["chk_order"] = "Dat hang loi";
                }

                return View();
            }     
            else
            {
                ViewData["email"] = DataStore.Instance.Get_Session(DataStore.GET_EMAIL);

                return Redirect("/Login/Index");
            }
                
        }
        public IActionResult Confirm_Order()
        {
            ViewData["ProductManu"] = DataStore.Instance.Get(DataStore.MANUFACTURER);

            ViewBag.ProductOffer = DataStore.Instance.Get(DataStore.PRODUCT_OFFER);

            ViewData["ProductCategory"] = DataStore.Instance.Get(DataStore.PRODUCT_CATEGORY);

            //ViewBag.ListProducts = DataStore.Instance.Get(DataStore.PRODUCT);

            //ViewData["email"] = DataStore.Instance.Get_Session(HttpContext.Session.GetString("email"));

            StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;

            ViewData["count_cart"] = context.Count_Cart();

            int count_pcart= context.Count_Cart();

            ViewData["items_cart"] = context.GetProduct_Cart();

            List<CartItem> ci = context.GetProduct_Cart();

            ViewData["sum_money"] = context.Sum_Cart();

            if (HttpContext.Session.GetString("email") != null)
            {
                ViewData["email"] = DataStore.Instance.Get_Session(HttpContext.Session.GetString("email"));

                int add_order = context.Add_C_P_Order(context.GetID_Customer(HttpContext.Session.GetString("email")), ci);

                if (add_order == count_pcart)
                {
                    if(context.Delete_Item_Order()!=0)
                    {
                        ViewData["count_cart"] = 0;

                        //ViewData["items_cart"] = context.GetProduct_Cart();

                        ViewData["sum_money"] = 0;

                        HttpContext.Session.SetInt32("chk_order", 1);

                        return Redirect("/Home/Index");
                    }
                    else
                    {
                        HttpContext.Session.SetInt32("chk_order", 0);

                        return Redirect("/Checkout/Index");
                    }
                }
                else
                {
                    //ViewData["chk_order"] = 0;

                    HttpContext.Session.SetInt32("chk_order", 0);

                    return Redirect("/Checkout/Index");
                }
            }
            else
            {
                ViewData["email"] = DataStore.Instance.Get_Session(DataStore.GET_EMAIL);

                return Redirect("/Login/Index");
            }
        }
    }
}
