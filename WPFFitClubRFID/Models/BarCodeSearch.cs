using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFFitClubRFID.Models
{
    public class BarCodeSearch
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public long customer_id { get; set; }
        public long sale_invoice_details_log { get; set; }
        public int session_qty { get; set; }
        public int session_used { get; set; }

        public bool gender { get; set; }


        public long id { get; set; }
        public long account_id { get; set; }
        public long sale_invoice_details_id { get; set; }
        public DateTime create_date { get; set; }
        public string description { get; set; }
        public bool is_deleted { get; set; }
        public int qty { get; set; }

    }
}
