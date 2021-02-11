using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GMSBackend.Entities
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }


        public string title { get; set; }

        [Required]
        [StringLength(100)]
        public string first_name { get; set; }

        [Required]
        [StringLength(100)]
        public string last_name { get; set; }

        public DateTime? birth_date { get; set; }

        public bool? Gender { get; set; }

        public DateTime create_date { get; set; }

        [Required]
        [StringLength(100)]
        public string mobile { get; set; }

        public string tel { get; set; }

        public string postal_code { get; set; }

        public string email { get; set; }

        public string telegram { get; set; }

        public string instagram { get; set; }

        public string address { get; set; }

        public DateTime? join_date { get; set; }

        public long? referral { get; set; }

        public long? visitor_id { get; set; }
        public string full_name { get; set; }   
        public bool is_deleted { get; set; }

        public int account_type_id { get; set; }
        
        public int? membership_join_type_id { get; set; }
        
        public int? jobinfo_id { get; set; }

        public string contract_file_path { get; set; }

        public decimal balance { get; set; }    

    }   
}