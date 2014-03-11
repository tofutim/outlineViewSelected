// WARNING
// This file has been generated automatically by Xamarin Studio to
// mirror C# types. Changes in this file made by drag-connecting
// from the UI designer will be synchronized back to C#, but
// more complex manual changes may not transfer correctly.


#import <Foundation/Foundation.h>
#import <AppKit/AppKit.h>


@interface MainWindowController : NSWindowController {
	NSArrayController *_arrayController;
	NSTableView *_tableView;
    NSOutlineView *_outlineView;
}

@property (nonatomic, retain) IBOutlet NSArrayController *arrayController;

@property (nonatomic, retain) IBOutlet NSTableView *tableView;
@property (assign) IBOutlet NSOutlineView *outlineView;

@end
