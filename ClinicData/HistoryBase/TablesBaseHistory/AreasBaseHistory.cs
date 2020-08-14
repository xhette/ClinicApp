using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClinicData.Entities;
using ClinicData.History;
using ClinicData.HistoryBase.Enums;

namespace ClinicData.HistoryBase.TablesBaseHistory
{
	class AreasBaseHistory : IBaseHistory<AreaHistory>
	{

		public void Delete(AreaHistory table, DoneStatusEnum done)
		{
			string sql = String.Format("SET session_replication_role = replica;" +
						"delete from areas where area_id = {0};" +
						"SET session_replication_role = DEFAULT;", table.Id);
		}

		public void Insert(AreaHistory table, DoneStatusEnum done)
		{
			string sql = "";

			if (done == DoneStatusEnum.Undone)
			{
				sql = String.Format("SET session_replication_role = replica;" +
						"insert into areas(area_id, area_name) values({0}, '{1}');" +
						"SET session_replication_role = DEFAULT;", table.Id, table.NameLast);
			}
			else if (done == DoneStatusEnum.Redone)
			{
				sql = String.Format("SET session_replication_role = replica;" +
						"insert into areas(area_id, area_name) values({0}, '{1}');" +
						"SET session_replication_role = DEFAULT;", table.Id, table.NameNow);
			}

			try
			{
				DbWork db = new DbWork();
				db.BaseOperation(sql);
			}
			catch { }
		}

		public void Update(AreaHistory table, DoneStatusEnum done)
		{

			string sql = "";

			if (done == DoneStatusEnum.Undone)
			{
				sql = String.Format("SET session_replication_role = replica;" +
						"update areas set area_name = '{0}' where area_id = {1}; " +
						"SET session_replication_role = DEFAULT;", table.NameLast, table.Id);
			}
			else if (done == DoneStatusEnum.Redone)
			{
				sql = String.Format("SET session_replication_role = replica;" +
						"update areas set area_name = '{0}' where area_id = {1}; " +
						"SET session_replication_role = DEFAULT;", table.NameNow, table.Id);
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
