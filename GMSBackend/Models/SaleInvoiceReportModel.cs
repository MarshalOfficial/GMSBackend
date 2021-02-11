using MD.PersianDateTime.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMSBackend.Models
{
    public class SaleInvoiceReportModel
    {
        //header
        public long id { get; set; }
        public DateTime inv_date { get; set; }
        public long account_id { get; set; }        

        public long? visitor_id { get; set; }

        public short inv_type { get; set; }

        public double? price { get; set; }

        public double? reduction { get; set; }

        public string memo { get; set; }

        public DateTime create_date { get; set; }

        public bool is_deleted { get; set; }

        public string inv_date_fa
        {
            get
            {
                var str = new PersianDateTime(inv_date);
                return str.ToString();
            }
        }

        //detail
        public int product_id { get; set; }

        public string product_name { get; set; }

        public int qty { get; set; }

        public double product_price { get; set; }    

        public short? reduction_percent { get; set; }

        public double? reduction_price { get; set; }
        
        public int session_qty { get; set; }

        public int session_reserved { get; set; }

        public int session_used { get; set; }


        //payment
        public int sale_invoice_payment_type_id { get; set; }

        public decimal payment_price { get; set; }

        public string description { get; set; }

        //Account
        public string account_title { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        //payment type
        public string payment_type_title { get; set; }    

    }
}
