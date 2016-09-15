using System;
using MySql.Data.MySqlClient;

namespace PDbPrueba
{
	class MainClass
	{
		public static void Main (string[] args)
		{
//			Console.WriteLine ("Probando dbprueba");
//
//			MySqlConnection mySqlConnection = new MySqlConnection (
//				"Database=dbprueba;User Id=root;Password=sistemas"
//			);
//
//			mySqlConnection.Open ();
//
//			//operaciones...
//
//			mySqlConnection.Close ();

			readLong ("Introduce el id: ");
		}

		private static long readLong(string label) {
			while (true) {
				Console.Write (label);
				string data = Console.ReadLine ();
				try {
					return long.Parse (data);
				} catch {
					Console.WriteLine ("Sólo números, por favor. Vuelve a introducir");
				}
			}
		}
	}
}
