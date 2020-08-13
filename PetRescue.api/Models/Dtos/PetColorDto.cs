﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models
{
    public class PetColorDto
    {
        public PetColorDto()
        {

        }

        public PetColorDto(PetColor petColor)
        {
            PetColorId = petColor.PetColorId;
            PetId = petColor.PetId;
            ColorId = petColor.ColorId;
        }

        public int PetColorId { get; set; }
        public int PetId { get; set; }
        public int ColorId { get; set; }
    }
}