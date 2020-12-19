using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcproject.Models
{
    public class Box
    {
        private int box_id;
        private string box_title;
        private string box_desc;

        public int Box_id { get => box_id; set => box_id = value; }
        public string Box_title { get => box_title; set => box_title = value; }
        public string Box_desc { get => box_desc; set => box_desc = value; }
        public Box(int box_id,string box_title,string box_desc)
        {
            this.box_id = box_id;
            this.box_title = box_title;
            this.box_desc = box_desc;
        }
        public Box() { }
    }
}
