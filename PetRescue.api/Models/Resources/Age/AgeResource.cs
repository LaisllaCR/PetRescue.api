using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models
{
    public class AgeResource
    {
        public AgeResource()
        {

        }

        public AgeResource(Age age)
        {
            AgeId = age.AgeId;
            Description = age.Description;
        }

        public int AgeId { get; set; }
        public string Description { get; set; }
    }
}
