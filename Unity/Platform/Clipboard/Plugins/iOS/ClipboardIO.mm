/**

MIT License

Copyright (c) 2017 - 2021 NDark

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

#include "../../../String/Plugins/iOS/iOSStringIO.h"

extern "C" 
{

// http://stackoverflow.com/questions/18980022/building-unity-app-to-ipad
//send clipboard to unity
const char * _GetPasteBoardContent()
{
    NSString *result = [UIPasteboard generalPasteboard].string;
    return StringCopy([result UTF8String]);
}
 
//get clipboard from unity
void _CopyToPasteBoard(const char * eString)
{
    [UIPasteboard generalPasteboard].string = CToNSString(eString);//@"the text to copy";
}
 
 
 
}


