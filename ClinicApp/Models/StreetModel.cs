using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ClinicData.Entities;

namespace ClinicApp.Models
{
	public class StreetModel
	{
		public int Id { get; set; }

		[Display(Name = "Название")]
		[Required(ErrorMessage = "Введите название улицы")]
		public string Name { get; set; }

		[Display(Name = "Участок")]
		[Required(ErrorMessage = "Выберите участок")]
		public int Area { get; set; }

		public List<AreaModel> AreasList { get; set; }

		public StreetModel() 
		{
			AreasList = new List<AreaModel>();
		}

		public StreetModel (Street db)
		{
			AreasList = new List<AreaModel>();

			Id = db.Id;
			Name = db.Name;
			Area = db.Area;
		}
	}
}