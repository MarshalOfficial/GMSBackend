using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFFitClubRFID.Models
{
    public class LoginResult
    {
        public string user_id { get; set; }
        public string user_name { get; set; }
        public string role { get; set; }
        public string original_user_name { get; set; }
        public string refresh_token { get; set; }
        public string access_token { get; set; }
    }
}
