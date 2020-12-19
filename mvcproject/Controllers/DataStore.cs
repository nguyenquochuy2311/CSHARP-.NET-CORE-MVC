using Microsoft.AspNetCore.Mvc;
using mvcproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Web;

namespace mvcproject.Controllers
{
    public class DataStore : Controller
    {
        public const string GLOBAL_MODEL = "GLOBAL_MODEL";
        public const string PRODUCT_CATEGORY = "PRODUCT_CATEGORY";
        public const string SLIDER1 = "SLIDER1";
        public const string SLIDER = "SLIDER";
        public const string BOX = "BOX";
        public const string PRODUCT = "PRODUCT";
        public const string PRODUCT_OFFER = "PRODUCT_OFFER";
        public const string MANUFACTURER = "MANUFACTURER";
        public const string DETAIL_PRODUCT = "DETAIL_PRODUCT";
        public const string GET_EMAIL = "Quy khach";

        public const string INSERT_RECORD = "INSERT_RECORD";
        public const string UPDATE_RECORD = "UPDATE_RECORD";
        public const string DELETE_RECORD = "DELETE_RECORD";

        public System.Collections.Specialized.NameValueCollection ServerVariables { get; }

        private GlobalModel globalModel;

        private StoreContext globalContext;

        private DataStore()
        {
            globalModel = new GlobalModel();

            globalContext = new StoreContext();
        }
        private static DataStore instance = null;
        public static DataStore Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataStore();
                }
                return instance;
            }
        }
        public string Get_Session(string email)
        {
            if (email == null)
                return GET_EMAIL;
            return email;
        }
        public object Get_ID(string name, string id)
        {

            switch (name)
            {
                case DETAIL_PRODUCT:
                    if (globalModel.Detail_product == null)
                        globalModel.Detail_product = (List<Product>)HandleGetContext_ID(name, id);
                    return globalModel.Detail_product;
                default:
                    return default;
            }
        }
 
        public object Get(string name)
        {
            switch (name)
            {
                case PRODUCT_CATEGORY:
                    if (globalModel.Product_category == null)
                        globalModel.Product_category = (List<Product_Category>)HandleGetContext(name);
                    return globalModel.Product_category;

                case SLIDER:
                    if (globalModel.Slider == null)
                        globalModel.Slider = (List<Slider>)HandleGetContext(name);
                    return globalModel.Slider;

                case SLIDER1:
                    if (globalModel.Slider1 == null)
                        globalModel.Slider1 = (List<Slider>)HandleGetContext(name);
                    return globalModel.Slider1;

                case BOX:
                    if (globalModel.Box == null)
                        globalModel.Box = (List<Box>)HandleGetContext(name);
                    return globalModel.Box;

                case PRODUCT:
                    if (globalModel.Product == null)
                        globalModel.Product = (List<Product>)HandleGetContext(name);
                    return globalModel.Product;

                case PRODUCT_OFFER:
                    if (globalModel.Product_offer == null)
                        globalModel.Product_offer = (List<Product>)HandleGetContext(name);
                    return globalModel.Product_offer;

                case MANUFACTURER:
                    if (globalModel.Manufacturer == null)
                        globalModel.Manufacturer = (List<Manufacturer>)HandleGetContext(name);
                    return globalModel.Manufacturer;
                case GET_EMAIL:
                    if (globalModel.Email == null)
                        globalModel.Email = HandleGetContext(name).ToString();
                    return globalModel.Email;

                case GLOBAL_MODEL:
                    return globalModel;

                default:
                    return default;
            }
        }
        private object HandleGetContext(string name)
        {
            switch (name)
            {
                case PRODUCT_CATEGORY:
                    return globalContext.GetP_cates();

                case SLIDER:
                    return globalContext.GetSilders();

                case SLIDER1:
                    return globalContext.GetSilders1();

                case BOX:
                    return globalContext.GetBoxes();

                case PRODUCT:
                    return globalContext.GetProducts();

                case PRODUCT_OFFER:
                    return globalContext.GetProducts_Offer();

                case MANUFACTURER:
                    return globalContext.GetManu();

                case GET_EMAIL:
                    return "Quy khach";

                default:
                    return default;
            }
        }
        private object HandleGetContext_ID(string name, string id)
        {
            switch (name)
            {
                case DETAIL_PRODUCT:
                    return globalContext.GetProducts_Detail(id);
                default:
                    return default;
            }
        }
    }
}
