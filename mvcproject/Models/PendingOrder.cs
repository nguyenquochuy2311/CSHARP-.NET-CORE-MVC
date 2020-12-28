using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcproject.Models
{
    public class PendingOrder
    {
        private int order_id;
        private int customer_id;
        private int invoice_no;
        private int product_id;
        private int qty;
        private string size;
        private string order_status;
        public Customer _customer { get; set; }
        public PendingOrder() { }
        public PendingOrder(int order_id, int customer_id, int invoice_no, int product_id, int qty, string size, string order_status)
        {
            this.order_id = order_id;
            this.customer_id = customer_id;
            this.invoice_no = invoice_no;
            this.product_id = product_id;
            this.qty = qty;
            this.size = size;
            this.order_status = order_status;
        }
        public int Order_id { get => order_id; set => order_id = value; }
        public int Customer_id { get => customer_id; set => customer_id = value; }
        public int Invoice_no { get => invoice_no; set => invoice_no = value; }
        public int Product_id { get => product_id; set => product_id = value; }
        public int Qty { get => qty; set => qty = value; }
        public string Size { get => size; set => size = value; }
        public string Order_status { get => order_status; set => order_status = value; }

    }
}
