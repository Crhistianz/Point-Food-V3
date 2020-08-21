using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PointFood.Model.Identity;
using PointFood.Persistence;
using PointFood.Service;
using PointFood.Service.Impl;

namespace PointFood
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API PointFood",
                    Version = "v1",
                    Description = "API PointFood del curso Aplicaciones Web con NetCore",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Grupo 3 - PointFood",
                        Email = "grupo3-PointFoood@upc.edu.pe",
                        Url = new Uri("https://github.com/RafaelAnderson/Point-Food"),
                    }
                });
            });


            services.AddControllers();
            services.AddDbContext<ApplicationDbContext>(
                opts => opts.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))
                );

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            });

            services.AddAutoMapper(typeof(Startup));
            services.AddTransient<ICardService, CardServiceImpl>();
            services.AddTransient<ICategoryService, CategoryServiceImpl>();
            services.AddTransient<IClientService, ClientServiceImpl>();
            services.AddTransient<IProductService, ProductServiceImpl>();
            services.AddTransient<IProductTypeService, ProductTypeServiceImpl>();
            services.AddTransient<IOrderService, OrderServiceImpl>();
            services.AddTransient<IRestaurantOwnerService, RestaurantOwnerServiceImpl>();
            services.AddTransient<IRestaurantService, RestaurantServiceImpl>();
            services.AddTransient<IStateService, StateServiceImpl>();
            services.AddTransient<IUserService, UserServiceImpl>();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder =>
                    builder.AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowAnyOrigin()
                );
            });

            var key = Encoding.ASCII.GetBytes(
              Configuration.GetValue<string>("SecretKey")
            );

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Point Food V1");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowSpecificOrigin");

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
