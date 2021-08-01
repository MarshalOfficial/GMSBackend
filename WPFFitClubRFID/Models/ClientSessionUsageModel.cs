using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFFitClubRFID.Models
{
    public class ClientSessionUsageModel
    {
        public long customer_id { get; set; }
        public long sale_invoice_details_id { get; set; }
        public string description { get; set; }
        public bool is_use { get; set; }
    }
}
