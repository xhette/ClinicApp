using System;

using ClinicData.Entities;
using ClinicData.HistoryBase.Enums;

namespace ClinicData.HistoryBase.TablesBaseHistory
{
	internal class RecordBaseHistory : IBaseHistory<RecordHistory>
	{
		public void Delete(RecordHistory table, DoneStatusEnum done)
		{
			string sql = String.Format("SET session_replication_role = replica;" +
						"delete from case_records where case_id = {0};" +
						"SET session_replication_role = DEFAULT;", table.Id);
		}

		public void Insert(RecordHistory table, DoneStatusEnum done)
		{
			string sql = "";

			if (done == DoneStatusEnum.Undone)
			{
				sql = String.Format("SET session_replication_role = replica;" +
						"insert into case_records (case_id, patient, diagnosis, therapy) values ({0}, {1}, {3}, '{4}');" +
						"SET session_replication_role = DEFAULT;",
						table.Id, table.PatientLast, table.DiagnosisLast, table.TherapyLast);
			}
			else if (done == DoneStatusEnum.Redone)
			{
				sql = String.Format("SET session_replication_role = replica;" +
						"insert into case_records (case_id, patient, diagnosis, therapy) values({0}, {1}, {3}, '{4}');" +
						"SET session_replication_role = DEFAULT;",
						table.Id, table.PatientNow, table.DiagnosisNow, table.TherapyNow);
			}

			try
			{
				DbWork db = new DbWork();
				db.BaseOperation(sql);
			}
			catch { }
		}

		public void Update(RecordHistory table, DoneStatusEnum done)
		{

			string sql = "";

			if (done == DoneStatusEnum.Undone)
			{
				sql = String.Format("SET session_replication_role = replica;" +
						"update case_records set patient = {0}, diagnosis = {1}, therapy = '{2}' where case_id = {3}; " +
						"SET session_replication_role = DEFAULT;", table.PatientLast, table.DiagnosisLast, table.TherapyLast, table.Id);
			}
			else if (done == DoneStatusEnum.Redone)
			{
				sql = String.Format("SET session_replication_role = replica;" +
						"update case_records set patient = {0}, diagnosis = {1}, therapy = '{2}' where case_id = {3}; " +
						"SET session_replication_role = DEFAULT;", table.PatientNow, table.DiagnosisNow, table.TherapyNow, table.Id);
			}

			try
			{
				DbWork db = new DbWork();
				db.BaseOperation(sql);
			}
			catch { }
		}
	}
}