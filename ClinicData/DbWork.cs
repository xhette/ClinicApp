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
	}
}
