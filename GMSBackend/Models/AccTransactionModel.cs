using System;

namespace GMSBackend.Models
{
    public class AccTransactionModel
    {
        public bool IsVariz { get; set; }

        public int AccountTypeID { get; set; }
        
        public long AccountID { get; set; }
        
        public decimal Price { get; set; }

        public string Description { get; set; }

        public long UserID { get; set; }

        public DateTime CreateDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}
