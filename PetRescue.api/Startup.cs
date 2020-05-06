using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PetRescue.api.Authentication;
using PetRescue.api.Models;
using PetRescue.api.Models.Interfaces;
using PetRescue.api.Models.Repositories;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.OpenApi.Models;

namespace PetRescue.api
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
            #region DBContext

            services.AddDbContext<dbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            #endregion

            services.AddCors();
            services.AddControllers();

            #region Authentication API

            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var apiSettingsSection = Configuration.GetSection("APISettings");
            services.Configure<APISettings>(apiSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var symmetricKey = Encoding.ASCII.GetBytes(appSettings.Secret);

            APISettings tokenConfigurations = Configuration.GetSection("APISettings").Get<APISettings>();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,
                      ValidIssuer = tokenConfigurations.Issuer,
                      ValidAudience = tokenConfigurations.Audience,
                      IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
                  };
            });

            #endregion

            #region Swagger

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Pet Rescue API",
                    Description = "API to consume info about missing PETs",
                    Contact = new OpenApiContact
                    {
                        Name = "Laislla Ramos",
                        Email = "laisllaramos@gmail.com",
                    }
                });
                //Set the comments path for the Swagger JSON and UI.

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            #endregion

            services.AddScoped<IAppClientRepository, AppClientRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();

            app.UseRouting();
            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseSwagger(); 
            
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pet Rescue V1");
                c.RoutePrefix = string.Empty;
            });
            /*
            var option = new RewriteOptions();
            option.AddRedirect("^$", "index.html");

            app.UseRewriter(option);
            */

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute().RequireAuthorization();
            });
        }
    }
}
