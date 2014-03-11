using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;
using System.Timers;

namespace outlineViewSelected
{
	public class SimpleModel : NSObject
	{
		public SimpleModel(string fruit)
		{
			_fruit = fruit;
		}

		private string _fruit;

		public string Fruit {
			get { return _fruit; }
			set {
				if (_fruit != value) {
					_fruit = value;
				}
			}
		}

		public override void SetValueForKey (NSObject value, NSString key)
		{
			switch (key) {
			case "fruit":
				Fruit = value.ToString ();
				break;			
			}
		}

		public override NSObject ValueForKey (NSString key)
		{
			switch (key) {
			case "Fruit":
				return new NSString (Fruit);
			case "Children":
				return new NSMutableArray ();
			case "Count":
				return new NSNumber(0);
			}
			return new NSNull();
		}

		[Export("copyWithZone:")]
		public NSObject CopyWithZone (IntPtr zone)
		{
			return new SimpleModel(_fruit).Retain ();
		}

		public SimpleModel[] Children {
			get { return null; }
		}
	}

	public partial class MainWindowController : MonoMac.AppKit.NSWindowController
	{
		#region Constructors

		// Called when created from unmanaged code
		public MainWindowController (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public MainWindowController (NSCoder coder) : base (coder)
		{
			Initialize ();
		}
		// Call to load from the XIB/NIB file
		public MainWindowController () : base ("MainWindow")
		{
			Initialize ();
		}
		// Shared initialization code
		void Initialize ()
		{
		}

		#endregion



		//strongly typed window accessor
		public new MainWindow Window {
			get {
				return (MainWindow)base.Window;
			}
		}

		Timer _timer;
		int i;
		bool isAddAtOnce = false;

		private void addFruits()
		{
			i++;
			if (arrayController.Content != null) {
				((NSMutableArray)(arrayController.Content)).RemoveAllObjects ();		// what if it is not mutable...
			}	
			Console.WriteLine ("Adding more fruits");

			if (isAddAtOnce) {
				var array = new NSMutableArray (4);
				array.Add (new SimpleModel ("strawberry" + i.ToString ()));
				array.Add (new SimpleModel ("raspberry" + i.ToString ()));
				array.Add (new SimpleModel ("blueberry" + i.ToString ()));
				array.Add (new SimpleModel ("fig" + i.ToString ()));
				arrayController.AddObjects (array);
			} else {
				arrayController.AddObject (new SimpleModel ("strawberry" + i.ToString ()));
				arrayController.AddObject (new SimpleModel ("raspberry" + i.ToString ()));
				arrayController.AddObject (new SimpleModel ("blueberry" + i.ToString ()));
				arrayController.AddObject (new SimpleModel ("fig" + i.ToString ()));
			}
		}

		public override void WindowDidLoad ()
		{
			base.WindowDidLoad ();

			arrayController.SelectsInsertedObjects = false;
			//			treeController.SelectsInsertedObjects = false;


			tableView.Delegate = new TableViewDelegate();
						outlineView.Delegate = new OutlineViewDelegate ();

			addFruits ();

			_timer = new Timer (2000);
			_timer.Enabled = true;
			_timer.Elapsed += (object sender, ElapsedEventArgs e) => {
				InvokeOnMainThread(() =>
					{
						addFruits();
					});
			};
			_timer.Start();
		}
	}
}

