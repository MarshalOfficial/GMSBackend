using MD.PersianDateTime.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMSBackend.Models
{
    public class SaleInvoiceReportModel
    {
        //header
        public long ID { get; set; }
        public DateTime InvDate { get; set; }
        public long AccountID { get; set; }        

        public long? VisitorID { get; set; }

        public short InvType { get; set; }

        public double? Price { get; set; }

        public double? Reduction { get; set; }

        public string Memo { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsDeleted { get; set; }

        public string InvDateFa
        {
            get
            {
                var str = new PersianDateTime(InvDate);
                return str.ToString();
            }
        }

        //detail
        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public int Qty { get; set; }

        public double ProductPrice { get; set; }    

        public short? Reduction_Percent { get; set; }

        public double? Reduction_Price { get; set; }
        
        public int SessionQty { get; set; }

        public int SessionReserved { get; set; }

        public int SessionUsed { get; set; }


        //payment
        public int SaleInvoicePaymentTypeId { get; set; }

        public decimal PaymentPrice { get; set; }

        public string Description { get; set; }

        //Account
        public string AccountTitle { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        //payment type
        public string PaymentTypeTitle { get; set; }    

    }
}
