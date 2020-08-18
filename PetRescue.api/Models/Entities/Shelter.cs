using System;
using System.Collections.Generic;

namespace PetRescue.api.Models
{
    public partial class Shelter
    {
        public int ShelterId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string EmailSecondary { get; set; }
        public string Phone { get; set; }
        public string PhoneSecondary { get; set; }
        public string UrlWebsite { get; set; }
    }
}
