using Contactlist.Contacts.Data;
using Contactlist.Contacts.Data.Interfaces;
using Contactlist.Contacts.RepoSitories;
using Contactlist.Contacts.RepoSitories.Interfaces;
using Contactlist.Contacts.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace Contactlist.Contacts
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

        

            services.Configure<ContactDatabaseSettings>(Configuration.GetSection(nameof(ContactDatabaseSettings)));
            services.AddSingleton<IContactDatabaseSettings>(sp => sp.GetRequiredService<IOptions<ContactDatabaseSettings>>().Value); 
            services.AddTransient<IContactContext, ContactContext>();
            services.AddTransient<IContactRepository, ContactRepository>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Contactlist.Contacts", Version = "v1" });
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c=>c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contactlist.Contacts v1"));
                
            }


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
