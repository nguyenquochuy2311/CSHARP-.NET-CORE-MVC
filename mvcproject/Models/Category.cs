using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcproject.Models
{
    public class Category
    {
        private int cat_id;
        private string cat_title;
        private string cat_top;
        private string cat_image;

        public int Cat_id { get => cat_id; set => cat_id = value; }
        public string Cat_title { get => cat_title; set => cat_title = value; }
        public string Cat_top { get => cat_top; set => cat_top = value; }
        public string Cat_image { get => cat_image; set => cat_image = value; }
        public Category(int cat_id,string cat_title,string cat_top,string cat_image)
        {
            this.cat_id = cat_id;
            this.cat_title = cat_title;
            this.cat_top = cat_top;
            this.cat_image = cat_image;
        }
        public Category() { }
    }
}
