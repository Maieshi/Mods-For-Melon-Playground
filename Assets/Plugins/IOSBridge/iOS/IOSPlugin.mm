#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>
#import <Photos/Photos.h>

extern UIViewController *UnityGetGLViewController();

@interface iOSPlugin : NSObject

@end

@implementation iOSPlugin

+(void)alertView:(NSString*) title addMessage:(NSString*) message
{
UIAlertController *alert = [UIAlertController alertControllerWithTitle:title
message:message
preferredStyle:UIAlertControllerStyleAlert];

UIAlertAction *defaultAction = [UIAlertAction actionWithTitle:@"OK" style:UIAlertActionStyleDefault
handler:^(UIAlertAction *action){}];

[alert addAction:defaultAction];
[UnityGetGLViewController() presentViewController:alert animated:YES completion:nil];
}

+(void)showAlertWithCallBack:(NSString*) title addMessage:(NSString*) message addObjectName:(NSString*) objectName addAction:(NSString*) callBackName
{
UIAlertController *alert = [UIAlertController alertControllerWithTitle:title
message:message
preferredStyle:UIAlertControllerStyleAlert];

UIAlertAction *defaultAction = [UIAlertAction actionWithTitle:@"OK" style:UIAlertActionStyleDefault
handler:^(UIAlertAction *action){
UnitySendMessage([objectName UTF8String], [callBackName UTF8String], "");
}];

[alert addAction:defaultAction];
[UnityGetGLViewController() presentViewController:alert animated:YES completion:nil];
}

+(void) showActionSheet:(NSString *)objectName methodName:(NSString *)callBackName{

UIAlertController *actionSheet = [UIAlertController alertControllerWithTitle:@"MORE" message:@"Choose action" preferredStyle:UIAlertControllerStyleActionSheet];

UIAlertAction *edit = [UIAlertAction actionWithTitle:@"Edit" style:UIAlertActionStyleDefault handler:^(UIAlertAction * _Nonnull action) {
UnitySendMessage([objectName UTF8String], [callBackName UTF8String], "EDIT");
}];

UIAlertAction *share = [UIAlertAction actionWithTitle:@"Share" style:UIAlertActionStyleDefault handler:^(UIAlertAction * _Nonnull action) {
UnitySendMessage([objectName UTF8String], [callBackName UTF8String], "SHARE");
}];
UIAlertAction *deleteAction = [UIAlertAction actionWithTitle:@"Delete" style:UIAlertActionStyleDefault handler:^(UIAlertAction * _Nonnull action) {
UnitySendMessage([objectName UTF8String], [callBackName UTF8String], "DELETE");
}];
UIAlertAction *defaultAction = [UIAlertAction actionWithTitle:@"Close" style:UIAlertActionStyleCancel handler:nil];


[actionSheet addAction:edit];
[actionSheet addAction:share];
[actionSheet addAction:deleteAction];
[actionSheet addAction:defaultAction];

[UnityGetGLViewController() presentViewController:actionSheet animated:YES completion:nil];
}

+(void) activeActionInputText:(NSString *)objectName methodName:(NSString *)callBackName fileName:(NSString *)fileName{

UIAlertController *inputField = [UIAlertController alertControllerWithTitle:@"Record Name" message:@"Enter new record's name" preferredStyle:UIAlertControllerStyleAlert];

UIAlertAction* ok = [UIAlertAction actionWithTitle:@"OK" style:UIAlertActionStyleDefault handler:^(UIAlertAction *action){
UITextField *textField = inputField.textFields[0];
NSString *newName = textField.text;
UnitySendMessage([objectName UTF8String], [callBackName UTF8String], newName.UTF8String);
}];

UIAlertAction* cancel = [UIAlertAction actionWithTitle:@"Cancel" style:UIAlertActionStyleDefault handler:^(UIAlertAction *action) {
UnitySendMessage([objectName UTF8String], [callBackName UTF8String], "");
}];

[inputField addTextFieldWithConfigurationHandler:^(UITextField *textField) {
textField.placeholder = @"Record name";
textField.text = fileName;
textField.clearButtonMode = UITextFieldViewModeWhileEditing;
textField.borderStyle = UITextBorderStyleRoundedRect;
}];

[inputField addAction:ok];
[inputField addAction:cancel];

[UnityGetGLViewController() presentViewController:inputField animated:YES completion:nil];
}

