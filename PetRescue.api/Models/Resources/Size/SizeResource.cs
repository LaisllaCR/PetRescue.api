using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models
{
    public class SizeResource
    {
        public SizeResource()
        {

        }

        public SizeResource(Size size)
        {
            SizeId = size.SizeId;
            Description = size.Description;
        }

        public int SizeId { get; set; }
        public string Description { get; set; }
    }
}
