using GMSBackend.Entities;
using MD.PersianDateTime.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMSBackend.Models.pagination_reports
{
    public class AccountPaginatedModel : Account
    {
        public long? row_count { get; set; }

        public string account_type_title { get; set; }

        public string create_date_fa 
        {
            get
            {
                var str = new PersianDateTime(create_date);
                return str.ToString();
            }
        }

        public string join_date_fa
        {
            get
            {
                var str = new PersianDateTime(join_date);
                return str.ToString();
            }
        }
    }
}
