using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClinicData.Composite;

namespace ClinicApp.Models
{
	public class CaseRecordModel
	{
		public RecordModel Record { get; set; }

		public DiagnosisModel Diagnosis { get; set; }

		public CaseRecordModel()
		{
			Record = new RecordModel();
			Diagnosis = new DiagnosisModel();
		}

		public CaseRecordModel (RecordComposite record)
		{
			Record = new RecordModel(record.Record);
			Diagnosis = new DiagnosisModel(record.Diagnosis);
		}
	}
}