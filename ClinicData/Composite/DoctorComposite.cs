using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicData.Entities;
using ClinicDb.Entities;

namespace ClinicData.Composite
{
	public class DoctorComposite
	{
		public Doctor Doctor { get; set; }

		public Speciality Speciality { get; set; }

		public User User { get; set; }

		public DoctorComposite()
		{
			Doctor = new Doctor();
			Speciality = new Speciality();
			User = new User();
		}

		public DoctorComposite(DbDataRecord rec)
		{
			Doctor = new Doctor (rec);
			Speciality = new Speciality (rec);
			User = new User(rec);
		}
	}
}
