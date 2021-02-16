using System;

namespace GMSBackend.Models
{
    public class AccountUpdateModel
    {
        public long id { get; set; }

        public string title { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public DateTime? birth_date { get; set; }

        public bool? Gender { get; set; }
        
        public string mobile { get; set; }

        public string tel { get; set; }

        public string postal_code { get; set; }

        public string email { get; set; }

        public string telegram { get; set; }

        public string instagram { get; set; }

        public string address { get; set; }
               
        public int? membership_join_type_id { get; set; }

        public int? jobinfo_id { get; set; }

        public string contract_file_path { get; set; }
        
    }
}
