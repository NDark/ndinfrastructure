/**
@file ClipboardIO.mm
@author NDark
@date 20170507 . file started.

*/
#import "iOSStringConverter.h"

extern "C" 
{


#define MakeStringCopy( _x_ ) ( _x_ != NULL  [_x_ isKindOfClass:[NSString class]] ) ? strdup( [_x_ UTF8String] ) : NULL
#define GetStringParam( _x_ ) ( _x_ != NULL ) ? [NSString stringWithUTF8String:_x_] : [NSString stringWithUTF8String:""]

//send clipboard to unity
const char * _GetPasteBoardContent()
{
    NSString *result = [UIPasteboard generalPasteboard].string;
    return MakeStringCopy(result);
}
 
//get clipboard from unity
void _CopyToPasteBoard(const char * eString)
{
    [UIPasteboard generalPasteboard].string = GetStringParam(eString);//@"the text to copy";
}
 
 
 
}

