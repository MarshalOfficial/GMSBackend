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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder.Entity<User>()
                .HasIndex(u => u.UserName)
                .IsUnique();

        }
    }
}
