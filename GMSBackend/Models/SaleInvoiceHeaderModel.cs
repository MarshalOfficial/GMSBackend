using GMSBackend.Entities;
using MD.PersianDateTime.Standard;

namespace GMSBackend.Models
{
    public class SaleInvoiceHeaderModel : SaleInvoiceHeader
    {
        public string inv_date_fa   
        {
            get
            {
                var str = new PersianDateTime(inv_date);
                return str.ToString();
            }
        }
    }
}
