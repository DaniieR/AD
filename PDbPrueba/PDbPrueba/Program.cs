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
			IDbCommand dbCommand = dbConnection.CreateCommand ();
			IDbDataParameter dbDataParameter = dbCommand.CreateParameter ();
			IDbDataParameter dbDataParameter2 = dbCommand.CreateParameter ();
			dbConnection.Open ();
			//Operaciones...

			IDataReader dataReader; 
			String cat;
			String catmod;
			String idmod;
			int idint;
			String iddel;
			do{
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
				Console.Clear();
				dbCommand.CommandText = "insert into categoria (nombre) values (@nombre)";
				dbDataParameter.ParameterName = "nombre";
				Console.WriteLine ("Introduzca una categoria");
				cat = Console.ReadLine ();
				dbDataParameter.Value = cat;
				dbCommand.Parameters.Add (dbDataParameter);
				dbCommand.ExecuteNonQuery ();
				dbCommand.Dispose();
			break;
			case '2':
					Console.Clear();
					dbCommand.CommandText = "select * from categoria";
					dataReader = dbCommand.ExecuteReader ();
					Console.WriteLine ("-----------------------");
					while (dataReader.Read()) {

						int id = dataReader.GetInt32 (0);
						String nombre = dataReader.GetString (1);
						Console.WriteLine ("ID " + id + " " + "Nombre " + nombre);
					}
					dataReader.Close();
					Console.WriteLine ("Introduzca una categoria");
					catmod = Console.ReadLine ();
					Console.WriteLine ("Introduzca el ID");
					idmod = Console.ReadLine ();
					idint = int.Parse (idmod);
					dbCommand.CommandText = "update categoria set nombre =(@nombre) where id =(@id)";
					dbDataParameter.ParameterName = "nombre";
					dbDataParameter.Value = catmod;
					dbDataParameter2.ParameterName = "id";
					dbDataParameter2.Value = idint;
					dbCommand.Parameters.Add (dbDataParameter);
					dbCommand.Parameters.Add (dbDataParameter2);
					dbCommand.ExecuteNonQuery();
					dbCommand.Dispose();
			break;
			case '3':
					Console.Clear();
					dbCommand.CommandText = "delete from categoria where id=@iddel";
					dbDataParameter.ParameterName = "iddel";
					Console.WriteLine ("Introduzca ID a eliminar");
					iddel = Console.ReadLine ();
					dbDataParameter.Value = iddel;
					dbCommand.Parameters.Add (dbDataParameter);
					dbCommand.ExecuteNonQuery ();
					dbCommand.Dispose();
			break;
			case '4':
				Console.Clear();
				dbCommand.CommandText = "select * from categoria";
				dataReader = dbCommand.ExecuteReader ();
				Console.WriteLine ("-----------------------");
				while (dataReader.Read()) {

					int id = dataReader.GetInt32 (0);
					String nombre = dataReader.GetString (1);
					Console.WriteLine ("ID " + id + " " + "Nombre " + nombre);
				}
				dataReader.Close();
				break;
			case '0':
				Console.Clear();
				dbConnection.Close ();
				dbCommand.Dispose();
				dbConnection=null;
				break;
				
			};
			}while(dbConnection!=null);
		}
	}
}
