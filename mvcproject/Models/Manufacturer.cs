using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcproject.Models
{
    public class Manufacturer
    {
        private int manufacturer_id;
        private string manufacturer_title;
        private string manufacturer_top;
        private string manufacturer_image;

        public int Manufacturer_id { get => manufacturer_id; set => manufacturer_id = value; }
        public string Manufacturer_title { get => manufacturer_title; set => manufacturer_title = value; }
        public string Manufacturer_top { get => manufacturer_top; set => manufacturer_top = value; }
        public string Manufacturer_image { get => manufacturer_image; set => manufacturer_image = value; }

        public Manufacturer(int m_id,string m_title,string m_top,string m_image)
        {
            this.manufacturer_id = m_id;
            this.manufacturer_title = m_title;
            this.manufacturer_top = m_top;
            this.manufacturer_image = m_image;
        }
        public Manufacturer() { }
    }
}
