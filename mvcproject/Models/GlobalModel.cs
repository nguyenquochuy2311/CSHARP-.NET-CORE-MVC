using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcproject.Models
{
    public class GlobalModel
    {
        private List<Box> box;
        private List<Cart> cart;
        private List<Product> product;
        private List<Product> product_offer;
        private List<Product> detail_product;
        private List<Category> category;
        private List<Product_Category> product_category;
        private List<Manufacturer> manufacturer;
        private List<Slider> slider;
        private List<Slider> slider1;
        private string email;

        public List<Box> Box { get => box; set => box = value; }
        public List<Cart> Cart { get => cart; set => cart = value; }
        public List<Product> Product { get => product; set => product = value; }
        public List<Product> Product_offer { get => product_offer; set => product_offer = value; }
        public List<Product> Detail_product { get => detail_product; set => detail_product = value; }
        public List<Category> Category { get => category; set => category = value; }
        public List<Product_Category> Product_category { get => product_category; set => product_category = value; }
        public List<Manufacturer> Manufacturer { get => manufacturer; set => manufacturer = value; }
        public List<Slider> Slider { get => slider; set => slider = value; }
        public List<Slider> Slider1 { get => slider1; set => slider1 = value; }
        public string Email { get => email; set => email = value; }
    }
}
