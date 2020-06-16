using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicData.Entities;

namespace ClinicData.Composite
{
	public class ReceptionComposite
	{
		public Reception Reception { get; set; }

		public Shedule Shedule { get; set; }

		public Doctor Doctor { get; set; }

		public Patient Patient { get; set; }

		public ReceptionComposite()
		{
			Reception = new Reception();
			Shedule = new Shedule();
			Doctor = new Doctor();
			Patient = new Patient();
		}

		public ReceptionComposite (DbDataRecord rec)
		{
			Reception = new Reception(rec);
			Shedule = new Shedule(rec);
			Doctor = new Doctor(rec);
			Patient = new Patient(rec);
		}
	}
}
