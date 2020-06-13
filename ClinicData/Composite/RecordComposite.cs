using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicData.Entities;

namespace ClinicData.Composite
{
	public class RecordComposite
	{
		public Record Record { get; set; }

		public Diagnosis Diagnosis { get; set; }

		public RecordComposite()
		{
			Record = new Record();
			Diagnosis = new Diagnosis();
		}

		public RecordComposite(DbDataRecord rec)
		{
			Record = new Record(rec);
			Diagnosis = new Diagnosis(rec);
		}
	}
}
