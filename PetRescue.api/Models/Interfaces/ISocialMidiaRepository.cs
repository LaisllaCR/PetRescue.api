using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Interfaces
{
    public interface ISocialMidiaRepository
    {
        IEnumerable<SocialMidiaDto> GetSocialMidias();
        SocialMidiaDto GetSocialMidiaByID(int id);
        void InsertSocialMidia(SocialMidiaDto socialMidia);
        void DeleteSocialMidia(int id);
        void UpdateSocialMidia(SocialMidiaDto socialMidia);
        void Save();
        bool SocialMidiaExists(int id);
    }
}
