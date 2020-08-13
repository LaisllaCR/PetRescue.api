using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models
{
    public class ColorDto
    {
        public ColorDto()
        {

        }

        public ColorDto(Color color)
        {
            ColorId = color.ColorId;
            Description = color.Description;
        }
        public int ColorId { get; set; }
        public string Description { get; set; }

    }
}
