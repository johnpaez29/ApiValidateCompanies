using LibraryCompanies.DataAccess;
using LibraryCompanies.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestValidacionEmpresas
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                              builder =>
                              {
                                  builder.WithOrigins("http://localhost:4200/");
                              });
            });

            services.AddControllers();
            AppSettings.ConnectionStringSql = Configuration.GetConnectionString("CompanyConnection");

            services.AddScoped<ICompanyData<Company>, CompanyRepository>()
                .AddScoped<ICompanyData<CompanyValidation>, CompanyValidationRepository>()
                .AddScoped<ICompanyData<InvalidateReason>, InvalidateReasonRepository>()
                .AddScoped<IValidationResponse, ValidationResponse>();

            services.AddDbContext<CompanyContext>(opt => opt.UseSqlServer(AppSettings.ConnectionStringSql));
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

            app.UseCors(MyAllowSpecificOrigins);
        }
    }
}
