using System;
using System.Reflection;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using OnlineShop.Api.Services.Interfaces;
using OnlineShop.Api.Services.Classes;
using OnlineShop.Api.Helpers;
using OnlineShop.Bll.Repositories.Interfaces;
using OnlineShop.Bll.Repositories.Implementation;
using OnlineShop.Common;

namespace OnlineShop.Api
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
            services.AddDbContext<OnlineShopAlphaContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();

            var appSettingsSection = Configuration.GetSection("JwtSettings");
            services.Configure<JwtSettings>(appSettingsSection);

            // configure jwt service
            var jwtSettings = appSettingsSection.Get<JwtSettings>();
            var key = Encoding.ASCII.GetBytes(jwtSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
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

            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IItemsService, ItemsService>();
            services.AddScoped<IProductsService, ProductsService>();
            services.AddSingleton<IUserManagementBLL, UserManagementBLL>();
            services.AddSingleton<IAddressManagementBLL, AddressManagementBLL>();
            services.AddSingleton<IItemsManagementBLL, ItemsManagementBLL>();
            services.AddSingleton<IProductManagementBLL, ProductManagementBLL>();

            services.AddCors(o => o.AddPolicy("FrontPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            services.AddSwaggerGen(setupAction =>
            {
                setupAction.SwaggerDoc(
                    "OnlineShopOpenApiSpecification",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "Online Shop Api",
                        Version = "3",
                        Description = "Through this API you can access to users and products of the online shop.",
                        License = new Microsoft.OpenApi.Models.OpenApiLicense()
                        {
                            Name = "MIT License",
                            Url = new Uri("https://opensource.org/licenses/MIT")
                        }
                    });

                var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

                setupAction.IncludeXmlComments(xmlCommentsFullPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint(
                    "/swagger/OnlineShopOpenApiSpecification/swagger.json",
                    "Online Shop Api");
                setupAction.RoutePrefix = "";
            });

            app.UseRouting();

            app.UseCors("FrontPolicy");

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}