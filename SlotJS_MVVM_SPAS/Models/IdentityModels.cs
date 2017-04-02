using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SlotJS_MVVM_SPAS.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
            public string PlayerName { get; set; }
            public int Credits { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class PlayerDb : IdentityDbContext<User>
    {
        public PlayerDb()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static PlayerDb Create()
        {
            return new PlayerDb();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("User").Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim").Property(p => p.Id).HasColumnName("UserClaimId");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles").Property(p => p.Id).HasColumnName("RoleId");

        }

       /// public DbSet<User> Players { get; set; }
    }
}