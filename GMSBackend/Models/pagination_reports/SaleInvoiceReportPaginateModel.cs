using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMSBackend.Models.pagination_reports
{
    public class SaleInvoiceReportPaginateModel : SaleInvoiceReportModel
    {
        public long row_count { get; set; }
    }
}
