using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMSBackend.Models.dto
{
    public class ClientSearchByRfidDTO
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public long customer_id { get; set; }
        public bool? gender { get; set; }
        public long sale_invoice_details_log { get; set; }
        public int session_qty { get; set; }
        public int session_used { get; set; }   
    }
}
