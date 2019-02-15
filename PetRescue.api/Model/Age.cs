using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Model
{
    [Table("age")]
    public class Age
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }

        [Column("age")]
        public string Name { get; set; }
    }
}
