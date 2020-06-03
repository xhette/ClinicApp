using ClinicData.Composite;
using ClinicData.Entities;
using ClinicDb.Entities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ClinicData
{
	public class DbWork
	{
		private string _connectionString = String.Format("Server = {0}; Port = {1}; User Id = {2}; Password = {3}; Database = {4}",
			"localhost", 5432, "postgres", "admin", "ClinicSuqa");
		private NpgsqlConnection _connection;

		public DbWork()
		{
			this._connection = new NpgsqlConnection(_connectionString);
		}

		#region Areas
		public List<Area> GetAreas()
		{
			List<Area> areas = new List<Area>();

			_connection.Open();
			var sql = "select * from areas";
			var cmd = new NpgsqlCommand(sql, _connection);

			NpgsqlDataReader npgSqlDataReader = cmd.ExecuteReader();
			if (npgSqlDataReader.HasRows)
			{
				foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
				{
					areas.Add(new Area(dbDataRecord));
				}
			}
			_connection.Close();

			return areas;
		}

		public void AddArea(Area area)
		{
			_connection.Open();
			var sql = String.Format("insert into areas (area_name) values ('{0}')", area.Name);
			var cmd = new NpgsqlCommand(sql, _connection);

			cmd.ExecuteNonQuery();
			_connection.Close();
		}

		public void EditArea(Area area)
		{
			_connection.Open();
			var sql = String.Format("update areas set area_name = '{0}' where area_id = {1}", area.Name, area.Id);
			var cmd = new NpgsqlCommand(sql, _connection);

			cmd.ExecuteNonQuery();
			_connection.Close();
		}

		public void DeleteArea (int id)
		{
			_connection.Open();
			var sql = String.Format("delete from areas where area_id = {0}", id);
			var cmd = new NpgsqlCommand(sql, _connection);

			cmd.ExecuteNonQuery();
			_connection.Close();
		}
		#endregion

		#region Streets
		public List<Street> GetStreets()
		{
			List<Street> areas = new List<Street>();

			_connection.Open();
			var sql = "select * from streets";
			var cmd = new NpgsqlCommand(sql, _connection);

			NpgsqlDataReader npgSqlDataReader = cmd.ExecuteReader();
			if (npgSqlDataReader.HasRows)
			{
				foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
				{
					areas.Add(new Street(dbDataRecord));
				}
			}
			_connection.Close();

			return areas;
		}

		public void AddStreet(Street street)
		{
			_connection.Open();
			var sql = String.Format("insert into streets (street_name, area) values ('{0}', {1})", street.Name, street.Area);
			var cmd = new NpgsqlCommand(sql, _connection);

			cmd.ExecuteNonQuery();
			_connection.Close();
		}

		public void EditStreet(Street street)
		{
			_connection.Open();
			var sql = String.Format("update streets set street_name = '{0}', area = {1} where street_id = {2}", street.Name, street.Area, street.Id);
			var cmd = new NpgsqlCommand(sql, _connection);

			cmd.ExecuteNonQuery();
			_connection.Close();
		}

		public void DeleteStreet(int id)
		{
			_connection.Open();
			var sql = String.Format("delete from streets where street_id = {0}", id);
			var cmd = new NpgsqlCommand(sql, _connection);

			cmd.ExecuteNonQuery();
			_connection.Close();
		}

		public List<Street> GetStreetsByArea(int areaId)
		{
			List<Street> areas = new List<Street>();

			_connection.Open();
			var sql = String.Format("select * from streets where area = {0}", areaId);
			var cmd = new NpgsqlCommand(sql, _connection);

			NpgsqlDataReader npgSqlDataReader = cmd.ExecuteReader();
			if (npgSqlDataReader.HasRows)
			{
				foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
				{
					areas.Add(new Street(dbDataRecord));
				}
			}
			_connection.Close();

			return areas;
		}
		#endregion

		#region Roles
		public List<Role> GetRoles()
		{
			List<Role> roles = new List<Role>();

			_connection.Open();
			var sql = "select * from roles";
			var cmd = new NpgsqlCommand(sql, _connection);

			NpgsqlDataReader npgSqlDataReader = cmd.ExecuteReader();
			if (npgSqlDataReader.HasRows)
			{
				foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
				{
					roles.Add(new Role(dbDataRecord));
				}
			}
			_connection.Close();

			return roles;
		}

		public void AddRole(Role role)
		{
			_connection.Open();
			var sql = String.Format("insert into roles (role_name) values ('{0}')", role.Name);
			var cmd = new NpgsqlCommand(sql, _connection);

			cmd.ExecuteNonQuery();
			_connection.Close();
		}

		public void EditRole(Role role)
		{
			_connection.Open();
			var sql = String.Format("update roles set role_name = '{0}' where role_id = {1}", role.Name, role.Id);
			var cmd = new NpgsqlCommand(sql, _connection);

			cmd.ExecuteNonQuery();
			_connection.Close();
		}

		public void DeleteRole(int id)
		{
			_connection.Open();
			var sql = String.Format("delete from roles where role_id = {0}", id);
			var cmd = new NpgsqlCommand(sql, _connection);

			cmd.ExecuteNonQuery();
			_connection.Close();
		}
		#endregion

		#region Users
		public List<User> GetUsers()
		{
			List<User> roles = new List<User>();

			_connection.Open();
			var sql = "select * from users";
			var cmd = new NpgsqlCommand(sql, _connection);

			NpgsqlDataReader npgSqlDataReader = cmd.ExecuteReader();
			if (npgSqlDataReader.HasRows)
			{
				foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
				{
					roles.Add(new User(dbDataRecord));
				}
			}
			_connection.Close();

			return roles;
		}

		public void AddUser(User role)
		{
			_connection.Open();
			var sql = String.Format("insert into users (login, password, role) values ('{0}', '{1}', {2})", role.Login, role.Password, role.Role);
			var cmd = new NpgsqlCommand(sql, _connection);

			cmd.ExecuteNonQuery();
			_connection.Close();
		}

		public void EditUser(User role)
		{
			_connection.Open();
			var sql = String.Format("update users set login = '{0}', password = '{1}, role = {2} where user_id = {3}", role.Login, role.Password, role.Role, role.Id);
			var cmd = new NpgsqlCommand(sql, _connection);

			cmd.ExecuteNonQuery();
			_connection.Close();
		}

		public void DeleteUser(int id)
		{
			_connection.Open();
			var sql = String.Format("delete from users where user_id = {0}", id);
			var cmd = new NpgsqlCommand(sql, _connection);

			cmd.ExecuteNonQuery();
			_connection.Close();
		}
		public List<User> GetUsersByRole(int roleId)
		{
			List<User> roles = new List<User>();

			_connection.Open();
			var sql = String.Format("select * from users where role = {0}", roleId);
			var cmd = new NpgsqlCommand(sql, _connection);

			NpgsqlDataReader npgSqlDataReader = cmd.ExecuteReader();
			if (npgSqlDataReader.HasRows)
			{
				foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
				{
					roles.Add(new User(dbDataRecord));
				}
			}
			_connection.Close();

			return roles;
		}
		#endregion

		#region Patients
		public List<PatientComposite> PatientsList()
		{
			List<PatientComposite> patients = new List<PatientComposite>();

			_connection.Open();

			var sql = "select patient_id, patient_surname, patient_name, patient_patronymic, street, house, room, account, " +
				"street_id, street_name, area,user_id, login, password, role " +
				"from users join(patients join streets on street = street_id) on account = user_id";
			var cmd = new NpgsqlCommand(sql, _connection);

			NpgsqlDataReader npgSqlDataReader = cmd.ExecuteReader();
			if (npgSqlDataReader.HasRows)
			{
				foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
				{
					patients.Add(new PatientComposite(dbDataRecord));
				}
			}
			_connection.Close();

			return patients;
		}

		public void RegistryPatient (PatientComposite patient)
		{
			_connection.Open();
			var sql = String.Format("insert into users (login, password, role) values ('{0}', '{1}', {2}) returning user_id", patient.User.Login, patient.User.Password, 3);
			var cmd = new NpgsqlCommand(sql, _connection);
			NpgsqlDataReader npgSqlDataReader = cmd.ExecuteReader();

			int id = 0;

			while (npgSqlDataReader.Read())
			{
				id = Int32.Parse(npgSqlDataReader["user_id"].ToString());
			}

			sql = String.Format("insert into patients (patient_surname, patient_name, patient_patronymic, street, house, room, account" +
				"values ('{0}', '{1}', '{2}', {3}, {4}, {5}, {6})", patient.Patient.Surname, patient.Patient.Name, patient.Patient.Patronymic, 
				patient.Patient.Street, patient.Patient.House, patient.Patient.Room, id);

			var cmd2 = new NpgsqlCommand(sql, _connection);

			cmd2.ExecuteNonQuery();
			_connection.Close();
		}
		#endregion

		#region Doctors
		public void RegisterDoctor(DoctorComposite doctor)
		{
			_connection.Open();
			var sql = String.Format("insert into users (login, password, role) values ('{0}', '{1}', {2}) returning user_id", doctor.User.Login, doctor.User.Password, 1);
			var cmd = new NpgsqlCommand(sql, _connection);
			NpgsqlDataReader npgSqlDataReader = cmd.ExecuteReader();

			int id = 0;

			while (npgSqlDataReader.Read())
			{
				id = Int32.Parse(npgSqlDataReader["user_id"].ToString());
			}

			sql = String.Format("insert into doctors (doctor_surname, doctor_name, doctor_patronymic, area, speciality, account" +
				"values ('{0}', '{1}', '{2}', {3}, {4}, {5})", doctor.Doctor.Surname, doctor.Doctor.Name, doctor.Doctor.Patronymic, doctor.Doctor.Speciality, doctor.Doctor.Area, id);

			var cmd2 = new NpgsqlCommand(sql, _connection);

			cmd2.ExecuteNonQuery();
			_connection.Close();
		}
		#endregion
	}
}
