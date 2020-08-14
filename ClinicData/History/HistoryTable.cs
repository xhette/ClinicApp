using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicData.History
{
	public class HistoryTable
	{
		public int Id { get; set; }

		public DateTime OperationDate { get; set; }

		public string Operation { get; set; }

		public HistoryTable() { }
	}
}
