/**

MIT License

Copyright (c) 2017 - 2018 NDark

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

*/
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
