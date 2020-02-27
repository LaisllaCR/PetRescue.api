using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models
{
    public class BreedResource
    {

        public BreedResource()
        {
        }

        public BreedResource(Breed breed)
        {
            BreedId = breed.BreedId;
            SpecieId = breed.SpecieId;
            Description = breed.Description;
        }

        public int BreedId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        [Required]
        public int SpecieId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Description { get; set; }  

    }
}
