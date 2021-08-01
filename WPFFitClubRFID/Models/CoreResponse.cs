using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFFitClubRFID.Models
{
    public class CoreResponse
    {
        public bool is_success { get; set; }
        public string user_message { get; set; }
        public string dev_message { get; set; }
        public long? total_items { get; set; }
        public long? total_pages { get; set; }
        public int? current_page { get; set; }
        public List<BarCodeSearch > data { get; set; }
    }
}
