using System;

namespace PetRescue.api.Models.Dtos.AppClient
{
    public class TokenDto
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}
