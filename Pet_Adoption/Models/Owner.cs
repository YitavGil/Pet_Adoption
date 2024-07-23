using System.ComponentModel.DataAnnotations;

namespace Pet_Adoption.Models
{
	public class Owner
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(100, MinimumLength = 2)]
		[Display(Name = "שם")]
		public string Name { get; set; }

		[Required]
		[Phone]
		[Display(Name = "מספר טלפון")]
		public string PhoneNumber { get; set; }

		public List<Pet> Pets { get; set; } = new List<Pet>();
	}
}