using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicData.Entities;

namespace ClinicData.Composite
{
	public class PatientComposite
	{
		public Patient Patient { get; set; }

		public Street Street { get; set; }

		public User User { get; set; }

		public PatientComposite()
		{
			Patient = new Patient();
			Street = new Street();
			User = new User();
		}

		public PatientComposite (DbDataRecord rec)
		{
			Patient = new Patient(rec);
			Street = new Street(rec);
			User = new User(rec);
		}
	}
}
