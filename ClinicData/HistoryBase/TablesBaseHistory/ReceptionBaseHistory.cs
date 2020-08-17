using System;

using ClinicData.Entities;
using ClinicData.HistoryBase.Enums;

namespace ClinicData.HistoryBase.TablesBaseHistory
{
	internal class ReceptionBaseHistory : IBaseHistory<ReceptionHistory>
	{
		public void Delete(ReceptionHistory table, DoneStatusEnum done)
		{
			string sql = String.Format("SET session_replication_role = replica;" +
						"delete from reception where reception_id = {0};" +
						"SET session_replication_role = DEFAULT;", table.Id);
			try
			{
				DbWork db = new DbWork();
				db.BaseOperation(sql);
			}
			catch (Exception ex)
			{

			}
		}

		public void Insert(ReceptionHistory table, DoneStatusEnum done)
		{
			string sql = "";

			if (done == DoneStatusEnum.Undone)
			{
				sql = String.Format("SET session_replication_role = replica;" +
						"insert into reception(reception_id, reception_time, patient, schedule) values({0}, '{1}', {2}, {3});" +
						"SET session_replication_role = DEFAULT;",
						table.Id, table.TimeLast, table.PatientLast, table.SheduleLast);
			}
			else if (done == DoneStatusEnum.Redone)
			{
				sql = String.Format("SET session_replication_role = replica;" +
						"insert into reception(reception_id, reception_time, patient, schedule) values({0}, '{1}', {2}, {3});" +
						"SET session_replication_role = DEFAULT;",
						table.Id, table.TimeNow, table.PatientNow, table.SheduleLast);
			}

			try
			{
				DbWork db = new DbWork();
				db.BaseOperation(sql);
			}
			catch (Exception ex)
			{

			}
		}

		public void Update(ReceptionHistory table, DoneStatusEnum done)
		{

			string sql = "";

			if (done == DoneStatusEnum.Undone)
			{
				sql = String.Format("SET session_replication_role = replica;" +
						"update reception set reception_time = '{0}', patient = {1}, schedule = {2} where reception_id = {3}; " +
						"SET session_replication_role = DEFAULT;", table.TimeLast, table.PatientLast, table.SheduleLast, table.Id);
			}
			else if (done == DoneStatusEnum.Redone)
			{
				sql = String.Format("SET session_replication_role = replica;" +
						"update reception set reception_time = '{0}', patient = {1}, schedule = {2} where reception_id = {3}; " +
						"SET session_replication_role = DEFAULT;", table.TimeNow, table.PatientNow, table.SheduleLast, table.Id);
			}

			try
			{
				DbWork db = new DbWork();
				db.BaseOperation(sql);
			}
			catch (Exception ex)
			{

			}
		}
	}
}