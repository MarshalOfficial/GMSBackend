using GMSBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace GMSBackend.Services
{
    public class DBRepository : DbContext
    {
        public DBRepository(DbContextOptions<DBRepository> options) : base(options) { }
        public DbSet<AccountType> account_types { get; set; }
        public DbSet<MembershipJoinType> membership_join_types { get; set; }    
        public DbSet<JobInfo> job_infos { get; set; }   
        public DbSet<Account> accounts { get; set; }    
        public DbSet<UserRole> user_roles { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<ClientPeriodicCheckUp> client_periodic_checkups { get; set; }  
        public DbSet<Product> product { get; set; }
        public DbSet<ProductCodingInfo> product_coding_infos { get; set; }  
        public DbSet<SaleInvoiceHeader> sale_invoice_headers { get; set; }  
        public DbSet<SaleInvoiceDetails> sale_invoice_details { get; set; } 
        public DbSet<SaleInvoicePayment> sale_invoice_payments { get; set; }    
        public DbSet<SaleInvoicePaymentType> sale_invoice_payment_types { get; set; }
        public DbSet<AccTransaction> acc_transactions { get; set; }
        public DbSet<ClientSessionUsageLog> client_session_usage_log { get; set; }      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder.Entity<User>()
                .HasIndex(u => u.user_name)
                .IsUnique();

            modelBuilder.Entity<ClientPeriodicCheckUp>().Property(e => e.create_date)
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("NOW()")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Product>().Property(e => e.create_date)
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("NOW()")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ProductCodingInfo>().Property(e => e.create_date)
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("NOW()")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<SaleInvoiceHeader>().Property(e => e.create_date)
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("NOW()")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<SaleInvoiceDetails>().Property(e => e.create_date)
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("NOW()")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<AccTransaction>().Property(e => e.create_date)
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("NOW()")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ClientSessionUsageLog>().Property(e => e.create_date)
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("NOW()")
                .ValueGeneratedOnAdd();

        }
    }
}
