using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcproject.Models
{
    public class Product_Category
    {
        private int p_cat_id;
        private string p_cat_title;
        private string p_cat_top;
        private string p_cat_image;

        public int P_cat_id { get => p_cat_id; set => p_cat_id = value; }
        public string P_cat_title { get => p_cat_title; set => p_cat_title = value; }
        public string P_cat_top { get => p_cat_top; set => p_cat_top = value; }
        public string P_cat_image { get => p_cat_image; set => p_cat_image = value; }
        public Product_Category(int p_cat_id,string p_cat_title,string p_cat_top,string p_cat_image)
        {
            this.p_cat_id = p_cat_id;
            this.p_cat_title = p_cat_title;
            this.p_cat_top = p_cat_top;
            this.p_cat_image = p_cat_image;
        }
        public Product_Category() { }
    }
}
