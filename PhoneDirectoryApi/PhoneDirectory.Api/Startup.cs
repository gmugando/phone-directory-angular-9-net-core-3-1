using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhoneDirectory.Data.Domain.Repositories;
using PhoneDirectory.Data.Domain.Services;
using PhoneDirectory.Data.Persistence.Context;
using PhoneDirectory.Data.Persistence.Repositories;
using PhoneDirectory.Data.Services;

namespace PhoneDirectoryApi
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
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.AddControllers();

            //services.AddDbContext<PhoneBookContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<PhoneBookContext>(options => options.UseSqlServer(connection));
            //services.AddDbContext<PhoneBookContext>();

            services.AddScoped<IPhoneBookRepository, PhoneBookRepository>();
            services.AddScoped<IEntryRepository, EntryRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IPhoneBookService, PhoneBookService>();
            services.AddScoped<IEntryService, EntryService>();

            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

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
