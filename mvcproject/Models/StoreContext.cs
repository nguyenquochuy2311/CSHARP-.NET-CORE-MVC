using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Web;
using System.Linq;
using mvcproject.Models;

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
        public static List<Product> product_list { get; set; }
        public static void InitProductList(int product_count)
        {
            product_list = new List<Product>();
            for(int i=1;i<product_count+1;i++)
            {
                product_list.Add(
                    new Product()
                    {
                        Product_id = i,
                        P_cat_id = i,
                        Cat_id = i,
                        Manufacturer_id=i,
                        Date=DateTime.Now,
                        Product_title="Product_title"+i,
                        Product_img="Product_img"+i,
                        Product_price=i,
                        Product_keywords="Product_keywords"+i,
                        Product_desc="Product_desc"+i
                    }
                    );
            }
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
        public List<CartItem> GetProduct_Cart()
        {
            List<CartItem> list = new List<CartItem>();

            using (MySqlConnection conn=GetConnection())
            {
                conn.Open();
                string query = "select * from cart join products where cart.p_id=products.product_id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new CartItem()
                        {
                            _Cart_product=new Product(Convert.ToInt32(reader["product_id"]),Convert.ToInt32(reader["p_cat_id"]),Convert.ToInt32(reader["cat_id"]),Convert.ToInt32(reader["manufacturer_id"]),(DateTime)(reader["date"]),reader["product_title"].ToString(),reader["product_img"].ToString(),Convert.ToInt32(reader["product_price"]),reader["product_keywords"].ToString(),reader["product_desc"].ToString()),
                            _Ip_add = reader["ip_add"].ToString(),
                            _Qty = Convert.ToInt32(reader["qty"]),
                            _Size = reader["size"].ToString()
                        }); ;
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public int Add_Product(Product p)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "insert into products (p_cat_id,cat_id,manufacturer_id,date,product_title,product_img,product_price,product_keywords,product_desc) values (@p_cat_id,@cat_id,@manufacturer_id,@date,@product_title,@product_img,@product_price,@product_keywords,@product_desc)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@p_cat_id", p.P_cat_id);
                cmd.Parameters.AddWithValue("@cat_id", p.Cat_id);
                cmd.Parameters.AddWithValue("@manufacturer_id", p.Manufacturer_id);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.AddWithValue("@product_title", p.Product_title);
                cmd.Parameters.AddWithValue("@product_img", p.Product_img);
                cmd.Parameters.AddWithValue("@product_price", p.Product_price);
                cmd.Parameters.AddWithValue("@product_keywords", p.Product_keywords);
                cmd.Parameters.AddWithValue("@product_desc", p.Product_desc);
                return (cmd.ExecuteNonQuery());
            }
        }
        public int Delete_Product(int pro_id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "delete from products where product_id=" + pro_id;
                MySqlCommand cmd = new MySqlCommand(str, conn);
                return (cmd.ExecuteNonQuery());
            }
        }
        public int Update_Product(Product p)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "update products set p_cat_id=@p_cat_id,cat_id=@cat_id,manufacturer_id=@manufacturer_id,date=@date,product_title=@product_title,product_img=@product_img,"+
            "product_price=@product_price,product_keywords=@product_keywords,product_desc=@product_desc where product_id=" + p.Product_id;
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@p_cat_id", p.P_cat_id);
                cmd.Parameters.AddWithValue("@cat_id", p.Cat_id);
                cmd.Parameters.AddWithValue("@manufacturer_id", p.Manufacturer_id);
                cmd.Parameters.AddWithValue("@product_title", p.Product_title);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.AddWithValue("@product_img", p.Product_img);
                cmd.Parameters.AddWithValue("@product_price", p.Product_price);
                cmd.Parameters.AddWithValue("@product_keywords", p.Product_keywords);
                cmd.Parameters.AddWithValue("@product_desc", p.Product_desc);
                return (cmd.ExecuteNonQuery());
            }
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
        public Product_Category Get_P_cates_id(int pro_id)
        {
            Product_Category _p_cat = new Product_Category();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from product_categories join products on product_categories.p_cat_id=products.p_cat_id where product_id=" + pro_id;
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    _p_cat.P_cat_id = Convert.ToInt32(reader["p_cat_id"]);
                    _p_cat.P_cat_title = reader["p_cat_title"].ToString();
                    _p_cat.P_cat_top = reader["p_cat_top"].ToString();
                    _p_cat.P_cat_image = reader["P_cat_image"].ToString();
                    reader.Close();
                }
                conn.Close();
            }
            return (_p_cat);
        }
        public Category Get_Cates_id(int pro_id)
        {
            Category _cat = new Category();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from categories join products on categories.cat_id=products.cat_id where product_id=" + pro_id;
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    _cat.Cat_id = Convert.ToInt32(reader["cat_id"]);
                    _cat.Cat_title = reader["cat_title"].ToString();
                    _cat.Cat_top = reader["cat_top"].ToString();
                    _cat.Cat_image = reader["cat_image"].ToString();
                    reader.Close();
                }
                conn.Close();
            }
            return (_cat);
        }
        public Manufacturer Get_Manu_id(int pro_id)
        {
            Manufacturer _manu = new Manufacturer();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from manufacturers join products on manufacturers.manufacturer_id=products.manufacturer_id where product_id=" + pro_id;
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    _manu.Manufacturer_id = Convert.ToInt32(reader["manufacturer_id"]);
                    _manu.Manufacturer_title = reader["manufacturer_title"].ToString();
                    _manu.Manufacturer_top = reader["manufacturer_top"].ToString();
                    _manu.Manufacturer_image = reader["manufacturer_image"].ToString();
                    reader.Close();
                }
                conn.Close();
            }
            return (_manu);
        }
        public List<Category> GetCates()
        {
            List<Category> list = new List<Category>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from categories";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Category()
                        {
                            Cat_id = Convert.ToInt32(reader["cat_id"]),
                            Cat_title = reader["cat_title"].ToString(),
                            Cat_image = reader["cat_image"].ToString()
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
                string query = "select * from manufacturers";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Manufacturer()
                        {
                            Manufacturer_id = Convert.ToInt32(reader["manufacturer_id"]),
                            Manufacturer_title = reader["manufacturer_title"].ToString(),
                            Manufacturer_top=reader["manufacturer_top"].ToString(),
                            Manufacturer_image = reader["manufacturer_image"].ToString()
                        }); ;
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public Manufacturer GetManu_ID(int manu_id)
        {
            Manufacturer _manu = new Manufacturer();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from manufacturers where manufacturer_id="+manu_id;
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    _manu.Manufacturer_id = Convert.ToInt32(reader["manufacturer_id"]);
                    _manu.Manufacturer_title = reader["manufacturer_title"].ToString();
                    _manu.Manufacturer_top = reader["manufacturer_top"].ToString();
                    _manu.Manufacturer_image = reader["manufacturer_image"].ToString();
                    reader.Close();
                }
                conn.Close();
            }
            return (_manu);
        }
        public int Delete_Manu(int manu_id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "delete from manufacturers where manufacturer_id="+manu_id;
                MySqlCommand cmd = new MySqlCommand(str, conn);
                return (cmd.ExecuteNonQuery());
            }
        }
        public int Add_Manu(Manufacturer manu)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "insert into manufacturers(manufacturer_title,manufacturer_top,manufacturer_image) values (@manufacturer_title, @manufacturer_top, @manufacturer_image)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@manufacturer_title", manu.Manufacturer_title);
                cmd.Parameters.AddWithValue("@manufacturer_top", manu.Manufacturer_top);
                cmd.Parameters.AddWithValue("@manufacturer_image", manu.Manufacturer_image);
                return (cmd.ExecuteNonQuery());
            }
        }
        public int Update_Manu(Manufacturer manu)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "update manufacturers set manufacturer_title=@manufacturer_title, manufacturer_top=@manufacturer_top, manufacturer_image=@manufacturer_image where manufacturer_id="+manu.Manufacturer_id;
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@manufacturer_title", manu.Manufacturer_title);
                cmd.Parameters.AddWithValue("@manufacturer_top", manu.Manufacturer_top);
                cmd.Parameters.AddWithValue("@manufacturer_image", manu.Manufacturer_image);
                return (cmd.ExecuteNonQuery());
            }
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
                        }); 
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public int Check_Cart(int pro_id)
        {
            int i = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select * from cart where p_id=@p_id";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("p_id", pro_id);
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
        public int Count_Cart()
        {
            int i = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select * from cart";
                MySqlCommand cmd = new MySqlCommand(str, conn);
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
        public List<Customer> GetCustomers()
        {
            List<Customer> list = new List<Customer>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from customers";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Customer()
                        {
                            Customer_id = Convert.ToInt32(reader["customer_id"]),
                            Customer_name = reader["customer_name"].ToString(),
                            Customer_email = reader["customer_email"].ToString(),
                            Customer_pass = reader["customer_pass"].ToString(),
                            Customer_address = reader["customer_address"].ToString(),
                            Customer_contact = reader["customer_contact"].ToString(),
                            Customer_image = reader["customer_image"].ToString(),
                    });
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
                    _c.Customer_address = reader["customer_address"].ToString();
                    _c.Customer_contact = reader["customer_contact"].ToString();
                    _c.Customer_image = reader["customer_image"].ToString();
                    reader.Close();
                }
                conn.Close();
            }
            return (_c);
        }
        public int GetID_Customer(string email)
        {
            int id_customer =0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from customers where customer_email='" + email + "'";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    id_customer = Convert.ToInt32(reader["customer_id"]);
                    reader.Close();
                }
                conn.Close();
            }
            return id_customer;
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
        public int Delete_Item(string pro_id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "delete from cart where p_id=@p_id";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("p_id", Convert.ToInt32(pro_id));
                return (cmd.ExecuteNonQuery());
            }
        }
        public int Sum_Cart()
        {
            int sum_init = 0;
            int sum_all = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from cart join products where cart.p_id=products.product_id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sum_init = (Convert.ToInt32(reader["qty"]) * Convert.ToInt32(reader["product_price"]));
                        sum_all += sum_init;
                    }
                }
            }
            return sum_all;
        }
        public int Update_Qty(string pro_id,int qty)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "update cart set qty=@qty where p_id=@p_id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("qty", qty);
                cmd.Parameters.AddWithValue("p_id", Convert.ToInt32(pro_id));
                return (cmd.ExecuteNonQuery());
            }
        }
        public int Add_C_P_Order(int customer_id, List<CartItem> ci)
        {
            List<MyOrder> co_list = new List<MyOrder>();
            List<PendingOrder> po_list = new List<PendingOrder>();

            int count = 0;

            Random r = new Random();
            int num = r.Next();

            foreach (CartItem item in ci)
            { 
                co_list.Add(new MyOrder
                { 
                    Customer_id=customer_id,
                    Due_amount= item._Qty * item._Cart_product.Product_price,
                    Invoice_no=num,
                    Qty= item._Qty,
                    Size=item._Size,
                    Order_date=DateTime.Now,
                    Order_status="Dang cho xu ly",
                });
                po_list.Add(new PendingOrder
                {
                    Customer_id = customer_id,
                    Invoice_no = num,
                    Product_id = item._Cart_product.Product_id,
                    Qty = item._Qty,
                    Size = item._Size,
                    Order_status = "Dang cho xu ly",
                });
            }
            var str = "insert into customer_orders (customer_id,due_amount," +
                "invoice_no,qty,size,order_date,order_status) values " +
                "(@customer_id,@due_amount,@invoice_no,@qty,@size,@order_date,@order_status)";
            foreach (MyOrder item in co_list)
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();            
                    MySqlCommand cmd = new MySqlCommand(str, conn);
                    //cmd.Parameters.AddWithValue("order_id", item.Order_id);
                    cmd.Parameters.AddWithValue("@customer_id", item.Customer_id);
                    cmd.Parameters.AddWithValue("@due_amount", item.Due_amount);
                    cmd.Parameters.AddWithValue("@invoice_no", item.Invoice_no);
                    cmd.Parameters.AddWithValue("@qty", item.Qty);
                    cmd.Parameters.AddWithValue("@size", item.Size);
                    cmd.Parameters.AddWithValue("@order_date", item.Order_date);
                    cmd.Parameters.AddWithValue("@order_status", item.Order_status);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    count++;
                }
            }
            var str1 = "insert into pending_orders (customer_id,invoice_no," +
                "product_id,qty,size,order_status) values " +
                "(@customer_id,@invoice_no,@product_id,@qty,@size,@order_status)";
            foreach (PendingOrder item in po_list)
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(str1, conn);
                    //cmd.Parameters.AddWithValue("order_id", item.Order_id);
                    cmd.Parameters.AddWithValue("@customer_id", item.Customer_id);
                    cmd.Parameters.AddWithValue("@invoice_no", item.Invoice_no);
                    cmd.Parameters.AddWithValue("@product_id", item.Product_id);
                    cmd.Parameters.AddWithValue("@qty", item.Qty);
                    cmd.Parameters.AddWithValue("@size", item.Size);
                    cmd.Parameters.AddWithValue("@order_status", item.Order_status);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    count++;
                }
            }
            return count/2;      
        }
        public int Delete_Item_Order()
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "delete from cart";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                return (cmd.ExecuteNonQuery());
            }
        }
        public List<MyOrder> Get_Order(string customer_id)
        {
            List<MyOrder> list = new List<MyOrder>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from customer_orders where customer_id = " + Convert.ToInt32(customer_id);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new MyOrder()
                        {
                            Order_id = Convert.ToInt32(reader["order_id"]),
                            Customer_id = Convert.ToInt32(reader["customer_id"]),
                            Due_amount = Convert.ToInt32(reader["due_amount"]),
                            Invoice_no = Convert.ToInt32(reader["invoice_no"]),
                            Qty = Convert.ToInt32(reader["qty"]),
                            Size = reader["size"].ToString(),
                            Order_date = (DateTime)(reader["order_date"]),
                            Order_status = reader["order_status"].ToString(),
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public MyOrder Get_Order(int order_id)
        {
            MyOrder order = new MyOrder();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from customer_orders where order_id = " + order_id;
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    order.Order_id = Convert.ToInt32(reader["order_id"]);
                    order.Due_amount = Convert.ToInt32(reader["due_amount"]);
                    order.Invoice_no = Convert.ToInt32(reader["invoice_no"]);
                }
            }
            return order;
        }
        public bool Confirm_Order(string order_id)
        {
            int count = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "update customer_orders set order_status = 'Hoàn tất' where order_id='" + order_id + "'";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        count++;
                    }
                }
                if (count > 0)
                    return true;
                else return false;
            }
        }
        public bool Check_pass(string email, string password)
        {
            int count = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from customers where customer_email = '" + email + "' and customer_pass = '" + password + "'";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        count++;
                    }
                }
                if (count > 0)
                    return true;
                else return false;
            }
        }
        public bool Update_Pass(string email, string new_password)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "update customers set customer_pass = '" + new_password + "' where customer_email = '" + email + "'";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else return false;
            }
        }
        public Customer Get_C_Order(string customer_email)
        {
            Customer _c = new Customer();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from customers where customer_email = '" + customer_email + "'";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    _c.Customer_id = Convert.ToInt32(reader["customer_id"]);
                    _c.Customer_name = reader["customer_name"].ToString();
                    _c.Customer_email = reader["customer_email"].ToString();
                    _c.Customer_pass = reader["customer_pass"].ToString();
                    _c.Customer_address = reader["customer_address"].ToString();
                    _c.Customer_contact = reader["customer_contact"].ToString();
                    _c.Customer_image = reader["customer_image"].ToString();
                    reader.Close();
                }
                conn.Close();
            }
            return (_c);
        }
        public bool Add_Payment(Payments payments)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "insert into payments(invoice_no, amount, payment_date)" +
                    " values (" + payments.Invoice_no +
                    "," + payments.Amount +
                    ", '" + payments.Payment_date + "')"
                    ;
                MySqlCommand cmd = new MySqlCommand(query, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else return false;
            }
        }
        public bool Update_Customer_Order_Completed(int order_id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "update customer_orders set order_status = 'Hoàn tất' where order_id = '" + order_id + "'";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else return false;
            }
        }
        public bool Delete_Pending_Order(int invoice_no)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "delete from pending_orders where invoice_no = " + invoice_no + "";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else return false;
            }
        }
        public bool Update_Customer(Customer customer)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "update customers set customer_name = '" + customer.Customer_name + "'," +
                    " customer_contact = " + customer.Customer_contact + "," +
                    " customer_address = '" + customer.Customer_address + "'," +
                    " customer_image = '" + customer.Customer_image + "' where customer_email = '" + customer.Customer_email + "'";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else return false;
            }
        }
        public bool Delete_Customer(string email)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "Delete from customers where customer_email = '" + email + "'";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                if (cmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else return false;
            }
        }
        public List<PendingOrder> Get_PedingOrder()
        {
            List<PendingOrder> list = new List<PendingOrder>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from pending_orders join customers on pending_orders.customer_id=customers.customer_id where order_status='Dang cho xu ly' order by 1 DESC LIMIT 0,4";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new PendingOrder()
                        {
                            Order_id = Convert.ToInt32(reader["order_id"]),
                            Customer_id = Convert.ToInt32(reader["customer_id"]),
                            Invoice_no = Convert.ToInt32(reader["invoice_no"]),
                            Product_id = Convert.ToInt32(reader["product_id"]),
                            Qty = Convert.ToInt32(reader["qty"]),
                            Size = reader["size"].ToString(),
                            Order_status = reader["order_status"].ToString(),
                            _customer = new Customer(Convert.ToInt32(reader["customer_id"]),reader["customer_name"].ToString(),reader["customer_email"].ToString(),reader["customer_pass"].ToString(),reader["customer_address"].ToString(),reader["customer_contact"].ToString(),reader["customer_image"].ToString(),reader["customer_ip"].ToString())
                        });
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return list;
        }
        public int Check_AdLogin(string email,string pass)
        {
            int i = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select * from admins where admin_email=@admin_email and admin_pass=@admin_pass";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("admin_email", email);
                cmd.Parameters.AddWithValue("admin_pass", pass);
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
        public mvcproject.Areas.Admin.Models.Admin Get_Admin(string email)
        {
            mvcproject.Areas.Admin.Models.Admin _ad = new mvcproject.Areas.Admin.Models.Admin();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from admins where admin_email = '" + email + "'";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    _ad.Admin_id = Convert.ToInt32(reader["admin_id"]);
                    _ad.Admin_name = reader["admin_name"].ToString();
                    _ad.Admin_email = reader["admin_email"].ToString();
                    _ad.Admin_pass = reader["admin_pass"].ToString();
                    _ad.Admin_image = reader["admin_image"].ToString();
                    _ad.Admin_country = reader["admin_country"].ToString();
                    _ad.Admin_contact = reader["admin_contact"].ToString();
                    _ad.Admin_job = reader["admin_job"].ToString();
                    reader.Close();
                }
                conn.Close();
            }
            return (_ad);
        }
        public StoreContext()
        {
            ConnectionString = Startup.Configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
        }
    }
}
