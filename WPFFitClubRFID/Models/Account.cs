using MD.PersianDateTime.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFFitClubRFID.Models
{
    public class Account
    {
        public long id  { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public bool? Gender { get; set; }

        public string mobile { get; set; }

        public string rfid_barcode { get; set; }

    }
}
