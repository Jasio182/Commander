using Commander.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Commander
{
    public class Startup
    {
        // Getting access to config file.
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // Frameworks installed from NuGet via Terminal.
        public void ConfigureServices(IServiceCollection services)
        {
            // Configuration of a DbContext for use in the rest of application. Dependecy Injection. 
            // After that using ef: "dotnet ef migrations add InitialMigration" - created migration files, to create table and database.
            services.AddDbContext<CommanderContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("CommanderConnection")));

            // Makes AutoMapper avaliable by Dependency Injection for the rest of application.
            // Used to decouple internal domain from what is send and recived.
            // Sets up DTO (Data Transfer Object) - this can be done manually, but this is easier.
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers();
            // Registration of a Dependency Injection for API.
            // services.AddScoped<ICommanderRepo, MockCommanderRepo>(); not used anymore
            services.AddScoped<ICommanderRepo, SqlCommanderRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
