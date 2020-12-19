using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Web;

namespace mvcproject.Models
{
    public class StoreContext
    {
        private readonly IConfiguration configuration;

        public string ConnectionString { get; set; }//biết thành viên 

        public StoreContext(string connectionString) //phuong thuc khoi tao
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection() //lấy connection 
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<Slider> GetSilders1()
        {
            List<Slider> list = new List<Slider>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from slider order by slider_id desc LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Slider()
                        {
                            Slider_id = (int)reader["slider_id"],
                            Slider_name = reader["slider_name"].ToString(),
                            Slider_image = reader["slider_image"].ToString(),

                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }

        public List<Slider> GetSilders()
        {
            List<Slider> list = new List<Slider>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from slider order by slider_id desc LIMIT 1,2";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Slider()
                        {
                            Slider_id = Convert.ToInt32(reader["slider_id"]),
                            Slider_name = reader["slider_name"].ToString(),
                            Slider_image = reader["slider_image"].ToString(),

                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }

        public List<Box> GetBoxes()
        {
            List<Box> list = new List<Box>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from boxes_section order by box_id desc limit 0,3";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Box()
                        {
                            Box_id = Convert.ToInt32(reader["box_id"]),
                            Box_title = reader["box_title"].ToString(),
                            Box_desc = reader["box_desc"].ToString(),

                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }

        public List<Product> GetProducts()
        {
            List<Product> list = new List<Product>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from products order by 1 desc limit 0,8";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Product()
                        {
                            Product_id = Convert.ToInt32(reader["product_id"]),
                            P_cat_id = Convert.ToInt32(reader["p_cat_id"]),
                            Cat_id = Convert.ToInt32(reader["cat_id"]),
                            Manufacturer_id = Convert.ToInt32(reader["manufacturer_id"]),
                            Date = (DateTime)(reader["date"]),
                            Product_title = reader["product_title"].ToString(),
                            Product_img = reader["product_img"].ToString(),
                            Product_price = Convert.ToInt32(reader["product_price"]),
                            Product_keywords = reader["product_keywords"].ToString(),
                            Product_desc = reader["product_desc"].ToString(),

                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }

        public List<Product> GetProducts_Offer()
        {
            List<Product> list = new List<Product>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from products order by rand() limit 0,3";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Product()
                        {
                            Product_id = Convert.ToInt32(reader["product_id"]),
                            P_cat_id = Convert.ToInt32(reader["p_cat_id"]),
                            Cat_id = Convert.ToInt32(reader["cat_id"]),
                            Manufacturer_id = Convert.ToInt32(reader["manufacturer_id"]),
                            Date = (DateTime)(reader["date"]),
                            Product_title = reader["product_title"].ToString(),
                            Product_img = reader["product_img"].ToString(),
                            Product_price = Convert.ToInt32(reader["product_price"]),
                            Product_keywords = reader["product_keywords"].ToString(),
                            Product_desc = reader["product_desc"].ToString(),
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }

        public Product GetProducts_Detail(string id)
        {
            Product _p = new Product();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from products where product_id=" + Convert.ToInt32(id);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    _p.Product_id = Convert.ToInt32(reader["product_id"]);
                    _p.P_cat_id = Convert.ToInt32(reader["p_cat_id"]);
                    _p.Cat_id = Convert.ToInt32(reader["cat_id"]);
                    _p.Manufacturer_id = Convert.ToInt32(reader["manufacturer_id"]);
                    _p.Date = (DateTime)(reader["date"]);
                    _p.Product_title = reader["product_title"].ToString();
                    _p.Product_img = reader["product_img"].ToString();
                    _p.Product_price = Convert.ToInt32(reader["product_price"]);
                    _p.Product_keywords = reader["product_keywords"].ToString();
                    _p.Product_desc = reader["product_desc"].ToString();
                    reader.Close();
                }
                conn.Close();
            }
            return (_p);
        }

        public List<Product_Category> GetP_cates()
        {
            List<Product_Category> list = new List<Product_Category>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from product_categories";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Product_Category()
                        {
                            P_cat_id = Convert.ToInt32(reader["p_cat_id"]),
                            P_cat_title = reader["p_cat_title"].ToString(),
                            P_cat_image=reader["p_cat_image"].ToString(),
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }

        public List<Category> GetCates()
        {
            List<Category> list = new List<Category>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from categories where cat_top='yes'";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Category()
                        {
                            Cat_id = Convert.ToInt32(reader["cat_id"]),
                            Cat_title = reader["p_cat_title"].ToString(),
                            Cat_image = reader["p_cat_image"].ToString()
                        }); ;
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }

        public List<Manufacturer> GetManu()
        {
            List<Manufacturer> list = new List<Manufacturer>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from manufacturers where manufacturer_top = 'yes'";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Manufacturer()
                        {
                            Manufacturer_id = Convert.ToInt32(reader["manufacturer_id"]),
                            Manufacturer_title = reader["manufacturer_title"].ToString(),
                            Manufacturer_image = reader["manufacturer_image"].ToString()
                        }); ;
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }

        public List<Cart> GetCart()
        {
            List<Cart> list = new List<Cart>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from cart";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Cart()
                        {
                            Product_id = Convert.ToInt32(reader["p_id"]),
                            Qty = Convert.ToInt32(reader["qty"]),
                            Size = reader["size"].ToString()
                        }); ;
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }

        public Customer GetCustomer_Login(string email,string pass)
        {
            Customer _c = new Customer();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from customers where customer_email='" + email+"' and customer_pass='"+pass +"'";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    _c.Customer_id = Convert.ToInt32(reader["customer_id"]);
                    _c.Customer_name = reader["customer_name"].ToString();
                    _c.Customer_email = reader["customer_email"].ToString();
                    _c.Customer_pass = reader["customer_pass"].ToString();
                    _c.Customer_coutry = reader["customer_country"].ToString();
                    _c.Customer_city = reader["customer_city"].ToString();
                    _c.Customer_contact = reader["customer_contact"].ToString();
                    _c.Customer_image = reader["customer_image"].ToString();
                    reader.Close();
                }
                conn.Close();
            }
            return (_c);
        }
        public int Count_Customer(string email, string pass)
        {
            int i = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select * from customers where customer_email=@customer_email and customer_pass=@customer_pass";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("customer_email", email);
                cmd.Parameters.AddWithValue("customer_pass", pass);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        i++;
                    }
                }
            }
            return i;
        }
        
        public int Add_Cart(Cart c)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "insert into cart values(@p_id, @ip_add,@qty,@size)";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("p_id", c.Product_id);
                cmd.Parameters.AddWithValue("ip_add", c.Ip_add);
                cmd.Parameters.AddWithValue("qty", c.Qty);
                cmd.Parameters.AddWithValue("size", c.Size);
                return (cmd.ExecuteNonQuery());
            }
        }

        public List<MyOrder> Get_Order(string customer_id)
        {
            List<MyOrder> list = new List<MyOrder>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from customer_orders where order_status='Đang chờ xử lý' and customer_id = "+Convert.ToInt32(customer_id);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new MyOrder()
                        {
                            Order_id=Convert.ToInt32(reader["order_id"]),
                            Customer_id= Convert.ToInt32(reader["customer_id"]),
                            Due_mount=Convert.ToInt32(reader["due_mount"]),
                            Invoice_no=Convert.ToInt32(reader["invoice_no"]),
                            Qty=Convert.ToInt32(reader["qty"]),
                            Size=reader["size"].ToString(),
                            Order_date=(DateTime)(reader["order_date"]),
                            Order_status=reader["order_status"].ToString(),
                        }); 
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }

        public Customer Get_C_Order(string customer_email)
        {
            Customer _c = new Customer();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from customers where customer_email = '" +customer_email+"'";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    _c.Customer_id = Convert.ToInt32(reader["customer_id"]);
                    _c.Customer_name = reader["customer_name"].ToString();
                    _c.Customer_email = reader["customer_email"].ToString();
                    _c.Customer_pass = reader["customer_pass"].ToString();
                    _c.Customer_coutry = reader["customer_country"].ToString();
                    _c.Customer_city = reader["customer_city"].ToString();
                    _c.Customer_contact = reader["customer_contact"].ToString();
                    _c.Customer_image = reader["customer_image"].ToString();
                    reader.Close();
                }
                conn.Close();
            }
            return (_c);
        }

        public StoreContext()
        {
            ConnectionString = Startup.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
        }
    }
}
