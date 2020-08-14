using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicData.HistoryWorks
{
	public interface IHistoryWork
	{
		void GetElements(int current, DateTime time);

		int Undone();

		int Redone();
	}
}
