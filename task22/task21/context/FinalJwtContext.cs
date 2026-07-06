using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using task21.Models;
namespace task21.context
{
    public class FinalJwtContext:IdentityDbContext
    {
        public FinalJwtContext(DbContextOptions<FinalJwtContext> options)
            : base(options)
        {
            
        }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

           
            builder.Entity<RefreshToken>()
                .HasOne(t => t.User)
                .WithMany(u => u.RefreshTokens)
                .HasForeignKey(t => t.UserId);
        }
    }
}
