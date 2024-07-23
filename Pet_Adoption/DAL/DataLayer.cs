using Microsoft.EntityFrameworkCore;
using Pet_Adoption.Models;

namespace Pet_Adoption.DAL
{
	public class DataLayer : DbContext
	{
		public DataLayer(DbContextOptions<DataLayer> options) : base(options)
		{
			Database.EnsureCreated();
			if (Pets.Count() == 0) Seed();
		}

		private void Seed()
		{
			// Seeding logic here
		}

		public DbSet<Owner> Owners { get; set; }
		public DbSet<Pet> Pets { get; set; }
		public DbSet<PetImage> PetImages { get; set; }
	}
}