namespace CommonPassion_Backend.Migrations
{
    using CommonPassion_Backend.Entities;
    using CommonPassion_Backend.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class CommonPassionDbContext : IdentityDbContext<User>
    {
        public CommonPassionDbContext(DbContextOptions<CommonPassionDbContext> options)
            :base(options)
        {

        }
    }
}
