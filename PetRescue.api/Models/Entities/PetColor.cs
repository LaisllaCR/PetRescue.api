using System;
using System.Collections.Generic;

namespace PetRescue.api.Models
{
    public partial class PetColor
    {
        public int PetColorId { get; set; }
        public int PetId { get; set; }
        public int ColorId { get; set; }
    }
}
