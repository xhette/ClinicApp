using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicData.History;
using ClinicData.HistoryBase.Enums;

namespace ClinicData.HistoryBase
{
	public interface IBaseHistory <T> where T: HistoryTable
	{
		void Insert (T table, DoneStatusEnum done);

		void Update (T table, DoneStatusEnum done);

		void Delete (T table, DoneStatusEnum done);
	}
}
