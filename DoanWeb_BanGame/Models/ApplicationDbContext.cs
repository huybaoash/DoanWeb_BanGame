using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DoanWeb_BanGame.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Chức vụ")]

        public string Role { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
           
            public DbSet<Bill> Bills { get; set; }
            public DbSet<BillDetail> BillDetails { get; set; }
            public DbSet<Game> Games { get; set; }
            public DbSet<Producer> Producers { get; set; }
            public DbSet<Publisher> Publishers { get; set; }
            public DbSet<Sale> Sales { get; set; }

            public DbSet<TypeGame> TypeGames { get; set; }

            public DbSet<TypeGameDetails> TypeGameDetails { get; set; }

            public ApplicationDbContext()
                : base("DefaultConnection", throwIfV1Schema: false)
            {
            }

            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Bill>().HasRequired(c => c.Customer)
                    .WithMany()
                    .WillCascadeOnDelete(false);
                base.OnModelCreating(modelBuilder);
            }

        
    }
    
}