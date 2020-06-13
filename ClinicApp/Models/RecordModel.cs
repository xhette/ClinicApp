using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClinicData.Entities;

namespace ClinicApp.Models
{
	public class RecordModel
	{
		public int Id { get; set; }

		public int Patient { get; set; }

		public int Diagnosis { get; set; }

		public string Therapy { get; set; }

		public List<DiagnosisModel> Diagnoses { get; set; }

		public List<PatientModel> Patients { get; set; }

		public RecordModel() 
		{
			Diagnoses = new List<DiagnosisModel>();
			Patients = new List<PatientModel>();
		}

		public RecordModel (Record record)
		{
			Id = record.Id;
			Patient = record.Patient;
			Diagnosis = record.Diagnosis;
			Therapy = record.Therapy;

			Diagnoses = new List<DiagnosisModel>();
			Patients = new List<PatientModel>();
		}
	}
}