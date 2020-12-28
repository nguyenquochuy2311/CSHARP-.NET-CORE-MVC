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

            //ViewData["email"] = DataStore.Instance.Get_Session(HttpContext.Session.GetString("email"));

            StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;

            if (HttpContext.Session.GetString("email") != null)
            {
                ViewData["email"] = DataStore.Instance.Get_Session(HttpContext.Session.GetString("email"));   
            }   
            else
                ViewData["email"] = DataStore.Instance.Get_Session(DataStore.GET_EMAIL);

            ViewData["count_cart"] = context.Count_Cart();

            ViewData["items_cart"] = context.GetProduct_Cart();

            ViewData["sum_money"] = context.Sum_Cart();

            return View();
        }
        
        public IActionResult AddToCart(Cart c)
        {
            ViewData["ProductManu"] = DataStore.Instance.Get(DataStore.MANUFACTURER);

            ViewBag.ProductOffer = DataStore.Instance.Get(DataStore.PRODUCT_OFFER);

            ViewData["ProductCategory"] = DataStore.Instance.Get(DataStore.PRODUCT_CATEGORY);

            ViewData["email"] = DataStore.Instance.Get_Session(HttpContext.Session.GetString("email"));

            StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;

            if (HttpContext.Session.GetString("email") != null) 
                ViewData["email"] = DataStore.Instance.Get_Session(HttpContext.Session.GetString("email"));
            else
            {
                ViewData["email"] = DataStore.Instance.Get_Session(DataStore.GET_EMAIL);
            }

            Product _d = context.GetProducts_Detail(c.Product_id.ToString());

            int add_cart = 0;
            int check_cart = 0;
            if (_d != null)
            {
                c.Ip_add = "::1";
                check_cart = context.Check_Cart(c.Product_id);
                if(check_cart == 0)
                {
                    add_cart = context.Add_Cart(c);
                    if (add_cart != 0)
                    {
                        HttpContext.Session.SetInt32("check_addcart", 1);
                    }
                }
                else
                {
                    HttpContext.Session.SetInt32("check_addcart", 0);
                }
            }
            ViewData["sum_money"] = context.Sum_Cart();

            ViewData["count_cart"] = context.Count_Cart();

            return RedirectToAction("Index","Detail",new { @pro_id = c.Product_id });
        }
        public IActionResult Delete_Item(string pro_id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;

            ViewData["ProductManu"] = DataStore.Instance.Get(DataStore.MANUFACTURER);

            ViewBag.ProductOffer = DataStore.Instance.Get(DataStore.PRODUCT_OFFER);

            ViewData["ProductCategory"] = DataStore.Instance.Get(DataStore.PRODUCT_CATEGORY);

            if (HttpContext.Session.GetString("email") != null)
            {
                ViewData["email"] = DataStore.Instance.Get_Session(HttpContext.Session.GetString("email"));
            }
            else
            {
                ViewData["email"] = DataStore.Instance.Get_Session(DataStore.GET_EMAIL);
            }

            if (context.Delete_Item(pro_id)!=0)
            {
                ViewData["sum_money"] = context.Sum_Cart();

                ViewData["count_cart"] = context.Count_Cart();

                ViewData["items_cart"] = context.GetProduct_Cart();

                return Redirect("/Cart/Index");
            }
            ViewData["sum_money"] = context.Sum_Cart();

            ViewData["count_cart"] = context.Count_Cart();

            ViewData["items_cart"] = context.GetProduct_Cart();

            ViewData["Found_delete"] = "Loi khi xoa san pham";

            return View();
        }
        public IActionResult Update_Qty(string pro_id,int qty)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;

            ViewData["ProductManu"] = DataStore.Instance.Get(DataStore.MANUFACTURER);

            ViewBag.ProductOffer = DataStore.Instance.Get(DataStore.PRODUCT_OFFER);

            ViewData["ProductCategory"] = DataStore.Instance.Get(DataStore.PRODUCT_CATEGORY);

            if (HttpContext.Session.GetString("email") != null)
            {
                ViewData["email"] = DataStore.Instance.Get_Session(HttpContext.Session.GetString("email"));
            }
            else
            {
                ViewData["email"] = DataStore.Instance.Get_Session(DataStore.GET_EMAIL);
            }

            if (context.Update_Qty(pro_id,qty) != 0)
            {
                ViewData["sum_money"] = context.Sum_Cart();

                ViewData["count_cart"] = context.Count_Cart();

                ViewData["items_cart"] = context.GetProduct_Cart();

                return Redirect("/Cart/Index");
            }
            ViewData["sum_money"] = context.Sum_Cart();

            ViewData["count_cart"] = context.Count_Cart();

            ViewData["items_cart"] = context.GetProduct_Cart();

            ViewData["Found_update"] = "Loi khi update so luong san pham";

            return View();
        }
    }
}
