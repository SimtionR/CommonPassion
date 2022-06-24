namespace CommonPassion_Backend.Migrations
{
    using CommonPassion_Backend.Data.Entities;
    using CommonPassion_Backend.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class CommonPassionDbContext : IdentityDbContext<User>
    {
        public CommonPassionDbContext(DbContextOptions<CommonPassionDbContext> options)
            :base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Connection> Connections { get; set; }
        public DbSet<ConnectionPending> ConnectionPendings { get; set; }
        public DbSet<ResponsePending> ResponsePendings { get; set; }
        public DbSet<Reactions> Reactions { get; set; }
        public DbSet<UserReview> UserReviews { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<LeagueDetails> LeagueDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasOne(u => u.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<Profile>(p => p.UserId);

            builder.Entity<UserReview>()
                .HasOne(u => u.Profile);
        }
    }


}
