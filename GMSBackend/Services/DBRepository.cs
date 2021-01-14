using GMSBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace GMSBackend.Services
{
    public class DBRepository : DbContext
    {
        public DBRepository(DbContextOptions<DBRepository> options) : base(options) { }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<MembershipJoinType> MembershipJoinTypes { get; set; }
        public DbSet<JobInfo> JobInfos { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ClientPeriodicCheckUp> ClientPeriodicCheckUps { get; set; }
        public DbSet<ProductMain> ProductMains { get; set; }
        public DbSet<ProductCodingInfo> ProductCodingInfos { get; set; }
        public DbSet<SaleInvoiceHeader> SaleInvoiceHeaders { get; set; }
        public DbSet<SaleInvoiceDetails> SaleInvoiceDetails { get; set; }
            
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();

            modelBuilder.Entity<ClientPeriodicCheckUp>().Property(e => e.CreateDate)
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("NOW()")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ProductMain>().Property(e => e.CreateDate)
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("NOW()")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ProductCodingInfo>().Property(e => e.CreateDate)
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("NOW()")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<SaleInvoiceHeader>().Property(e => e.CreateDate)
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("NOW()")
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<SaleInvoiceDetails>().Property(e => e.CreateDate)
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("NOW()")
                .ValueGeneratedOnAdd();

        }
    }
}
