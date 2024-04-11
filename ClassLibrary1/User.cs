using SERP.Framework.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProjectAPI.Entities

{
    [Table("Users")]
    public class User : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Uid { get; set; }


        [Required]
        [StringLength(255)]
        public string UserName { get; set; }
        [Required]
        public string PassWord { get; set; }
        public byte Role { get; set; }

        [StringLength(30)] public string AvatarUrl { get; set; }

        [StringLength(30)] public string PhoneNumber { get; set; }

        [StringLength(10)] public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        [StringLength(30)] public string LastName { get; set; }

        [StringLength(30)] public string Name { get; set; }
    }
}
