using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRest.Modelos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ApiRest
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
            services.AddDbContext<ApplicationDbContex>(options => options.UseInMemoryDatabase("prueba"));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ApplicationDbContex db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();

            // Inicialización de Datos
            if (!db.Computers.Any())
            {
                db.Computers.AddRange(new List<Computer>()
                {
                    new Computer(){memory = 8, processor = 1, diskType = 1 },
                    new Computer(){memory = 8, processor = 2, diskType = 1 },
                    new Computer(){memory = 8, processor = 3, diskType = 1 },
                    new Computer(){memory = 8, processor = 4, diskType = 1 }
                });
                db.SaveChanges();

            }
        }
    }
}
