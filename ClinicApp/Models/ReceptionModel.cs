using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ClinicData.Entities;

namespace ClinicApp.Models
{
	public class ReceptionModel
	{
		public int Id { get; set; }

		public DateTime Time { get; set; }

		public int? Patient { get; set; }

		public int Shedule { get; set; }

		public bool Available
		{
			get
			{
				if (Patient.HasValue && Patient.Value > 0)
				{
					return false;
				}
				else
				{
					return true;
				}
			}
		}

		public ReceptionModel () { }

		public ReceptionModel(Reception db) 
		{
			Id = db.Id;
			Time = db.Time;
			Patient = db.Patient;
			Shedule = db.Shedule;
		}
	}
}