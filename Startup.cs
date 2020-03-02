using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductCatalog.Data;

namespace ProductCatalog
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore(option => option.EnableEndpointRouting = false).AddNewtonsoftJson();
            services.AddScoped<StoreDataContext, StoreDataContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseMvc();            
            //app.UseEndpoints(endpoints =>
            //{
              //  endpoints.MapGet("/", async context =>
                //{
                  //  await context.Response.WriteAsync("Hello World!");
               // });
                //endpoints.MapGet("/id",async context => {
                //    await context.Response.WriteAsync("<a href='github.com/edwilsoncruz'>Edwilson Cruz</a>");
                //});
           // });
        }
    }
}
