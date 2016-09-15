using System;
using MySql.Data.MySqlClient;

namespace PDbPrueba
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Probando Dbprueba");
			Console.WriteLine ("Seleccione una opcion");
			Console.WriteLine ("1 Nuevo");
			Console.WriteLine ("2 Editar");
			Console.WriteLine ("3 Eliminar");
			Console.WriteLine ("4 Listar Todos");
			Console.WriteLine ("0 Salir");

			MySqlConnection mySqlConnection = new MySqlConnection ("Database=dbprueba;User Id=root;Password=sistemas");
			mySqlConnection.Open ();
			//Operaciones...
			switch (Console.Read ()) {
			case '0':
				mySqlConnection.Close ();
			break;
			};
		}
	}
}
