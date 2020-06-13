using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClinicData.Composite;

namespace ClinicApp.Models
{
	public class RegisterPatientModel
	{
		public PatientModel Patient { get; set; }

		public UserModel User { get; set; }

		public List<StreetModel> Streets { get; set; }

		public RegisterPatientModel()
		{
			Patient = new PatientModel();
			User = new UserModel();
			Streets = new List<StreetModel>();
		}

		public RegisterPatientModel (PatientComposite db)
		{
			Patient = new PatientModel(db.Patient);
			User = new UserModel(db.User);
			Streets = new List<StreetModel>();
		}
	}
}