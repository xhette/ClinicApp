using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ClinicData.Entities;

namespace ClinicApp.Models
{
	public class ScheduleModel
	{
		public int Id { get; set; }

		public DateTime Date { get; set; }

		public DateTime StartTime { get; set; }

		public DateTime EndTime { get; set; }

		public int Doctor { get; set; }

		public List<ReceptionModel> Receptions { get; set; }

		public ScheduleModel () 
		{
			Receptions = new List<ReceptionModel>();
		}

		public ScheduleModel(Shedule db)
		{
			Receptions = new List<ReceptionModel>();

			Id = db.Id;
			Date = db.Date;
			StartTime = db.StartTime;
			EndTime = db.EndTime;
			Doctor = db.Doctor;
		}
	}
}