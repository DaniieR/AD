using System;
using Gtk;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.Generic;

using PArticulo2;
using Org.InstitutoSerpis.Ad;

public partial class MainWindow: Gtk.Window
{	
	private IDbConnection dbConnection;
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		dbConnection = new MySqlConnection ("Database=dbprueba;User Id=root; Password=sistemas");
		dbConnection.Open ();

		List <Articulo> list = new List<Articulo>();
		//TODO rellenar desde la tabla articulo
		string selectSql = "select * from articulo";
		IDbCommand dbCommand = dbConnection.CreateCommand ();
		dbCommand.CommandText = selectSql;
		IDataReader dataReader = dbCommand.ExecuteReader ();
		while (dataReader.Read()) {
			long id = (long)dataReader ["id"];
			string nombre = (string)dataReader ["nombre"];
			decimal? precio = dataReader ["precio"] is DBNull ? null : (decimal?) dataReader ["precio"];
			long? categoria = dataReader ["categoria"] is DBNull ? null : (long?) dataReader ["categoria"];
			Articulo articulo = new Articulo(id, nombre, precio, categoria);
			list.Add (articulo);
				}
		dataReader.Close ();
		TreeViewHelper.Fill (treeview1, list);
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		dbConnection.Close ();
		Application.Quit ();
		a.RetVal = true;
	}
}
