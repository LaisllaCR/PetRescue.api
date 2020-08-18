using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models
{
    public class PetPhotoDto
    {
        public PetPhotoDto()
        {

        }

        public int PetPhotoId { get; set; }
        public int PetId { get; set; }
        public string File { get; set; }
    }
}
