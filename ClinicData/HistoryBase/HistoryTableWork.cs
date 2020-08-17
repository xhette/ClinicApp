using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicData.Entities;
using ClinicData.HistoryBase.Enums;
using ClinicData.HistoryBase.TablesBaseHistory;
using ClinicData.HistoryWorks;

using ClinicDb.Entities;

namespace ClinicData.HistoryBase
{
	public static class HistoryTableWork
	{
		public static int AreasHistory (int current, DateTime time, DoneStatusEnum done)
		{
			string sql = String.Format("select * from {0} where operation_time < '{1}'", HistoryTableNamesEnum.areas_history, time);

			List<AreaHistory> history = new List<AreaHistory>();

			DbWork db = new DbWork();
			List<DbDataRecord> dbRecords = db.GetHistory(sql);

			foreach (var record in dbRecords)
			{
				history.Add(new AreaHistory(record));
			}

			history.Reverse();

			CommonHistoryWork<AreaHistory> common = new CommonHistoryWork<AreaHistory>(current, time, history);

			IBaseHistory<AreaHistory> baseHistory = new AreasBaseHistory();

			if (done == DoneStatusEnum.Undone)
			{
				return common.Undone(baseHistory);
			}
			else if (done == DoneStatusEnum.Redone)
			{
				return common.Redone(baseHistory);
			}
			else 
			{ 
				return -1; 
			}
		}
		public static int CaseRecordsHistory (int current, DateTime time, DoneStatusEnum done)
		{
			string sql = String.Format("select * from {0} where operation_time < '{1}'", HistoryTableNamesEnum.case_records_history, time);

			List<RecordHistory> history = new List<RecordHistory>();

			DbWork db = new DbWork();
			List<DbDataRecord> dbRecords = db.GetHistory(sql);

			foreach (var record in dbRecords)
			{
				history.Add(new RecordHistory(record));
			}

			history.Reverse();

			CommonHistoryWork<RecordHistory> common = new CommonHistoryWork<RecordHistory>(current, time, history);

			IBaseHistory<RecordHistory> baseHistory = new RecordBaseHistory();

			if (done == DoneStatusEnum.Undone)
			{
				return common.Undone(baseHistory);
			}
			else if (done == DoneStatusEnum.Redone)
			{
				return common.Redone(baseHistory);
			}
			else
			{
				return -1;
			}
		}
		public static int DiagnosisHistory (int current, DateTime time, DoneStatusEnum done)
		{
			string sql = String.Format("select * from {0} where operation_time < '{1}'", HistoryTableNamesEnum.diagnosis_history, time);

			List<DiagnosisHistory> history = new List<DiagnosisHistory>();

			DbWork db = new DbWork();
			List<DbDataRecord> dbRecords = db.GetHistory(sql);

			foreach (var record in dbRecords)
			{
				history.Add(new DiagnosisHistory(record));
			}

			history.Reverse();

			CommonHistoryWork<DiagnosisHistory> common = new CommonHistoryWork<DiagnosisHistory>(current, time, history);

			IBaseHistory<DiagnosisHistory> baseHistory = new DiagnosisBaseHistory();

			if (done == DoneStatusEnum.Undone)
			{
				return common.Undone(baseHistory);
			}
			else if (done == DoneStatusEnum.Redone)
			{
				return common.Redone(baseHistory);
			}
			else
			{
				return -1;
			}
		}
		public static int DoctorsHistory (int current, DateTime time, DoneStatusEnum done)
		{
			string sql = String.Format("select * from {0} where operation_time < '{1}'", HistoryTableNamesEnum.doctors_history, time);

			List<DoctorHistory> history = new List<DoctorHistory>();

			DbWork db = new DbWork();
			List<DbDataRecord> dbRecords = db.GetHistory(sql);

			foreach (var record in dbRecords)
			{
				history.Add(new DoctorHistory(record));
			}

			history.Reverse();

			CommonHistoryWork<DoctorHistory> common = new CommonHistoryWork<DoctorHistory>(current, time, history);

			IBaseHistory<DoctorHistory> baseHistory = new DoctorBaseHistory();

			if (done == DoneStatusEnum.Undone)
			{
				return common.Undone(baseHistory);
			}
			else if (done == DoneStatusEnum.Redone)
			{
				return common.Redone(baseHistory);
			}
			else
			{
				return -1;
			}
		}
		public static int PatientsHistory (int current, DateTime time, DoneStatusEnum done)
		{
			string sql = String.Format("select * from {0} where operation_time < '{1}'", HistoryTableNamesEnum.patients_history, time);

			List<PatientHistory> history = new List<PatientHistory>();

			DbWork db = new DbWork();
			List<DbDataRecord> dbRecords = db.GetHistory(sql);

			foreach (var record in dbRecords)
			{
				history.Add(new PatientHistory(record));
			}

			history.Reverse();

			CommonHistoryWork<PatientHistory> common = new CommonHistoryWork<PatientHistory>(current, time, history);

			IBaseHistory<PatientHistory> baseHistory = new PatientBaseHistory();

			if (done == DoneStatusEnum.Undone)
			{
				return common.Undone(baseHistory);
			}
			else if (done == DoneStatusEnum.Redone)
			{
				return common.Redone(baseHistory);
			}
			else
			{
				return -1;
			}
		}
		public static int ReceptionsHistory (int current, DateTime time, DoneStatusEnum done)
		{
			string sql = String.Format("select * from {0} where operation_time < '{1}'", HistoryTableNamesEnum.reception_history, time);

			List<ReceptionHistory> history = new List<ReceptionHistory>();

			DbWork db = new DbWork();
			List<DbDataRecord> dbRecords = db.GetHistory(sql);

			foreach (var record in dbRecords)
			{
				history.Add(new ReceptionHistory(record));
			}

			history.Reverse();

			CommonHistoryWork<ReceptionHistory> common = new CommonHistoryWork<ReceptionHistory>(current, time, history);

			IBaseHistory<ReceptionHistory> baseHistory = new ReceptionBaseHistory();

			if (done == DoneStatusEnum.Undone)
			{
				return common.Undone(baseHistory);
			}
			else if (done == DoneStatusEnum.Redone)
			{
				return common.Redone(baseHistory);
			}
			else
			{
				return -1;
			}
		}

