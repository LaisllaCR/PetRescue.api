using System;
using System.Collections.Generic;

namespace PetRescue.api.Models
{
    public partial class PetPhoto
    {
        public int PetPhotoId { get; set; }
        public int PetId { get; set; }
        public string Description { get; set; }
        public string FileUrl { get; set; }
        public string FileExtension { get; set; }
    }
}
