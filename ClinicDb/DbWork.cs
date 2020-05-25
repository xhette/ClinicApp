using ClinicDb.Entities;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace ClinicDb
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

		public List<Area> GetAreas()
		{
			List<Area> areas = new List<Area>();

			_connection.Open();
			var sql = "select * from areas";
			using var cmd = new NpgsqlCommand(sql, _connection);

			NpgsqlDataReader npgSqlDataReader = cmd.ExecuteReader();
			if (npgSqlDataReader.HasRows)
			{
				foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
				{
					areas.Add(new Area(dbDataRecord));
				}
			}

			return areas;
		}
	}
}
