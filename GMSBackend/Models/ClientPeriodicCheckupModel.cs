using GMSBackend.Entities;
using MD.PersianDateTime.Standard;

namespace GMSBackend.Models
{
    public class ClientPeriodicCheckupModel: ClientPeriodicCheckUp
    {
        public string CreateDateFa  
        {
            get
            {
                var str = new PersianDateTime(CreateDate);
                return str.ToString();
            }
        }
    }
}
