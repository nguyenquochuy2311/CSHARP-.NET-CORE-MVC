using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvcproject.Models
{
    public class Customer
    {
        private int customer_id;

        private string customer_name;

        private string customer_email;

        private string customer_pass;

        private string customer_address;

        private string customer_contact;

        private string customer_image;

        private string customer_ip;

        public int Customer_id { get => customer_id; set => customer_id = value; }
        public string Customer_name { get => customer_name; set => customer_name = value; }
        public string Customer_email { get => customer_email; set => customer_email = value; }
        public string Customer_pass { get => customer_pass; set => customer_pass = value; }
        public string Customer_address { get => customer_address; set => customer_address = value; }
        public string Customer_contact { get => customer_contact; set => customer_contact = value; }
        public string Customer_image { get => customer_image; set => customer_image = value; }
        public string Customer_ip { get => customer_ip; set => customer_ip = value; }

        public Customer(int customer_id, string customer_name, string customer_email, string customer_pass, string customer_address, string customer_contact, string customer_image, string customer_ip)
        {
            this.customer_id = customer_id;
            this.customer_name = customer_name;
            this.customer_email = customer_email;
            this.customer_pass = customer_pass;
            this.customer_address = customer_address;
            this.customer_contact = customer_contact;
            this.customer_image = customer_image;
            this.customer_ip = customer_ip;
        }
        public Customer() { }
    }

}
