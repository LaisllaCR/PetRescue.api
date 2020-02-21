using System;
using System.Collections.Generic;

namespace PetRescue.api.Models
{
    public partial class Size
    {
        public Size()
        {
            Pet = new HashSet<Pet>();
        }

        public int SizeId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Pet> Pet { get; set; }
    }
}
