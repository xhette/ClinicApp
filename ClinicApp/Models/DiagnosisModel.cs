using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClinicData.Entities;

namespace ClinicApp.Models
{
	public class DiagnosisModel
	{
		public int Id { get; set; }

		public string Code { get; set; }

		public string Description { get; set; }

		public DiagnosisModel () { }

		public DiagnosisModel (Diagnosis diagnosis)
		{
			Id = diagnosis.Id;
			Code = diagnosis.Code;
			Description = diagnosis.Description;
		}
	}
}