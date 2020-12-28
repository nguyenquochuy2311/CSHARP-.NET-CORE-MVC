using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcproject.Models
{
    public class Cart
    {
        private int product_id;
        private string ip_add;
        private int qty;
        private string size;
        public Cart(int product_id, string ip_add, int qty, string size)
        {
            this.Product_id = product_id;
            this.Ip_add = ip_add;
            this.Qty = qty;
            this.Size = size;
        }

        public int Product_id { get => product_id; set => product_id = value; }
        public string Ip_add { get => ip_add; set => ip_add = value; }
        public int Qty { get => qty; set => qty = value; }
        public string Size { get => size; set => size = value; }

        public Cart() { }
    }
    public class CartItem   
    {
        public Product _Cart_product { get; set; }
        public string _Ip_add { get; set; }
        public int _Qty { get; set; }
        public string _Size { get; set; }
        public CartItem() { }
    }
}
