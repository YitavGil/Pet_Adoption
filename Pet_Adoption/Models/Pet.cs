using Pet_Adoption.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pet_Adoption.Models
{
	public class Pet
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(100, MinimumLength = 2)]
		[Display(Name = "שם")]
		public string Name { get; set; }

		[Required]
		[Display(Name = "סוג")]
		public string Type { get; set; }

		[Display(Name = "גיל")]
		[Range(0, 30)]
		public int Age { get; set; }

		[ForeignKey("Owner")]
		public int OwnerId { get; set; }
		public Owner Owner { get; set; }

		public List<PetImage> Images { get; set; } = new List<PetImage>();

		[NotMapped]
		[Display(Name = "הוספת תמונה")]
		public IFormFile SetImage { get; set; }

		public void AddImage(IFormFile image)
		{
			if (image == null) return;

			using var stream = new MemoryStream();
			image.CopyTo(stream);
			Images.Add(new PetImage { Data = stream.ToArray(), Pet = this });
		}
	}
}