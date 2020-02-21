﻿using System;
using System.Collections.Generic;

namespace PetRescue.api.Models
{
    public partial class PetCharacteristic
    {
        public int PetCharacteristicId { get; set; }
        public int CharacteristicId { get; set; }
        public int PetId { get; set; }

        public virtual Characteristics Characteristic { get; set; }
        public virtual Pet Pet { get; set; }
    }
}
