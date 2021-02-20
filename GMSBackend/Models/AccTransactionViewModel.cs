using GMSBackend.Entities;
using MD.PersianDateTime.Standard;

namespace GMSBackend.Models
{
    public class AccTransactionViewModel : AccTransaction
    {
        public string create_date_fa    
        {
            get
            {
                var str = new PersianDateTime(create_date);
                return str.ToString();
            }
        }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string title { get; set; }
        public string mobile { get; set; }
        public string account_type_title { get; set; }
        public string user_name { get; set; }

    }
}