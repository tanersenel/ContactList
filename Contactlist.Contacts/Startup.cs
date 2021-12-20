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

            services.AddControllers();

            services.Configure<ContactDatabaseSettings>(Configuration.GetSection(nameof(ContactDatabaseSettings)));
            services.AddSingleton<IContactDatabaseSettings>(sp => sp.GetRequiredService<IOptions<ContactDatabaseSettings>>().Value);
            services.AddTransient<IContactContext, ContactContext>();
            services.AddTransient<IContactRepository, ContactRepository>();


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
