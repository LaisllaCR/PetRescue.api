using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models
{
    public class SocialMidiaDto
    {
        public SocialMidiaDto()
        {

        }
        public SocialMidiaDto(SocialMidia socialMidia)
        {
            SocialMidiaId = socialMidia.SocialMidiaId;
            Description = socialMidia.Description;
        }

        public int SocialMidiaId { get; set; }
        public string Description { get; set; }
    }
}
