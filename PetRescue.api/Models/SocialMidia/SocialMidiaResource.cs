using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models
{
    public class SocialMidiaResource
    {
        public SocialMidiaResource()
        {

        }
        public SocialMidiaResource(SocialMidia socialMidia)
        {
            SocialMidiaId = socialMidia.SocialMidiaId;
            Description = socialMidia.Description;
        }

        public int SocialMidiaId { get; set; }
        public string Description { get; set; }
    }
}
