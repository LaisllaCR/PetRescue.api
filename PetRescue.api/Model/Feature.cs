using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Model
{
    [Table("feature")]
    public class Feature
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }

        [Column("feature")]
        public string Name { get; set; }
    }
}
