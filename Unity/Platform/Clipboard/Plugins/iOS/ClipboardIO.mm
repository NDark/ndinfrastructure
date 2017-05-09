/**

MIT License

Copyright (c) 2017 NDark

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
@file ClipboardIO.mm
@author NDark
@date 20170507 . file started.

*/

extern "C" 
{


#define MakeStringCopy( _x_ ) ( _x_ != NULL  [_x_ isKindOfClass:[NSString class]] ) ? strdup( [_x_ UTF8String] ) : NULL
#define GetStringParam( _x_ ) ( _x_ != NULL ) ? [NSString stringWithUTF8String:_x_] : [NSString stringWithUTF8String:""]

// https://forum.unity3d.com/threads/trying-to-make-my-own-copy-paste-text-plugin-for-ios-code-included-nothing-happens.117359/
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

