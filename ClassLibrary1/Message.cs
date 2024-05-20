using SERP.Framework.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProjectAPI.Entities
{
	[Table("Messages")]
	public class Message : BaseEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }
		[Required]
		public Guid RoomChatId { get; set; }
		[Required]
		public Guid SenderId { get; set; }
		public string Content { get; set; }
	}
}
