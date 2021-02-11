using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMSBackend.Entities
{
    public class ClientPeriodicCheckUp
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        public long account_id { get; set; }
      
        public double? height { get; set; }

        public double? weight { get; set; }

        public string img_url { get; set; }

        public double? waist_size { get; set; }

        public DateTime create_date { get; set; }

        public double? chest { get; set; }

        public double? abs { get; set; }

        public double? butt { get; set; }

        public double? right_arm { get; set; }

        public double? left_arm { get; set; }

        public double? right_thigh { get; set; }

        public double? left_thigh { get; set; }

        public double? right_calves { get; set; }

        public double? left_calves { get; set; }

        public bool is_deleted { get; set; }

        public int session_no { get; set; }  
    }
}
    