using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BookApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Database Connection String
            services.AddDbContext<BookDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("LocalBookDB"));
            });

            // Adding MVC
            services.AddMvc();

            // Author
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            // Book
            services.AddScoped<IBookRepository, BookRepository>();
            // Category
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            // Country
            services.AddScoped<ICountryRepository, CountryRepository>();
            // Review
            services.AddScoped<IReviewRepository, ReviewRepository>();
            // Reviewer
            services.AddScoped<IReviewerRepository, ReviewerRepository>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // Seeding Database with Dummy Data
            // context.SeedDataContext();

            
            // MVC Endpoints Configuration
                app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute( 
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{:id?}"
                    );
            }); 
            
        }
    }
}
