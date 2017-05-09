/**
@file iOSStringIO.mm
@author NDark
@date 20170507 . file started.

*/
#import "iOSStringIO.h"

// Converts C style string to NSString
NSString* CToNSString (const char* _String )
{
    if (_String)
	{
        return [NSString stringWithUTF8String: _String];
	}
    else
	{
        return [NSString stringWithUTF8String: ""];
	}
}

// Helper method to create C string copy
char* StringCopy (const char* _String)
{
    if (_String == NULL)
	{
        return NULL;
	}
    
    char* ret = (char*)malloc(strlen(_String) + 1);
    strcpy(ret, _String);
    return ret;
}
