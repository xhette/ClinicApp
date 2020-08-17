using System;

using ClinicData.HistoryBase.Enums;

using ClinicDb.Entities;

namespace ClinicData.HistoryBase.TablesBaseHistory
{
	internal class SpecialityBaseHistory : IBaseHistory<SpecialityHistory>
	{
		public void Delete(SpecialityHistory table, DoneStatusEnum done)
		{
			string sql = String.Format("SET session_replication_role = replica;" +
						"delete from specialities where speciality_id = {0};" +
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

		public void Insert(SpecialityHistory table, DoneStatusEnum done)
		{
			string sql = "";

			if (done == DoneStatusEnum.Undone)
			{
				sql = String.Format("SET session_replication_role = replica;" +
						"insert into specialities(speciality_id, speciality_name) values({0}, '{1}');" +
						"SET session_replication_role = DEFAULT;", table.Id, table.NameLast);
			}
			else if (done == DoneStatusEnum.Redone)
			{
				sql = String.Format("SET session_replication_role = replica;" +
						"insert into specialities(speciality_id, speciality_name) values({0}, '{1}');" +
						"SET session_replication_role = DEFAULT;", table.Id, table.NameNow);
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

		public void Update(SpecialityHistory table, DoneStatusEnum done)
		{

			string sql = "";

			if (done == DoneStatusEnum.Undone)
			{
				sql = String.Format("SET session_replication_role = replica;" +
						"update specialities set speciality_name = '{0}' where speciality_id = {1}; " +
						"SET session_replication_role = DEFAULT;", table.NameLast, table.Id);
			}
			else if (done == DoneStatusEnum.Redone)
			{
				sql = String.Format("SET session_replication_role = replica;" +
						"update specialities set speciality_name = '{0}' where speciality_id = {1}; " +
						"SET session_replication_role = DEFAULT;", table.NameNow, table.Id);
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