using System;
using MonoMac.AppKit;

namespace outlineViewSelected
{
	public class TableViewDelegate : NSTableViewDelegate
	{
		public TableViewDelegate ()
		{
		}

		public override void SelectionDidChange (MonoMac.Foundation.NSNotification notification)
		{
			var tableView = (NSTableView)notification.Object;
			Console.WriteLine ("SelectionDidChange in TableView to row {0}", tableView.SelectedRow);
		}
	}
}

