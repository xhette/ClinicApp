using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ClinicData.Entities;

namespace ClinicApp.Models
{
	public class RecordModel
	{
		public int Id { get; set; }

		[Required (ErrorMessage = "Выберите пациента")]
		public int Patient { get; set; }

		[Display(Name = "Диагноз")]
		[Required(ErrorMessage = "Выберите диагноз")]
		public int Diagnosis { get; set; }

		[Display(Name = "Лечение")]
		[Required(ErrorMessage = "Назначьте лечение")]
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