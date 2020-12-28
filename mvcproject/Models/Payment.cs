using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcproject.Models
{
    public class Payments
    {
        private int payment_id;
        private int invoice_no;
        private int amount;
        private string payment_date;
        public Payments() { }
        public Payments(int payment_id, int invoice_no, int amount, string payment_date)
        {
            this.payment_id = payment_id;
            this.invoice_no = invoice_no;
            this.amount = amount;
            this.payment_date = payment_date;
        }

        public int Payment_id { get => payment_id; set => payment_id = value; }
        public int Invoice_no { get => invoice_no; set => invoice_no = value; }
        public int Amount { get => amount; set => amount = value; }
        public string Payment_date { get => payment_date; set => payment_date = value; }
    }
}