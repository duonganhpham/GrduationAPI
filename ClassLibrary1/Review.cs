using SERP.Framework.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProjectAPI.Entities
{
	[Table("Reviews")]
	public class Review : BaseEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }
		public string content { get; set; }
		[Required]
		public Guid RoomId { get; set; }
		[Required]
		public Guid UserId { get; set; }
		public byte Star { get; set; }
	}
}
