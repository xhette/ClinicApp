using System;

using ClinicData.Entities;
using ClinicData.HistoryBase.Enums;

namespace ClinicData.HistoryBase.TablesBaseHistory
{
	internal class DoctorBaseHistory : IBaseHistory<DoctorHistory>
	{
		public void Delete(DoctorHistory table, DoneStatusEnum done)
		{
			string sql = String.Format("SET session_replication_role = replica;" +
						"delete from doctors where doctor_id = {0};" +
						"SET session_replication_role = DEFAULT;", table.Id);
		}

		public void Insert(DoctorHistory table, DoneStatusEnum done)
		{
			string sql = "";

			if (done == DoneStatusEnum.Undone)
			{
				sql = String.Format("SET session_replication_role = replica;" +
						"insert into doctors(doctor_id, doctor_surname, doctor_name, doctor_patronymic, area, speciality, account) values({0}, '{1}', '{2}', '{3}', {4}, {5}, {6});" +
						"SET session_replication_role = DEFAULT;", 
						table.Id, table.SurnameLast, table.NameLast, table.PatronymicLast, table.AreaLast, table.SpecialityLast, table.AccountLast);
			}
			else if (done == DoneStatusEnum.Redone)
			{
				sql = String.Format("SET session_replication_role = replica;" +
						"insert into doctors(doctor_id, doctor_surname, doctor_name, doctor_patronymic, area, speciality, account) values({0}, '{1}', '{2}', '{3}', {4}, {5}, {6});" +
						"SET session_replication_role = DEFAULT;",
						table.Id, table.SurnameNow, table.NameNow, table.PatronymicNow, table.AreaNow, table.SpecialityNow, table.AccountNow);
			}

			try
			{
				DbWork db = new DbWork();
				db.BaseOperation(sql);
			}
			catch { }
		}

		public void Update(DoctorHistory table, DoneStatusEnum done)
		{

			string sql = "";

			if (done == DoneStatusEnum.Undone)
			{
				sql = String.Format("SET session_replication_role = replica;" +
						"update doctors set doctor_surname = '{0}', doctor_name = '{1}', doctor_patronymic = '{2}', area = {3}, speciality = {4}, account = {5} where doctor_id = {6}; " +
						"SET session_replication_role = DEFAULT;",
						table.SurnameLast, table.NameLast, table.PatronymicLast, table.AreaLast, table.SpecialityLast, table.AccountLast, table.Id);
			}
			else if (done == DoneStatusEnum.Redone)
			{
				sql = String.Format("SET session_replication_role = replica;" +
						"update doctors set doctor_surname = '{0}', doctor_name = '{1}', doctor_patronymic = '{2}', area = {3}, speciality = {4}, account = {5} where doctor_id = {6}; " +
						"SET session_replication_role = DEFAULT;",
						table.SurnameNow, table.NameNow, table.PatronymicNow, table.AreaNow, table.SpecialityNow, table.AccountNow, table.Id);
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