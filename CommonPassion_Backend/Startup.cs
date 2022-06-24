namespace CommonPassion_Backend
{
    using CommonPassion_Backend.Migrations;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using CommonPassion_Backend.Infrastrcture;
    using MediatR;
    using CommonPassion_Backend.Mediator.Queries.ReactionQueries;
    using Azure.Storage.Blobs;

    public class Startup
    {
        public Startup(IConfiguration configuration) => this.Configuration = configuration;

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {

            var appSettings = this.Configuration.GetAppSetings(services);
            var apiSettings = this.Configuration.GetApiConfigSettings(services);

            var azureConnectionString = this.Configuration.GetValue<string>("AzureBlobStorageConnectionString");
            services.AddSingleton(x => new BlobServiceClient(azureConnectionString));

            services.AddHttpClient();
            services.AddAuthorization();
            services.AddControllers();
            services.AddAutoMapper(typeof(Program));
            services.AddMediatR(typeof(GetLikesQuery));
            services.AddDbContext<CommonPassionDbContext>(options => options
             .UseSqlServer(this.Configuration.GetDefaultConnectionString()))
                    .AddIdentity()
                    .AddJwtAuthentication(appSettings)
                    .AddAplicationServices()
                    .AddSwagger()
                    .AddCache(this.Configuration);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            
            app.UseHttpsRedirection()
               .UseStaticFiles()
               .UseSwagger()
               .UseSwaggerUI(c=>
               {
           
                   c.SwaggerEndpoint("/swagger/v1/swagger.json", "CommonPassion");
                   c.RoutePrefix = string.Empty;
               
               })
               .UseRouting()
               .UseCors(options => options
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod())
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");
                })
                .ApplyMigrations();

        }
    }
}
