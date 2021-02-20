using MD.PersianDateTime.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMSBackend.Models
{
    public class ClientSessionUsageReportModel
    {
        public long invoice_id { get; set; }
        public long sale_invoice_details_id { get; set; }   
        public DateTime invoice_date { get; set; }
        public string product_name { get; set; }
        public int session_qty { get; set; }
        public int session_used { get; set; }
        public bool can_use { get; set; }
        public string invoice_date_fa {
            get
            {
                var str = new PersianDateTime(invoice_date);
                return str.ToString();
            }
        }

    }
}
