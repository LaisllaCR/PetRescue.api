using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Resources.AppClient
{
    public class TokenResource
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }
    }
}
