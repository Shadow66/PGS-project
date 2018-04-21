using AutoMapper;
using LetsMeet.BL.Interfaces;
using LetsMeet.BL.Services;
using LetsMeet.DA;
using LetsMeet.DA.Dto;
using LetsMeet.DA.Interfaces;
using LetsMeet.DA.Models;
using LetsMeet.DA.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System.Text;
using System.Threading.Tasks;

namespace LetsMeet.Api
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
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            services.AddTransient<ITestService, TestService>();
            services.AddTransient<ITestRepository, TestRepository>();

            services.AddTransient<IAuthorizeService, AuthorizeService>();
            services.AddTransient<IAuthorizeRepository, AuthorizeRepository>();


            services.AddTransient<IFindEventsService, FindEventsService>();
            services.AddTransient<IFindEventsRepository, FindEventsRepository>();

            services.AddTransient<IDbInitializerService, DbInitializerService>();
            services.AddTransient<IDbInitializer, DbInitializer>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "LetsMeet.Api", Version = "v1" });
            });

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
                options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
            });

            services.AddMvc();
            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("CorsPolicy");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

        

            // app.UseIdentity();
            app.UseStaticFiles();

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
