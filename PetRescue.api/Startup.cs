using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PetRescue.api.Authentication;
using PetRescue.api.Model;
using PetRescue.api.Model.DAL.Interfaces;
using PetRescue.api.Model.DAL.Repositories;
using PetRescue.api.Models;
using PetRescue.api.Models.Interfaces;
using PetRescue.api.Models.Repositories;
using System;
using System.Text;

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
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

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

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute().RequireAuthorization();
            });
        }
    }
}
