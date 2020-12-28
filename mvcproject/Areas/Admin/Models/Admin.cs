using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcproject.Areas.Admin.Models
{
    public class Admin
    {
        private int admin_id;
        private string admin_name;
        private string admin_email;
        private string admin_pass;
        private string admin_image;
        private string admin_country;
        private string admin_contact;
        private string admin_job;

        public Admin() { }
        public Admin(int admin_id, string admin_name, string admin_email, string admin_pass, string admin_image, string admin_country, string admin_contact, string admin_job)
        {
            this.Admin_id = admin_id;
            this.Admin_name = admin_name;
            this.Admin_email = admin_email;
            this.Admin_pass = admin_pass;
            this.Admin_image = admin_image;
            this.Admin_country = admin_country;
            this.Admin_contact = admin_contact;
            this.Admin_job = admin_job;
        }

        public int Admin_id { get => admin_id; set => admin_id = value; }
        public string Admin_name { get => admin_name; set => admin_name = value; }
        public string Admin_email { get => admin_email; set => admin_email = value; }
        public string Admin_pass { get => admin_pass; set => admin_pass = value; }
        public string Admin_image { get => admin_image; set => admin_image = value; }
        public string Admin_country { get => admin_country; set => admin_country = value; }
        public string Admin_contact { get => admin_contact; set => admin_contact = value; }
        public string Admin_job { get => admin_job; set => admin_job = value; }
    }
}
