// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoMac.Foundation;
using System.CodeDom.Compiler;

namespace outlineViewSelected
{
	[Register ("MainWindowController")]
	partial class MainWindowController
	{
		[Outlet]
		MonoMac.AppKit.NSArrayController arrayController { get; set; }

		[Outlet]
		MonoMac.AppKit.NSOutlineView outlineView { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTableView tableView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (arrayController != null) {
				arrayController.Dispose ();
				arrayController = null;
			}

			if (tableView != null) {
				tableView.Dispose ();
				tableView = null;
			}

			if (outlineView != null) {
				outlineView.Dispose ();
				outlineView = null;
			}
		}
	}

	[Register ("MainWindow")]
	partial class MainWindow
	{
		
		void ReleaseDesignerOutlets ()
		{
		}
	}
}
