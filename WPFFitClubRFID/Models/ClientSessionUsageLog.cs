using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFFitClubRFID.Models
{
    public class ClientSessionUsageLog
    {
        public long id { get; set; }
        public long account_id { get; set; }
        public long sale_invoice_details_id { get; set; }
        public DateTime create_date { get; set; }
        public string description { get; set; }
        public bool is_deleted { get; set; }
        public int qty { get; set; }

    }
}
