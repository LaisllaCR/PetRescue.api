using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Model
{
    [Table("hair")]
    public class Hair
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }

        [Column("hair")]
        public string Name { get; set; }
    }
}
