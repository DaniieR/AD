using System;
using Gtk;
using System.Collections.Generic;
namespace PArticulo2
{
	public partial class ArticuloView : Gtk.Window
	{
		public ArticuloView () : base(Gtk.WindowType.Toplevel) {
			this.Build ();
			spinButtonPrecio.Value = 0;
			saveAction.Sensitive = false;

			List<Categoria> list = new List<Categoria> ();
			list.Add(new Categoria(1L,"Categoria 1"));
			list.Add(new Categoria(2L,"Categoria 2"));
			list.Add(new Categoria(3L,"Categoria 3"));
			ListStore listStore = new ListStore (typeof(object));
			foreach (object item in list)
				listStore.AppendValues (item);

			comboBoxCategoria.Model = listStore;

			entryNombre.Changed += delegate {
				string value = entryNombre.Text;
				value = value.Trim();
				saveAction.Sensitive = !value.Equals("");
			};

			saveAction.Activated += delegate {
				Console.WriteLine ("saveAction.Activated");
			};
		}
	}
	public class Categoria{
		public Categoria (long id, string nombre) {
			Id = id;
			Nombre = nombre;
		}
		public long Id { get; set;}
		public string Nombre { get; set;}
	}
}