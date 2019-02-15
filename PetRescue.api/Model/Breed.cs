using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Model
{
    [Table("breed")]
    public class Breed
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }

        [Column("breed")]
        public string Name { get; set; }
    }
}
