using System;
using MonoMac.AppKit;

namespace outlineViewSelected
{
	public class OutlineViewDelegate : NSOutlineViewDelegate
	{
		public OutlineViewDelegate ()
		{
		}

		public override void SelectionDidChange (MonoMac.Foundation.NSNotification notification)
		{
			var outlineView = (NSTableView)notification.Object;
			Console.WriteLine ("SelectionDidChange in OutlineView to row {0}", outlineView.SelectedRow);
		}
	}
}

