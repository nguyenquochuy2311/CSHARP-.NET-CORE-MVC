using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcproject.Models
{
    public class MyOrder
    {
        private int order_id;
        private int customer_id;
        private int due_amount;
        private int invoice_no;
        private int qty;
        private string size;
        private DateTime order_date;
        private string order_status;

        public MyOrder() { }
        public MyOrder(int order_id, int customer_id, int due_mount, int invoice, int qty, string size, DateTime order_date, string order_status)
        {
            this.order_id = order_id;
            this.customer_id = customer_id;
            this.due_amount = due_mount;
            this.invoice_no = invoice;
            this.qty = qty;
            this.size = size;
            this.order_date = order_date;
            this.order_status = order_status;
        }

        public int Order_id { get => order_id; set => order_id = value; }
        public int Customer_id { get => customer_id; set => customer_id = value; }
        public int Due_amount { get => due_amount; set => due_amount = value; }
        public int Invoice_no { get => invoice_no; set => invoice_no = value; }
        public int Qty { get => qty; set => qty = value; }
        public string Size { get => size; set => size = value; }
        public DateTime Order_date { get => order_date; set => order_date = value; }
        public string Order_status { get => order_status; set => order_status = value; }
    }
}
