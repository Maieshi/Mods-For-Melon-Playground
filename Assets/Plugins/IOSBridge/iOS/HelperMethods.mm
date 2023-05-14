#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

extern UIViewController *UnityGetGLViewController();

@interface HelperMethods : NSObject

@end

@implementation HelperMethods


+(void) createActionSheet:(NSString *)objectName methodName:(NSString *)callBackName count:(NSArray*)callBackCount{

UIAlertController *actionSheet = [UIAlertController alertControllerWithTitle:@"Action" message:@"Choose action" preferredStyle:UIAlertControllerStyleActionSheet];

for(NSString* str in callBackCount){

UIAlertAction *action = [UIAlertAction actionWithTitle:str style:UIAlertActionStyleDefault handler:^(UIAlertAction * _Nonnull action) {
UnitySendMessage([objectName UTF8String], [callBackName UTF8String], [str UTF8String]);
}];

[actionSheet addAction:action];
}

UIAlertAction *defaultAction = [UIAlertAction actionWithTitle:@"Close" style:UIAlertActionStyleCancel handler:nil];

[actionSheet addAction:defaultAction];

[UnityGetGLViewController() presentViewController:actionSheet animated:YES completion:nil];
}


+(void) shareUrl:(NSString *)url
{
NSURL* absoluteUrl = [NSURL URLWithString: url];
NSArray* dataToShare = @[absoluteUrl];
UIActivityViewController* activityViewController =[[UIActivityViewController alloc] initWithActivityItems:dataToShare applicationActivities:nil];
if (activityViewController == nil){
return;
}

if(UIDevice.currentDevice.userInterfaceIdiom == UIUserInterfaceIdiomPad) {
activityViewController.popoverPresentationController.sourceView = UnityGetGLViewController().view;
activityViewController.popoverPresentationController.sourceRect = CGRectMake(280, 500, 50, 50);
}

[UnityGetGLViewController() presentViewController:activityViewController animated:YES completion:nil];
}


@end

extern "C"
{
void _createActionSheet(const char *objectName, const char *callBackName, const char* callCount[], int count)
{

NSMutableArray* tempArr = [[NSMutableArray alloc] initWithCapacity: count];

for (int i = 0; i < count; i++) {


[tempArr addObject: [NSString stringWithUTF8String: callCount[i]]];
}

NSArray* arrToAdd = [NSArray arrayWithArray:tempArr];

[HelperMethods createActionSheet:[NSString stringWithUTF8String:objectName] methodName:[NSString stringWithUTF8String:callBackName] count:arrToAdd];
}

void _shareUrl(const char *url)
{
[HelperMethods shareUrl:[NSString stringWithUTF8String:url]];
}
}
