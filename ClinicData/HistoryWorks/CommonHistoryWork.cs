using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicData.History;
using ClinicData.HistoryBase;
using ClinicData.HistoryBase.Enums;

namespace ClinicData.HistoryWorks
{
	public class CommonHistoryWork <T> where T : HistoryTable
	{
		private int currentStep;

		private DateTime currentDateTime;

		List<T> historyTable;

		public CommonHistoryWork (int current, DateTime time, List<T> history)
		{
			history = new List<T>();

			currentStep = current;
			currentDateTime = time;
			historyTable = history;
		}

		public int Undone(IBaseHistory<T> baseHistory)
		{
			int returnStep = currentStep;

			if (currentStep < historyTable.Count)
			{
				T historyRecord = historyTable[currentStep];

				switch (historyRecord.Operation)
				{
					case "INSERT":
						baseHistory.Delete(historyRecord, DoneStatusEnum.Undone);
						break;
					case "UPDATE":
						baseHistory.Update(historyRecord, DoneStatusEnum.Undone);
						break;
					case "DELETE":
						baseHistory.Insert(historyRecord, DoneStatusEnum.Undone);
						break;
					default: break;
				}
			}

			return returnStep;
		}

		public int Redone(IBaseHistory<T> baseHistory)
		{
			int returnStep = currentStep;

			T historyRecord = historyTable[currentStep];

			if (currentStep > 0)
			{
				switch (historyRecord.Operation)
				{
					case "INSERT":
						baseHistory.Insert(historyRecord, DoneStatusEnum.Redone);
						break;
					case "UPDATE":
						baseHistory.Update(historyRecord, DoneStatusEnum.Redone);
						break;
					case "DELETE":
						baseHistory.Delete(historyRecord, DoneStatusEnum.Redone);
						break;
					default: break;
				}
			}

			return returnStep;
		}
	}
}
