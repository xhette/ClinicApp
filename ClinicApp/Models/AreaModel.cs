using ClinicData.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClinicApp.Models
{
	public class AreaModel
	{
		public int Id { get; set; }

		[Display(Name = "Название")]
		[Required(ErrorMessage = "Введите название участка")]
		public string Name { get; set; }

		public AreaModel() { }

		public AreaModel(Area db)
		{
			Id = db.Id;
			Name = db.Name;
		}
	}
}
