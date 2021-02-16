using GMSBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMSBackend.Models.pagination_reports
{
    public class AccountPaginatedModel : Account
    {
        public long row_count { get; set; }

        public string account_type_title { get; set; }  
    }
}
