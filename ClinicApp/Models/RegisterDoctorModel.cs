using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClinicData.Composite;

namespace ClinicApp.Models
{
	public class RegisterDoctorModel
	{
		public DoctorModel Doctor { get; set; }

		public UserModel User { get; set; }

		public List<AreaModel> Areas { get; set; }

		public List<SpecialityModel> Specialities { get; set; }

		public RegisterDoctorModel()
		{
			Doctor = new DoctorModel();
			User = new UserModel();
			Areas = new List<AreaModel>();
			Specialities = new List<SpecialityModel>();
		}

		public RegisterDoctorModel (DoctorComposite db)
		{
			Doctor = new DoctorModel(db.Doctor);
			User = new UserModel(db.User);
			Areas = new List<AreaModel>();
			Specialities = new List<SpecialityModel>();
		}
	}
}