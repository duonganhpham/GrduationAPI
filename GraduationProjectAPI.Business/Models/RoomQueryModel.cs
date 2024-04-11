using Microsoft.AspNetCore.Http;
using SERP.Framework.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationProjectAPI.Business.Models
{
	public class RoomQueryModel : PaginationRequest
	{
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
		[StringLength(20)] public string Tag { get; set; }
		public List<IFormFile> Images { get; set; }
	}
}
