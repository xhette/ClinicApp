using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ClinicData.Composite;

namespace ClinicApp.Models
{
	public class ReceptionViewModel
	{
		public DoctorModel Doctor { get; set; }

		public PatientModel Patient { get; set; }

		public ScheduleModel Schedule { get; set; }

		public ReceptionModel Reception { get; set; }

		public ReceptionViewModel()
		{
			Doctor = new DoctorModel();
			Patient = new PatientModel();
			Schedule = new ScheduleModel();
			Reception = new ReceptionModel();
		}

		public ReceptionViewModel(ReceptionComposite rec)
		{
			Doctor = new DoctorModel(rec.Doctor);
			Patient = new PatientModel(rec.Patient);
			Schedule = new ScheduleModel(rec.Shedule);
			Reception = new ReceptionModel(rec.Reception);
		}
	}
}