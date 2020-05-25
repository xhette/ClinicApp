using System;

namespace ClinicDb
{
	class Program
	{
		static void Main(string[] args)
		{
			DbWork db = new DbWork();

			var list = db.GetAreas();
		}
	}
}
