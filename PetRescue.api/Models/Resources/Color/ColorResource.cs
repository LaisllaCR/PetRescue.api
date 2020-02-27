﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models
{
    public class ColorResource
    {
        public ColorResource()
        {

        }

        public ColorResource(Color color)
        {
            ColorId = color.ColorId;
            Description = color.Description;
        }
        public int ColorId { get; set; }
        public string Description { get; set; }

    }
}