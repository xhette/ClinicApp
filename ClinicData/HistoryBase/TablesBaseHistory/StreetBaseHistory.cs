using System;

using ClinicData.Entities;
using ClinicData.HistoryBase.Enums;

namespace ClinicData.HistoryBase.TablesBaseHistory
{
	internal class StreetBaseHistory : IBaseHistory<StreetHistory>
	{
		public void Delete(StreetHistory table, DoneStatusEnum done)
		{
			string sql = String.Format("SET session_replication_role = replica;" +
						"delete from streets where street_id = {0};" +
						"SET session_replication_role = DEFAULT;", table.Id);
		}

		public void Insert(StreetHistory table, DoneStatusEnum done)
		{
			string sql = "";

			if (done == DoneStatusEnum.Undone)
			{
				sql = String.Format("SET session_replication_role = replica;" +
						"insert into streets(street_id, street_name, areas) values({0}, '{1}', {2});" +
						"SET session_replication_role = DEFAULT;", table.Id, table.NameLast, table.AreaLast);
			}
			else if (done == DoneStatusEnum.Redone)
			{
				sql = String.Format("SET session_replication_role = replica;" +
						"insert into streets(street_id, street_name, areas) values({0}, '{1}', {2});" +
						"SET session_replication_role = DEFAULT;", table.Id, table.NameNow, table.AreaNow);
			}

			try
			{
				DbWork db = new DbWork();
				db.BaseOperation(sql);
			}
			catch { }
		}

		public void Update(StreetHistory table, DoneStatusEnum done)
		{

			string sql = "";

			if (done == DoneStatusEnum.Undone)
			{
				sql = String.Format("SET session_replication_role = replica;" +
						"update streets set street_name = '{0}', areas = {1} where street_id = {2}; " +
						"SET session_replication_role = DEFAULT;", table.NameLast, table.AreaLast, table.Id);
			}
			else if (done == DoneStatusEnum.Redone)
			{
				sql = String.Format("SET session_replication_role = replica;" +
						"update streets set street_name = '{0}', areas = {1} where street_id = {2}; " +
						"SET session_replication_role = DEFAULT;", table.NameNow, table.AreaNow, table.Id);
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