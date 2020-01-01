using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyTodoListApi.Data;
using Microsoft.AspNetCore.Cors;
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
            services.AddDbContext<ToDoListDbContext>(options => 
                options.UseSqlServer("Server=.;Database=ToDoApp;Trusted_Connection=True;MultipleActiveResultSets= true;",
                providerOptions => providerOptions.EnableRetryOnFailure())); 
            services.AddControllers();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider DiProvider)
        {
            ServiceProviderContainer.Provider = DiProvider;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(builder => builder.AllowAnyOrigin());

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
