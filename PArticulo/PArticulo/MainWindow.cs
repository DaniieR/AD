using Gtk;
<<<<<<< HEAD
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Data;

using Org.InstitutoSerpis.Ad;
using PArticulo;
=======
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Org.InstitutoSerpis.Ad;
>>>>>>> 7efccaf48b7ec54963797cd75834b9891da0dac6

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
<<<<<<< HEAD
		App.Instance.DbConnection = new MySqlConnection (
			"Database=dbprueba;User Id=root;Password=sistemas"
		);
		App.Instance.DbConnection.Open ();

		fill ();

		treeView.Selection.Changed += delegate {
			bool selected = treeView.Selection.CountSelectedRows() > 0;
			editAction.Sensitive = selected;
			deleteAction.Sensitive = selected;
		};

		newAction.Activated += delegate {
			new ArticuloView();
		};

		deleteAction.Activated += delegate {
			if (WindowHelper.Confirm(this, "¿Quieres eliminar el registro?"))
				ArticuloDao.Delete(TreeViewHelper.GetId(treeView));
		};


		refreshAction.Activated += delegate {
			fill();
		};


	}

	private void fill() {
		editAction.Sensitive = false;
		deleteAction.Sensitive = false;
		//IList list = ArticuloDao.GetList ();
		IList list = EntityDao.GetList<Articulo> ();
		TreeViewHelper.Fill (treeView, list);
=======
		IList list = new List<Articulo> ();
		list.Add (new Articulo(1L, "artículo 1", 1.5m));
		list.Add (new Articulo(2L, "artículo 2", 2.5m));
		list.Add (new Articulo(3L, "artículo 3", 3.5m));

		//		IList list = new List<Categoria> ();
		//		list.Add (new Categoria(1L, "categoría 1"));
		//		list.Add (new Categoria(2L, "categoría 2"));
		//		list.Add (new Categoria(3L, "categoría 3"));

		TreeViewHelper.Fill (treeView, list);
		list.Add (new Articulo(4L, "artículo 4", 4.5m));
		TreeViewHelper.Fill (treeView, list);

		//		TreeViewHelper.AppendColumns (treeView, typeof(Articulo));
		//		TreeViewHelper.AppendColumns (treeView, new string[] { "id", "nombre", "precio" });
		//		ListStore listStore = new ListStore (typeof(long), typeof(string), typeof(decimal));
		//		listStore.AppendValues (1L, "artículo 1", 1.5m);
		//		listStore.AppendValues (2L, "artículo 2", 2.5m);
		//		treeView.Model = listStore;
>>>>>>> 7efccaf48b7ec54963797cd75834b9891da0dac6
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
<<<<<<< HEAD
		App.Instance.DbConnection.Close ();
=======
>>>>>>> 7efccaf48b7ec54963797cd75834b9891da0dac6
		Application.Quit ();
		a.RetVal = true;
	}
}
<<<<<<< HEAD
=======

public class Categoria {
	public Categoria(long id, string nombre) {
		Id = id;
		Nombre = nombre;
	}
	public long Id { get; set; }
	public string Nombre { get; set; }
}
public class Articulo {
	public Articulo (long id, string nombre, decimal precio) {
		Id = id;
		Nombre = nombre;
		Precio = precio;
	}
	public long Id { get; set; }
	public string Nombre { get; set; }
	public decimal Precio { get; set; }
}
>>>>>>> 7efccaf48b7ec54963797cd75834b9891da0dac6
