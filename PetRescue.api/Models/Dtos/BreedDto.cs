﻿using System;
using System.ComponentModel.DataAnnotations;

namespace PetRescue.api.Models
{
    public class BreedDto
    {

        public BreedDto()
        {
        }
        public int BreedId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        [Required]
        public int SpecieId { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Description { get; set; }  

    }
}
