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

		public User GetUserByLogin (string login)
		{
			_connection.Open();
			var sql = String.Format("select * from users where login = '{0}' fetch first 1 rows only", login);
			var cmd = new NpgsqlCommand(sql, _connection);

			User user = new User();

			NpgsqlDataReader npgSqlDataReader = cmd.ExecuteReader();

			if (npgSqlDataReader.HasRows)
			{
				foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
				{
					user = new User(dbDataRecord);
				}
			}
			_connection.Close();

			return user;
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
			_connection.Close();
			_connection.Open();

			sql = String.Format("insert into patients (patient_surname, patient_name, patient_patronymic, street, house, room, account)" +
				"values ('{0}', '{1}', '{2}', {3}, {4}, {5}, {6})", patient.Patient.Surname, patient.Patient.Name, patient.Patient.Patronymic, 
				patient.Patient.Street, patient.Patient.House, patient.Patient.Room, id);

			var cmd2 = new NpgsqlCommand(sql, _connection);

			cmd2.ExecuteNonQuery();
			_connection.Close();
		}

		public PatientComposite GetPatientByUserId (int userId)
		{
			PatientComposite patient = new PatientComposite();

			_connection.Open();

			var sql = String.Format("select patient_id, patient_surname, patient_name, patient_patronymic, street, house, room, account, " +
				"street_id, street_name, area,user_id, login, password, role " +
				"from users join(patients join streets on street = street_id) on account = user_id" +
				" where user_id = {0}", userId);
			var cmd = new NpgsqlCommand(sql, _connection);

			NpgsqlDataReader npgSqlDataReader = cmd.ExecuteReader();
			if (npgSqlDataReader.HasRows)
			{
				foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
				{
					patient = new PatientComposite(dbDataRecord);
				}
			}
			_connection.Close();

			return patient;
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
			_connection.Close();
			_connection.Open();
			sql = String.Format("insert into doctors (doctor_surname, doctor_name, doctor_patronymic, area, speciality, account)" +
				"values ('{0}', '{1}', '{2}', {3}, {4}, {5})", doctor.Doctor.Surname, doctor.Doctor.Name, doctor.Doctor.Patronymic, doctor.Doctor.Area, doctor.Doctor.Speciality, id);

			var cmd2 = new NpgsqlCommand(sql, _connection);

			cmd2.ExecuteNonQuery();
			_connection.Close();
		}

		public List<Doctor> GetDoctorsBySpec (int specId)
		{
			List<Doctor> doctors = new List<Doctor>();

			_connection.Open();
			var sql = String.Format("select * from doctors join specialities on speciality = speciality_id where speciality = {0}", specId);

			var cmd = new NpgsqlCommand(sql, _connection);

			NpgsqlDataReader npgSqlDataReader = cmd.ExecuteReader();
			if (npgSqlDataReader.HasRows)
			{
				foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
				{
					doctors.Add(new Doctor(dbDataRecord));
				}
			}
			_connection.Close();

			return doctors;
		}
		#endregion

		#region Receptionists
		public void RegisteReceptionist(User user)
		{
			_connection.Open();
			var sql = String.Format("insert into users (login, password, role) values ('{0}', '{1}', {2}) returning user_id", user.Login, user.Password, 2);
			var cmd = new NpgsqlCommand(sql, _connection);
			cmd.ExecuteNonQuery();
		}
		#endregion

		#region Specialities
		public List<Speciality> GetSpecialities()
		{
			List<Speciality> areas = new List<Speciality>();

			_connection.Open();
			var sql = "select * from specialities";
			var cmd = new NpgsqlCommand(sql, _connection);

			NpgsqlDataReader npgSqlDataReader = cmd.ExecuteReader();
			if (npgSqlDataReader.HasRows)
			{
				foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
				{
					areas.Add(new Speciality(dbDataRecord));
				}
			}
			_connection.Close();

			return areas;
		}

		public void AddSpeciality(Speciality area)
		{
			_connection.Open();
			var sql = String.Format("insert into specialities (speciality_name) values ('{0}')", area.Name);
			var cmd = new NpgsqlCommand(sql, _connection);

			cmd.ExecuteNonQuery();
			_connection.Close();
		}

		public void EditSpeciality(Speciality area)
		{
			_connection.Open();
			var sql = String.Format("update specialities set speciality_name = '{0}' where speciality_id = {1}", area.Name, area.Id);
			var cmd = new NpgsqlCommand(sql, _connection);

			cmd.ExecuteNonQuery();
			_connection.Close();
		}

		public void DeleteSpeciality(int id)
		{
			_connection.Open();
			var sql = String.Format("delete from specialities where speciality_id = {0}", id);
			var cmd = new NpgsqlCommand(sql, _connection);

			cmd.ExecuteNonQuery();
			_connection.Close();
		}
		#endregion

		#region CaseRecords
		public List<RecordComposite> RecordsByPatient(int patientId)
		{
			List<RecordComposite> records = new List<RecordComposite>();

			_connection.Open();

			var sql = String.Format("select diagnosis_id, diagnosis_code, diagnosis_description, case_id, patient, diagnosis, therapy from " +
				"(case_records right join patients on patient = patient_id) left join diagnosis on diagnosis = diagnosis_id where patient = {0}", patientId);
			var cmd = new NpgsqlCommand(sql, _connection);

			NpgsqlDataReader npgSqlDataReader = cmd.ExecuteReader();
			if (npgSqlDataReader.HasRows)
			{
				foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
				{
					records.Add( new RecordComposite(dbDataRecord));
				}
			}
			_connection.Close();

			return records;
		}
		#endregion

		#region Receptions
		public List<ReceptionComposite> ReceptionsByPatient(int patientId)
		{
			List<ReceptionComposite> receptions = new List<ReceptionComposite>();

			_connection.Open();

			string sql = String.Format("select * from patients join (reception join (schedules join (doctors join specialities on speciality = speciality_id) on doctor = doctor_id) on schedule = schedule_id) on patient = patient_id join streets on street = street_id where patient = {0}", patientId);

			var cmd = new NpgsqlCommand(sql, _connection);

			NpgsqlDataReader npgSqlDataReader = cmd.ExecuteReader();
			if (npgSqlDataReader.HasRows)
			{
				foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
				{
					receptions.Add(new ReceptionComposite(dbDataRecord));
				}
			}
			_connection.Close();

			return receptions;
		}

		public Reception ReceptionByScheduleAndTime (int schedule, DateTime time)
		{
			Reception reception = new Reception();

			_connection.Open();

			string sql = String.Format("select * from reception join (schedules join (doctors join specialities on speciality = speciality_id) on doctor = doctor_id) on schedule = schedule_id where schedule = {0} and reception_time = '{1}'", schedule, time.ToString("HH:mm:ss"));
			var cmd = new NpgsqlCommand(sql, _connection);

			NpgsqlDataReader npgSqlDataReader = cmd.ExecuteReader();
			if (npgSqlDataReader.HasRows)
			{
				foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
				{
					reception = new Reception (dbDataRecord);
				}
			}
			else
			{
				reception = new Reception
				{
					Patient = null,
					Shedule = schedule,
					Time = time
				};
			}
			_connection.Close();

			return reception;
		}

		public List<Shedule> GetSheduleByDoctor (int doctorId)
		{
			List<Shedule> shedule = new List<Shedule>();

			_connection.Open();

			string sql = String.Format("select * from schedules where doctor = {0}", doctorId);

			var cmd = new NpgsqlCommand(sql, _connection);

			NpgsqlDataReader npgSqlDataReader = cmd.ExecuteReader();

			if (npgSqlDataReader.HasRows)
			{
				foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
				{
					shedule.Add(new Shedule(dbDataRecord));
				}
			}
			_connection.Close();

			return shedule;
		}

		public Shedule GetSheduleById(int id)
		{
			Shedule shedule = new Shedule();

			_connection.Open();

			string sql = String.Format("select * from schedules where schedule_id = {0}", id);

			var cmd = new NpgsqlCommand(sql, _connection);

			NpgsqlDataReader npgSqlDataReader = cmd.ExecuteReader();

			if (npgSqlDataReader.HasRows)
			{
				foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
				{
					shedule = new Shedule(dbDataRecord);
				}
			}
			_connection.Close();

			return shedule;
		}

		public void AddSchedule (int scheduleId, int patientId, DateTime time)
		{
			_connection.Open();
			var sql = String.Format("insert into reception (reception_time, patient, schedule) values ('{0}', {1}, {2})", time.ToString("HH:mm:ss"), patientId, scheduleId);
			var cmd = new NpgsqlCommand(sql, _connection);

			cmd.ExecuteNonQuery();
			_connection.Close();
		}
		#endregion
	}
}
