using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvcproject.Models;
using mvcproject.Utilities;
using MySql.Data.MySqlClient;

namespace mvcproject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;
            if (HttpContext.Session.GetInt32("chk_admin") !=null)
            {
                HttpContext.Session.Remove("chk_admin");
                ViewData["chk_login"] = 1;
            }
            if (HttpContext.Session.GetString("email") != null)
            {
                string email = HttpContext.Session.GetString("email");
                ViewData["admin"] = context.Get_Admin(email);
                ViewData["count_product"] = context.GetProducts().Count();
                ViewData["count_customer"] = context.GetCustomers().Count();
                ViewData["count_p_cat"] = context.GetP_cates().Count();
                ViewData["p_cat"] = context.GetP_cates();
                ViewData["cat"] = context.GetCates();
                ViewData["count_pending_order"] = context.Get_PedingOrder().Count();
                ViewData["pending_order"] = context.Get_PedingOrder();
                ViewData["get_manu"] = context.GetManu();
                ViewData["get_product"] = context.GetProducts();
            }
            return View();
        }
        public IActionResult Sidebar()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;
            if (HttpContext.Session.GetString("email") != null)
            {
                string email = HttpContext.Session.GetString("email");
                ViewData["admin"] = context.Get_Admin(email);
                ViewData["count_product"] = context.GetProducts().Count();
                ViewData["count_customer"] = context.GetCustomers().Count();
                ViewData["count_p_cat"] = context.GetP_cates().Count();
                ViewData["p_cat"] = context.GetP_cates();
                ViewData["cat"] = context.GetCates();
                ViewData["count_pending_order"] = context.Get_PedingOrder().Count();
                ViewData["pending_order"] = context.Get_PedingOrder();
                ViewData["get_manu"] = context.GetManu();
                ViewData["get_product"] = context.GetProducts();
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/Admin");
        }
        public IActionResult Add_Manu()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;
            if (HttpContext.Session.GetString("email") != null)
            {
                string email = HttpContext.Session.GetString("email");
                ViewData["admin"] = context.Get_Admin(email);
                ViewData["count_product"] = context.GetProducts().Count();
                ViewData["count_customer"] = context.GetCustomers().Count();
                ViewData["count_p_cat"] = context.GetP_cates().Count();
                ViewData["p_cat"] = context.GetP_cates();
                ViewData["cat"] = context.GetCates();
                ViewData["count_pending_order"] = context.Get_PedingOrder().Count();
                ViewData["pending_order"] = context.Get_PedingOrder();
                ViewData["get_manu"] = context.GetManu();
                ViewData["get_product"] = context.GetProducts();
                if (HttpContext.Session.GetInt32("chk_addmenu")!=null)
                {
                    HttpContext.Session.Remove("chk_addmenu");
                    ViewData["chk_addmenu"] = 0;
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Confirm_AddManu(IFormFile files, Manufacturer m)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;
            var filePaths = files.FileName.ToString();
            if (HttpContext.Session.GetString("email") != null)
            {
                string email = HttpContext.Session.GetString("email");
                ViewData["admin"] = context.Get_Admin(email);
                ViewData["count_product"] = context.GetProducts().Count();
                ViewData["count_customer"] = context.GetCustomers().Count();
                ViewData["count_customer"] = context.GetCustomers().Count();
                ViewData["count_p_cat"] = context.GetP_cates().Count();
                ViewData["count_pending_order"] = context.Get_PedingOrder().Count();
                ViewData["pending_order"] = context.Get_PedingOrder();
                ViewData["get_manu"] = context.GetManu();
                ViewData["get_product"] = context.GetProducts();
                m.Manufacturer_image = filePaths;
                if (context.Add_Manu(m) > 0)
                {
                    HttpContext.Session.SetInt32("chk_addmanu", 1);
                    ViewData["get_manu"] = context.GetManu();
                    return Redirect("/Admin/Admin/View_Manu");
                }
                else
                {
                    HttpContext.Session.SetInt32("chk_addmanu", 0);
                    return Redirect("/Admin/Admin/Add_Manu");
                }
            }
            return View();
        }

        public IActionResult View_Manu()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;
            if (HttpContext.Session.GetString("email") != null)
            {
                string email = HttpContext.Session.GetString("email");
                ViewData["admin"] = context.Get_Admin(email);
                ViewData["count_product"] = context.GetProducts().Count();
                ViewData["count_customer"] = context.GetCustomers().Count();
                ViewData["count_p_cat"] = context.GetP_cates().Count();
                ViewData["p_cat"] = context.GetP_cates();
                ViewData["cat"] = context.GetCates();
                ViewData["count_pending_order"] = context.Get_PedingOrder().Count();
                ViewData["pending_order"] = context.Get_PedingOrder();
                ViewData["get_manu"] = context.GetManu();
                ViewData["get_product"] = context.GetProducts();
                if (HttpContext.Session.GetInt32("chk_addmanu") != null)
                {
                    HttpContext.Session.Remove("chk_addmanu");
                    ViewData["chk_addmanu"] = 1;
                }
                if(HttpContext.Session.GetInt32("chk_updatemanu")!=null)
                {
                    HttpContext.Session.Remove("chk_updatemanu");
                    ViewData["chk_updatemanu"] = 1;
                }
                if(HttpContext.Session.GetInt32("chk_deletemanu") != null)
                {
                    HttpContext.Session.Remove("chk_deletemanu");
                    ViewData["chk_deletemanu"] = 1;
                }
            }
            return View();
        }
        public IActionResult Update_Manu(string manufacturer_id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;
            dynamic mymodel = new ExpandoObject();
            if (HttpContext.Session.GetString("email") != null)
            {
                string email = HttpContext.Session.GetString("email");
                mymodel.admin = context.Get_Admin(email);
                ViewData["admin"] = context.Get_Admin(email);
                ViewData["count_product"] = context.GetProducts().Count();
                ViewData["count_customer"] = context.GetCustomers().Count();
                ViewData["count_p_cat"] = context.GetP_cates().Count();
                ViewData["p_cat"] = context.GetP_cates();
                ViewData["cat"] = context.GetCates();
                ViewData["count_pending_order"] = context.Get_PedingOrder().Count();
                ViewData["pending_order"] = context.Get_PedingOrder();
                ViewData["get_manu"] = context.GetManu();
                ViewData["get_product"] = context.GetProducts();
                ViewData["manu"] = context.GetManu_ID(Convert.ToInt32(manufacturer_id));
                if (HttpContext.Session.GetInt32("chk_addmanu") != null)
                {
                    HttpContext.Session.Remove("chk_addmanu");
                }
            }
            return View(mymodel);
        }
        [HttpPost]
        public async Task<IActionResult> Confirm_UpdateManu(IFormFile files, Manufacturer m)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;
            var filePaths = files.FileName.ToString();
            if (HttpContext.Session.GetString("email") != null)
            {
                string email = HttpContext.Session.GetString("email");
                ViewData["admin"] = context.Get_Admin(email);
                ViewData["count_product"] = context.GetProducts().Count();
                ViewData["count_customer"] = context.GetCustomers().Count();
                ViewData["count_customer"] = context.GetCustomers().Count();
                ViewData["count_p_cat"] = context.GetP_cates().Count();
                ViewData["count_pending_order"] = context.Get_PedingOrder().Count();
                ViewData["pending_order"] = context.Get_PedingOrder();
                ViewData["get_manu"] = context.GetManu();
                ViewData["get_product"] = context.GetProducts();
                m.Manufacturer_image = filePaths;
                if (context.Update_Manu(m) > 0)
                {
                    HttpContext.Session.SetInt32("chk_updatemanu", 1);
                    ViewData["get_manu"] = context.GetManu();
                    return Redirect("/Admin/Admin/View_Manu");
                }
                else
                {
                    HttpContext.Session.SetInt32("chk_addmanu", 0);
                    return Redirect("/Admin/Admin/Update_Manu");
                }
            }
            return View();
        }
        public IActionResult Delete_Manu(string manufacturer_id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;
            if (HttpContext.Session.GetString("email") != null)
            {
                string email = HttpContext.Session.GetString("email");
                ViewData["admin"] = context.Get_Admin(email);
                ViewData["count_product"] = context.GetProducts().Count();
                ViewData["count_customer"] = context.GetCustomers().Count();
                ViewData["count_p_cat"] = context.GetP_cates().Count();
                ViewData["count_pending_order"] = context.Get_PedingOrder().Count();
                ViewData["pending_order"] = context.Get_PedingOrder();
                ViewData["get_manu"] = context.GetManu();
                ViewData["get_product"] = context.GetProducts();
                ViewData["manu"] = context.GetManu_ID(Convert.ToInt32(manufacturer_id));
                if (context.Delete_Manu(Convert.ToInt32(manufacturer_id))!=0)
                {
                    HttpContext.Session.SetInt32("chk_deletemanu", 1);
                    ViewData["get_manu"] = context.GetManu();
                    return Redirect("/Admin/Admin/View_Manu");

                }
            }
            return View();
        }
        public IActionResult View_Product()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;
            if (HttpContext.Session.GetString("email") != null)
            {
                string email = HttpContext.Session.GetString("email");
                ViewData["admin"] = context.Get_Admin(email);
                ViewData["count_product"] = context.GetProducts().Count();
                ViewData["count_customer"] = context.GetCustomers().Count();
                ViewData["count_p_cat"] = context.GetP_cates().Count();
                ViewData["p_cat"] = context.GetP_cates();
                ViewData["cat"] = context.GetCates();
                ViewData["count_pending_order"] = context.Get_PedingOrder().Count();
                ViewData["pending_order"] = context.Get_PedingOrder();
                ViewData["get_manu"] = context.GetManu();
                ViewData["get_product"] = context.GetProducts();

                if (HttpContext.Session.GetInt32("chk_addproduct") != null)
                {
                    HttpContext.Session.Remove("chk_addproduct");
                    ViewData["chk_addproduct"] = 1;
                }
                if (HttpContext.Session.GetInt32("chk_updateproduct") != null)
                {
                    HttpContext.Session.Remove("chk_updateproduct");
                    ViewData["chk_updateproduct"] = 1;
                }
                if (HttpContext.Session.GetInt32("chk_deleteproduct") != null)
                {
                    HttpContext.Session.Remove("chk_deleteproduct");
                    ViewData["chk_deleteproduct"] = 1;
                }
            }

            return View();
        }
        public IActionResult Add_Product()
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;
            if (HttpContext.Session.GetString("email") != null)
            {
                string email = HttpContext.Session.GetString("email");
                ViewData["admin"] = context.Get_Admin(email);
                ViewData["count_product"] = context.GetProducts().Count();
                ViewData["count_customer"] = context.GetCustomers().Count();
                ViewData["count_p_cat"] = context.GetP_cates().Count();
                ViewData["p_cat"] = context.GetP_cates();
                ViewData["cat"] = context.GetCates();
                ViewData["count_pending_order"] = context.Get_PedingOrder().Count();
                ViewData["pending_order"] = context.Get_PedingOrder();
                ViewData["get_manu"] = context.GetManu();
                ViewData["get_product"] = context.GetProducts();
                if (HttpContext.Session.GetInt32("chk_addproduct") != null)
                {
                    HttpContext.Session.Remove("chk_addproduct");
                    ViewData["chk_addproduct"] = 0;
                }
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Confirm_AddProduct(IFormFile files, Product p)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;
            var filePaths = files.FileName.ToString();
            if (HttpContext.Session.GetString("email") != null)
            {
                string email = HttpContext.Session.GetString("email");
                ViewData["admin"] = context.Get_Admin(email);
                ViewData["count_product"] = context.GetProducts().Count();
                ViewData["count_customer"] = context.GetCustomers().Count();
                ViewData["count_customer"] = context.GetCustomers().Count();
                ViewData["count_p_cat"] = context.GetP_cates().Count();
                ViewData["count_pending_order"] = context.Get_PedingOrder().Count();
                ViewData["pending_order"] = context.Get_PedingOrder();
                ViewData["get_manu"] = context.GetManu();
                ViewData["get_product"] = context.GetProducts();
                p.Product_img = filePaths;
                if (context.Add_Product(p) > 0)
                {
                    HttpContext.Session.SetInt32("chk_addproduct", 1);
                    ViewData["get_product"] = context.GetProducts();
                    return Redirect("/Admin/Admin/View_Product");
                }
                else
                {
                    HttpContext.Session.SetInt32("chk_addproduct", 0);
                    return Redirect("/Admin/Admin/Add_Product");
                }
            }
            return View();
        }
        public IActionResult Delete_Product(string pro_id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;
            if (HttpContext.Session.GetString("email") != null)
            {
                string email = HttpContext.Session.GetString("email");
                ViewData["admin"] = context.Get_Admin(email);
                ViewData["count_product"] = context.GetProducts().Count();
                ViewData["count_customer"] = context.GetCustomers().Count();
                ViewData["count_p_cat"] = context.GetP_cates().Count();
                ViewData["count_pending_order"] = context.Get_PedingOrder().Count();
                ViewData["pending_order"] = context.Get_PedingOrder();
                ViewData["get_manu"] = context.GetManu();
                ViewData["get_product"] = context.GetProducts();

                if (context.Delete_Product(Convert.ToInt32(pro_id)) != 0)
                {
                    HttpContext.Session.SetInt32("chk_deleteproduct", 1);
                    ViewData["get_product"] = context.GetProducts();
                    return Redirect("/Admin/Admin/View_Product");

                }
            }
            return View();
        }
        public IActionResult Update_Product(string pro_id)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;
            if (HttpContext.Session.GetString("email") != null)
            {
                string email = HttpContext.Session.GetString("email");
                ViewData["admin"] = context.Get_Admin(email);
                ViewData["count_product"] = context.GetProducts().Count();
                ViewData["count_customer"] = context.GetCustomers().Count();
                ViewData["count_p_cat"] = context.GetP_cates().Count();
                ViewData["p_cat"] = context.GetP_cates();
                ViewData["cat"] = context.GetCates();
                ViewData["count_pending_order"] = context.Get_PedingOrder().Count();
                ViewData["pending_order"] = context.Get_PedingOrder();
                ViewData["get_manu"] = context.GetManu();
                ViewData["get_product"] = context.GetProducts();
                ViewData["product"] = context.GetProducts_Detail(pro_id);
                ViewData["p_cat_id"] = context.Get_P_cates_id(Convert.ToInt32(pro_id));
                ViewData["cat_id"] = context.Get_Cates_id(Convert.ToInt32(pro_id));
                ViewData["manu_id"] = context.Get_Manu_id(Convert.ToInt32(pro_id));
                if (HttpContext.Session.GetInt32("chk_addproduct") != null)
                {
                    HttpContext.Session.Remove("chk_addproduct");
                }
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Confirm_UpdateProduct(IFormFile files, Product pro)
        {
            StoreContext context = HttpContext.RequestServices.GetService(typeof(mvcproject.Models.StoreContext)) as StoreContext;
            var filePaths = files.FileName.ToString();
            if (HttpContext.Session.GetString("email") != null)
            {
                string email = HttpContext.Session.GetString("email");
                ViewData["admin"] = context.Get_Admin(email);
                ViewData["count_product"] = context.GetProducts().Count();
                ViewData["count_customer"] = context.GetCustomers().Count();
                ViewData["count_customer"] = context.GetCustomers().Count();
                ViewData["count_p_cat"] = context.GetP_cates().Count();
                ViewData["count_pending_order"] = context.Get_PedingOrder().Count();
                ViewData["pending_order"] = context.Get_PedingOrder();
                ViewData["get_manu"] = context.GetManu();
                ViewData["get_product"] = context.GetProducts();
                pro.Product_img = filePaths;
                if (context.Update_Product(pro) > 0)
                {
                    HttpContext.Session.SetInt32("chk_updateproduct", 1);
                    ViewData["get_product"] = context.GetProducts();
                    return Redirect("/Admin/Admin/View_Product");
                }
                else
                {
                    HttpContext.Session.SetInt32("chk_updateproduct", 0);
                    return Redirect("/Admin/Admin/Update_Product");
                }
            }
            return View();
        }
    }
}
