using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mvcproject.Models;
using mvcproject.Areas.Admin.Models;
using mvcproject.Utilities;
using System.Dynamic;

namespace mvcproject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class Admin_LoginController : Controller
    {
        public IActionResult Index()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;
            if (HttpContext.Session.GetInt32("chk_login") !=null)
            {
                HttpContext.Session.Remove("chk_login");
                ViewData["chk_login"] = 0;
            }
            if(HttpContext.Session.GetString("email")!=null)
            {
                string email = HttpContext.Session.GetString("email");
                ViewData["admin"] = context.Get_Admin(email);
                ViewData["count_product"] = context.GetProducts().Count();
                ViewData["count_customer"] = context.GetCustomers().Count();
                ViewData["count_p_cat"] = context.GetP_cates().Count();
                ViewData["count_pending_order"] = context.Get_PedingOrder().Count();
                ViewData["pending_order"] = context.Get_PedingOrder();
            }
            return View();
        }
        public IActionResult Check_Login(mvcproject.Areas.Admin.Models.Admin ad)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;
            if(context.Check_AdLogin(ad.Admin_email,ad.Admin_pass)!=0)
            {
                HttpContext.Session.SetString("email", ad.Admin_email.ToString());
                ViewData["admin"] = context.Get_Admin(ad.Admin_email);
                ViewData["count_product"] = context.GetProducts().Count();
                ViewData["count_customer"] = context.GetCustomers().Count();
                ViewData["count_p_cat"] = context.GetP_cates().Count();
                ViewData["count_pending_order"] = context.Get_PedingOrder().Count();
                ViewData["pending_order"] = context.Get_PedingOrder();
                return Redirect("/Admin/Admin/Index");
            }
            else
            {
                HttpContext.Session.SetInt32("chk_login", 0);
                return Redirect("/Admin/Admin_Login/Index");
            }
        }
    }
}
