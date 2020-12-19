using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcproject.Models
{
    public class Slider
    {
        private int slider_id;
        private string slider_name;
        private string slider_image;

        public int Slider_id { get => slider_id; set => slider_id = value; }
        public string Slider_name { get => slider_name; set => slider_name = value; }
        public string Slider_image { get => slider_image; set => slider_image = value; }

        public Slider(int slider_id, string slider_name, string slider_image)
        {
            this.slider_id = slider_id;
            this.slider_name = slider_name;
            this.slider_image = slider_image;
        }
        public Slider() { }
    }
}
