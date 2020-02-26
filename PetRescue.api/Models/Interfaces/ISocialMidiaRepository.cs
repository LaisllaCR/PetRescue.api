using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Interfaces
{
    public interface ISocialMidiaRepository
    {
        IEnumerable<SocialMidiaResource> GetSocialMidias();
        SocialMidiaResource GetSocialMidiaByID(int id);
        void InsertSocialMidia(SocialMidiaResource socialMidia);
        void DeleteSocialMidia(int id);
        void UpdateSocialMidia(SocialMidiaResource socialMidia);
        void Save();
        bool SocialMidiaExists(int id);
    }
}