+(void) initWithActivity:(NSString *)url
{
NSURL* absoluteUrl = [NSURL fileURLWithPath: url];
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

+(void) saveImageToAlbum:(NSString *)url
{
NSURL* absoluteUrl = [NSURL fileURLWithPath: url];
UIImage *image = [UIImage imageNamed: absoluteUrl.path];
UIImageWriteToSavedPhotosAlbum(image, self, @selector(image:didFinishSavingWithError:contextInfo:), nil);
}



+(void)image:(UIImage *)image didFinishSavingWithError: (NSError *) error contextInfo: (void *) contextInfo
{
UIAlertView *alert;
if (!error)
{
alert = [[UIAlertView alloc]initWithTitle:@"Success!" message:@"The picture was saved successfully to your Gallery." delegate:nil cancelButtonTitle:@"OK" otherButtonTitles: nil];

}
else
{
[iOSPlugin openSettingMenu];
}

[alert show];
}

+(void) openSettingMenu{
UIAlertController *alert = [UIAlertController alertControllerWithTitle:@"Photo" message:@"Photo access is absolutely necessary to use this app" preferredStyle:UIAlertControllerStyleAlert];
UIAlertAction *defaultAction = [UIAlertAction actionWithTitle:@"Setting" style:UIAlertActionStyleDefault
handler:^(UIAlertAction *action){
[[UIApplication sharedApplication] openURL:[NSURL URLWithString:UIApplicationOpenSettingsURLString]];
}];

UIAlertAction *actionClose = [UIAlertAction actionWithTitle:@"Close" style:UIAlertActionStyleCancel handler:nil];

[alert addAction:defaultAction];
[alert addAction:actionClose];

[UnityGetGLViewController() presentViewController:alert animated:YES completion:nil];
}

+(void) copyText: (NSString *)textToCopy{
UIPasteboard.generalPasteboard.string = textToCopy;
}

@end

extern "C"
{
void _showAlert(const char *title, const char *message)
{
[iOSPlugin alertView:[NSString stringWithUTF8String:title] addMessage:[NSString stringWithUTF8String:message]];
}

void _showAlertWithCallBack(const char *title, const char *message, const char *objectName, const char *callBackName)
{
[iOSPlugin showAlertWithCallBack:[NSString stringWithUTF8String:title] addMessage:[NSString stringWithUTF8String:message] addObjectName:[NSString stringWithUTF8String:objectName] addAction:[NSString stringWithUTF8String:callBackName]];
}


void _initWithActivity(const char *url)
{
[iOSPlugin initWithActivity:[NSString stringWithUTF8String:url]];
}

void _saveImageToAlbum(const char *url)
{
[iOSPlugin saveImageToAlbum:[NSString stringWithUTF8String:url]];
}

void _showActionSheet(const char *objectName, const char *callBackName)
{
[iOSPlugin showActionSheet:[NSString stringWithUTF8String:objectName] methodName:[NSString stringWithUTF8String:callBackName]];
}

void _setNewFileName(const char *objectName, const char *callBackName, const char *fileName)
{
[iOSPlugin activeActionInputText:[NSString stringWithUTF8String:objectName] methodName:[NSString stringWithUTF8String:callBackName] fileName:[NSString stringWithUTF8String:fileName]];
}

void _copyText(const char *textToCopy)
{
[iOSPlugin copyText:[NSString stringWithUTF8String:textToCopy]];
}
}
