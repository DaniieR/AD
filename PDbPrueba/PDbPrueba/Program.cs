using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace PDbPrueba
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			IDbConnection dbConnection = new MySqlConnection ("Database=dbprueba;User Id=root;Password=sistemas");
			dbConnection.Open ();
			//Operaciones...
			IDbCommand dbCommand = dbConnection.CreateCommand ();
			IDataReader dataReader; 
			String cat;
			do{
				Console.WriteLine ("Probando Dbprueba");
				Console.WriteLine ("------------------------");
				Console.WriteLine ("Seleccione una opcion");
				Console.WriteLine ("------------------------");
				Console.WriteLine ("1 Nuevo");
				Console.WriteLine ("2 Editar");
				Console.WriteLine ("3 Eliminar");
				Console.WriteLine ("4 Listar Todos");
				Console.WriteLine ("0 Salir");
				int opcion = Console.Read ();
			switch (opcion) {
			case '1':
				dbCommand.CommandText = "insert into categoria (nombre) values (@nombre)";
				IDbDataParameter dbDataParameter = dbCommand.CreateParameter ();
				dbDataParameter.ParameterName = "nombre";
				Console.WriteLine ("Introduzca una categoria");
				cat = Console.ReadLine ();
				dbDataParameter.Value = cat;
				dbCommand.Parameters.Add (dbDataParameter);
				dbCommand.ExecuteNonQuery ();
			break;
			case '2':
					dbCommand.CommandText = "select * from categoria";
					dataReader = dbCommand.ExecuteReader ();
					Console.WriteLine ("");
					Console.WriteLine ("-----------------------");
					while (dataReader.Read()) {

						int id = dataReader.GetInt32 (0);
						String nombre = dataReader.GetString (1);
						Console.WriteLine ("ID " + id + " " + "Nombre " + nombre);
					}
					dataReader.Close();
					Console.WriteLine ("Introduzca una categoria");
					String catmod = Console.ReadLine ();
					Console.WriteLine ("Introduzca el ID");
					String idmod = Console.ReadLine ();
					int idint = int.Parse (idmod);


			break;
			case '4':

				dbCommand.CommandText = "select * from categoria";
				dataReader = dbCommand.ExecuteReader ();
				Console.WriteLine ("");
				Console.WriteLine ("-----------------------");
				while (dataReader.Read()) {

					int id = dataReader.GetInt32 (0);
					String nombre = dataReader.GetString (1);
					Console.WriteLine ("ID " + id + " " + "Nombre " + nombre);
				}
				dataReader.Close();
				break;
			case '0':
				dbConnection.Close ();
				dbConnection=null;
				break;
				
			};
			}while(dbConnection!=null);
		}
	}
}
