using GMSBackend.Entities;
using MD.PersianDateTime.Standard;

namespace GMSBackend.Models
{
    public class SaleInvoiceHeaderModel : SaleInvoiceHeader
    {
        public string InvDateFa
        {
            get
            {
                var str = new PersianDateTime(InvDate);
                return str.ToString();
            }
        }
    }
}
