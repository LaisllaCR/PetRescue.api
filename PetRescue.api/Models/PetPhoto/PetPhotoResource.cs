using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models
{
    public class PetPhotoResource
    {
        public PetPhotoResource()
        {

        }

        public PetPhotoResource(PetPhoto petPhoto)
        {
            PetPhotoId = petPhoto.PetPhotoId;
            PetId = petPhoto.PetId;
            File = petPhoto.File;
        }

        public int PetPhotoId { get; set; }
        public int PetId { get; set; }
        public string File { get; set; }
    }
}
