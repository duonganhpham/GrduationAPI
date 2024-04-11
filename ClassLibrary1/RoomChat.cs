using SERP.Framework.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProjectAPI.Entities
{
	[Table("RoomChat")]
	public class RoomChat : BaseEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }
		[Required]
		public Guid OwnerId { get; set; }
		[Required]
		public Guid RenterId { get; set; }
	}
}
