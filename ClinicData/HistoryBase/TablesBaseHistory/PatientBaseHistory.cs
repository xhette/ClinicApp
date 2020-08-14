using System;

using ClinicData.Entities;
using ClinicData.HistoryBase.Enums;

namespace ClinicData.HistoryBase.TablesBaseHistory
{
	internal class PatientBaseHistory : IBaseHistory<PatientHistory>
	{
		public void Delete(PatientHistory table, DoneStatusEnum done)
		{
			string sql = String.Format("SET session_replication_role = replica;" +
						"delete from patients where patient_id = {0};" +
						"SET session_replication_role = DEFAULT;", table.Id);
		}

		public void Insert(PatientHistory table, DoneStatusEnum done)
		{
			string sql = "";

			if (done == DoneStatusEnum.Undone)
			{
				sql = String.Format("SET session_replication_role = replica;" +
						"insert into patients(patient_id, patient_surname, patient_name, patient_patronymic, street, house, room, account) values({0}, '{1}', '{2}', '{3}', {4}, {5}, {6}, {7});" +
						"SET session_replication_role = DEFAULT;",
						table.Id, table.SurnameLast, table.NameLast, table.PatronymicLast, table.StreetLast, table.HouseLast, table.RoomLast, table.AccountLast);
			}
			else if (done == DoneStatusEnum.Redone)
			{
				sql = String.Format("SET session_replication_role = replica;" +
						"insert into patients(patient_id, patient_surname, patient_name, patient_patronymic, street, house, room, account) values({0}, '{1}', '{2}', '{3}', {4}, {5}, {6}, {7});" +
						"SET session_replication_role = DEFAULT;",
						table.Id, table.SurnameNow, table.NameNow, table.PatronymicNow, table.StreetNow, table.HouseNow, table.RoomNow, table.AccountNow);
			}

			try
			{
				DbWork db = new DbWork();
				db.BaseOperation(sql);
			}
			catch { }
		}

		public void Update(PatientHistory table, DoneStatusEnum done)
		{

			string sql = "";

			if (done == DoneStatusEnum.Undone)
			{
				sql = String.Format("SET session_replication_role = replica;" +
						"update patients set patient_surname = '{0}', patient_name = '{1}', patient_patronymic = '{2}', street = {3}, house = {4}, room = {5}, account = {6} where patient_id = {7}; " +
						"SET session_replication_role = DEFAULT;",
						table.SurnameLast, table.NameLast, table.PatronymicLast, table.StreetLast, table.HouseLast, table.RoomLast, table.AccountLast, table.Id);
			}
			else if (done == DoneStatusEnum.Redone)
			{
				sql = String.Format("SET session_replication_role = replica;" +
						"update patients set patient_surname = '{0}', patient_name = '{1}', patient_patronymic = '{2}', street = {3}, house = {4}, room = {5}, account = {6} where patient_id = {7}; " +
						"SET session_replication_role = DEFAULT;",
						table.SurnameNow, table.NameNow, table.PatronymicNow, table.StreetNow, table.HouseNow, table.RoomNow, table.AccountNow, table.Id);
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