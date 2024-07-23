using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pet_Adoption.Models
{
	public class PetImage
	{
		[Key]
		public int Id { get; set; }

		public byte[] Data { get; set; }

		[ForeignKey("Pet")]
		public int PetId { get; set; }
		public Pet Pet { get; set; }
	}
}