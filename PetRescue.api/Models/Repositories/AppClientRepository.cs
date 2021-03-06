﻿using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using PetRescue.api.Authentication;
using PetRescue.api.Model.DAL.Repositories;
using PetRescue.api.Models.Interfaces;
using PetRescue.api.Models.Dtos.AppClient;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PetRescue.api.Models.Repositories
{
    public class AppClientRepository : IAppClientRepository
    {
        private readonly AppSettings AppSettings;
        private readonly APISettings APISettings;
        private readonly dbContext _context;

        public AppClientRepository(dbContext context, IOptions<AppSettings> appSettings, IOptions<APISettings> apiSettings)
        {
            AppSettings = appSettings.Value;
            APISettings = apiSettings.Value;
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public TokenDto Authenticate(AppClientDto resource)
        {
            try
            {
                //TODO: Check if exist app client at DB

                TokenDto tokenResource = new TokenDto();

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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
