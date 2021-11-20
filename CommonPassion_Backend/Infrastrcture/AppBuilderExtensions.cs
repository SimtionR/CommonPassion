namespace CommonPassion_Backend.Infrastrcture
{
    using CommonPassion_Backend.Migrations;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class AppBuilderExtensions
    {

        public static void  ApplyMigrations(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();



            var dbContext = services.ServiceProvider.GetService<CommonPassionDbContext>();


            

            dbContext.Database.Migrate();
        }
        
    }
}
