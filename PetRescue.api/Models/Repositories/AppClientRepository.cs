using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using PetRescue.api.Authentication;
using PetRescue.api.Model.DAL.Repositories;
using PetRescue.api.Models.Interfaces;
using PetRescue.api.Models.Resources.AppClient;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PetRescue.api.Models.Repositories
{
    public class AppClientRepository : Repository<AppClientResource>, IAppClientRepository
    {
        private readonly AppSettings AppSettings;
        private readonly APISettings APISettings;

        public AppClientRepository(dbContext context, IOptions<AppSettings> appSettings, IOptions<APISettings> apiSettings) : base(context)
        {
            AppSettings = appSettings.Value;
            APISettings = apiSettings.Value;
        }

        public dbContext dbContext
        {
            get { return Context as dbContext; }
        }

        public TokenResource Authenticate(AppClientResource resource)
        {
            try
            {
                //TODO: Check if exist app client at DB

                TokenResource tokenResource = new TokenResource();

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(AppSettings.Secret); 
                var tokenExpirationDate = DateTime.UtcNow.AddMinutes(60);
                IdentityModelEventSource.ShowPII = true;

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, "PetRescueAPI") //TODO: replace for user id
                    }),
                    Expires = tokenExpirationDate,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                    Audience = APISettings.Audience,
                    Issuer = APISettings.Issuer
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                tokenResource.Token = tokenHandler.WriteToken(token);
                tokenResource.Expires = tokenExpirationDate;

                return tokenResource;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