		public static int SpecialitiesHistory (int current, DateTime time, DoneStatusEnum done)
		{
			string sql = String.Format("select * from {0} where operation_time < '{1}'", HistoryTableNamesEnum.specialities_history, time);

			List<SpecialityHistory> history = new List<SpecialityHistory>();

			DbWork db = new DbWork();
			List<DbDataRecord> dbRecords = db.GetHistory(sql);

			foreach (var record in dbRecords)
			{
				history.Add(new SpecialityHistory(record));
			}

			history.Reverse();

			CommonHistoryWork<SpecialityHistory> common = new CommonHistoryWork<SpecialityHistory>(current, time, history);

			IBaseHistory<SpecialityHistory> baseHistory = new SpecialityBaseHistory();

			if (done == DoneStatusEnum.Undone)
			{
				return common.Undone(baseHistory);
			}
			else if (done == DoneStatusEnum.Redone)
			{
				return common.Redone(baseHistory);
			}
			else
			{
				return -1;
			}
		}
		public static int StreetsHistory (int current, DateTime time, DoneStatusEnum done)
		{
			string sql = String.Format("select * from {0} where operation_time < '{1}'", HistoryTableNamesEnum.streets_history, time);

			List<StreetHistory> history = new List<StreetHistory>();

			DbWork db = new DbWork();
			List<DbDataRecord> dbRecords = db.GetHistory(sql);

			foreach (var record in dbRecords)
			{
				history.Add(new StreetHistory(record));
			}

			history.Reverse();

			CommonHistoryWork<StreetHistory> common = new CommonHistoryWork<StreetHistory>(current, time, history);

			IBaseHistory<StreetHistory> baseHistory = new StreetBaseHistory();

			if (done == DoneStatusEnum.Undone)
			{
				return common.Undone(baseHistory);
			}
			else if (done == DoneStatusEnum.Redone)
			{
				return common.Redone(baseHistory);
			}
			else
			{
				return -1;
			}
		}
	}
}
