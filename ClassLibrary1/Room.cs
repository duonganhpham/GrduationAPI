using SERP.Framework.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraduationProjectAPI.Entities
{
	[Table("Rooms")]
	public class Room : BaseEntity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }
		public Guid RomOwnerId { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string Type { get; set; }
		public float Area { get; set; }
		public float Price { get; set; }
        public Boolean WifiInternet { get; set; }
        public Boolean AirConditioner { get; set; }
        public Boolean WaterHeater { get; set; }
        public Boolean Refrigerator { get; set; }
        public Boolean WashingMachine { get; set; }
        public Boolean EnclosedToilet { get; set; }
        public Boolean SafedDevice { get; set; }
        public float ElectronicPrice { get; set; }
        public float WaterPrice { get; set; }
        public string Description { get; set; }
	}
}
