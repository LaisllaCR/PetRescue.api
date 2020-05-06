using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetRescue.api.Models.Migration
{
    public class Initializer
    {
		public static void Initialize(dbContext context)
		{
			context.Database.EnsureCreated();

			if (context.Specie.Any())
			{
				return;
			}

			var species = new Specie[]
			{
				new Specie    { SpecieId = 1, Description  = "Feline"  },
				new Specie    { SpecieId = 2, Description  = "Canine"  },
			};

			foreach (Specie specie in species)
			{
				context.Specie.Add(specie);
			}

			context.SaveChanges();
		}

	}
}
