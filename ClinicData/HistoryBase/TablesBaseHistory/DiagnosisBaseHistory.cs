using System;

using ClinicData.Entities;
using ClinicData.HistoryBase.Enums;

namespace ClinicData.HistoryBase.TablesBaseHistory
{
	internal class DiagnosisBaseHistory : IBaseHistory<DiagnosisHistory>
	{
		public void Delete(DiagnosisHistory table, DoneStatusEnum done)
		{
			string sql = String.Format("SET session_replication_role = replica;" +
						"delete from diagnodis where diagnosis_id = {0};" +
						"SET session_replication_role = DEFAULT;", table.Id);
		}

		public void Insert(DiagnosisHistory table, DoneStatusEnum done)
		{
			string sql = "";

			if (done == DoneStatusEnum.Undone)
			{
				sql = String.Format("SET session_replication_role = replica;" +
						"insert into diagnosis(diagnosis_id, diagnosis_code, diagnosis_description) values({2}, '{0}', '{1}');" +
						"SET session_replication_role = DEFAULT;", table.CodeLast, table.DescriptionLast, table.Id);
			}
			else if (done == DoneStatusEnum.Redone)
			{
				sql = String.Format("SET session_replication_role = replica;" +
						"insert into diagnosis(diagnosis_id, diagnosis_code, diagnosis_description) values({2}, '{0}', '{1}');" +
						"SET session_replication_role = DEFAULT;", table.CodeNow, table.DescriptionNow, table.Id);
			}

			try
			{
				DbWork db = new DbWork();
				db.BaseOperation(sql);
			}
			catch { }
		}

		public void Update(DiagnosisHistory table, DoneStatusEnum done)
		{

			string sql = "";

			if (done == DoneStatusEnum.Undone)
			{
				sql = String.Format("SET session_replication_role = replica;" +
						"update diagnosis set diagnosis_code = '{0}', diagnosis_description = '{1}' where diagnosis_id = {2}; " +
						"SET session_replication_role = DEFAULT;", table.CodeLast, table.DescriptionLast, table.Id);
			}
			else if (done == DoneStatusEnum.Redone)
			{
				sql = String.Format("SET session_replication_role = replica;" +
						"update diagnosis set diagnosis_code = '{0}', diagnosis_description = '{1}' where diagnosis_id = {2}; " +
						"SET session_replication_role = DEFAULT;", table.CodeNow, table.DescriptionNow, table.Id);
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