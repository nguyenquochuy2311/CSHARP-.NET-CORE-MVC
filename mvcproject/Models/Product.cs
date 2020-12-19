using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcproject.Models
{
    public class Product
    {
        private int product_id;
        private int p_cat_id;
        private int cat_id;
        private int manufacturer_id;
        private DateTime date;
        private string product_title;
        private string product_img;
        private int product_price;
        private string product_keywords;
        private string product_desc;

        public int Product_id { get => product_id; set => product_id = value; }
        public int P_cat_id { get => p_cat_id; set => p_cat_id = value; }
        public int Cat_id { get => cat_id; set => cat_id = value; }
        public int Manufacturer_id { get => manufacturer_id; set => manufacturer_id = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Product_title { get => product_title; set => product_title = value; }
        public string Product_img { get => product_img; set => product_img = value; }
        public int Product_price { get => product_price; set => product_price = value; }
        public string Product_keywords { get => product_keywords; set => product_keywords = value; }
        public string Product_desc { get => product_desc; set => product_desc = value; }

        public Product(int p_id,int p_cat_id,int cat_id,int m_id,DateTime date,string p_title,string p_img,int p_price,string p_keywords,string p_desc)
        {
            this.product_id = p_id;
            this.p_cat_id = p_cat_id;
            this.cat_id = cat_id;
            this.manufacturer_id = m_id;
            this.date = date;
            this.product_title = p_title;
            this.product_img = p_img;
            this.product_price = p_price;
            this.product_keywords = p_keywords;
            this.product_desc = p_desc;
        }
        public Product() { }
    }
}
