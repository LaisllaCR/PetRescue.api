using System;
using System.Collections.Generic;

namespace PetRescue.api.Models
{
    public partial class PetPhoto
    {
        public int PetPhotoId { get; set; }
        public int PetId { get; set; }
        public string File { get; set; }

        public virtual Pet Pet { get; set; }
    }
}
