using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyTodoListApi.Data;
using MyTodoListApi.Models;
using System;

namespace MyTodoListApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        // This method gets called by the runtime. Use this method to add services to the container.
       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddDbContext<ToDoListDbContext>(options=>
            options.UseSqlServer(Configuration.GetConnectionString("ToDoListDataBase"), options => options.EnableRetryOnFailure() ));

            services.AddIdentity<CurrentUser, IdentityRole>()
                .AddEntityFrameworkStores<ToDoListDbContext>()
                .AddDefaultTokenProviders();

            //ToDo: configure Cookie timeout


            //change redirect Url 
            services.ConfigureApplicationCookie(options => {
                options.LoginPath = "/auth/register";
                options.ExpireTimeSpan = TimeSpan.FromSeconds(15);

            });

            
            //configure password requirements
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 2;

            }

            );
            
            services.AddControllers();
           }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env )
        {

           
             
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseCors(builder => builder.AllowAnyOrigin());

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();
            app.UseRouting();
           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
