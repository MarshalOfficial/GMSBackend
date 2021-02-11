using GMSBackend.Entities;
using MD.PersianDateTime.Standard;

namespace GMSBackend.Models
{
    public class ClientPeriodicCheckupModel: ClientPeriodicCheckUp
    {
        public string create_date_fa    
        {
            get
            {
                var str = new PersianDateTime(create_date);
                return str.ToString();
            }
        }
    }
}
