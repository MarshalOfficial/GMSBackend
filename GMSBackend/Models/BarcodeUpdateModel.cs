using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMSBackend.Models
{
    public class BarcodeUpdateModel
    {
        public long id { get; set; }

        public string rfid_barcode { get; set; }
    }
}
