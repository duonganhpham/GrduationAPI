﻿using SERP.Framework.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProjectAPI.Entities
{
	[Table("RoomImages")]
	public class RoomImage : BaseEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }
		[Required]
		public Guid RoomId { get; set; }
		public string ImageUrl { get; set; } 
	}
}
