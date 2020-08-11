using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models
{
    public class SpecieDto
    {
        public SpecieDto()
        {

        }

        public SpecieDto(Specie specie)
        {
            SpecieId = specie.SpecieId;
            Description = specie.Description;
        }

        public int SpecieId { get; set; }
        public string Description { get; set; }
    }
}
