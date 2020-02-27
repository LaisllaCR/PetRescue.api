using System;
using System.Collections.Generic;

namespace PetRescue.api.Models
{
    public partial class Color
    {
        public Color()
        {
            PetColor = new HashSet<PetColor>();
        }

        public int ColorId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PetColor> PetColor { get; set; }
    }
}
