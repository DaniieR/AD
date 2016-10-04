using Gtk;
using System;

namespace Org.InstitutoSerpis.Ad
{
	public class TreeViewHelper
	{
		public static void AppendColumns (TreeView treeView,string[] columnNames){
			int index = 0;
			foreach(string columnName in columnNames) {
				//for (int index = 0; index < columnNames.Length; index++) {
				treeView.AppendColumn (columnName /*s[index]*/, new CellRendererText (), 
				    delegate(TreeViewColumn tree_column, CellRenderer CellView, TreeModel tree_model,TreeIter tree_iter) {
						int column = Array.IndexOf(treeView.Columns,tree_column);
						CellRendererText cellRendererText = (CellRendererText)CellView;
						object value = tree_model.GetValue(tree_iter, column);
						cellRendererText.Text = value.ToString();
						Console.WriteLine ("index={0} column={1}", index, column);
					}
				);
			}
		}
	}
}

