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
@file ClipboardUtility_iOS.cs
@author NDark
@date 20170509 . file started.

*/
using System.Runtime.InteropServices; // DllImport

public static class ClipboardUtility_iOS
{
#if UNITY_IOS
	[DllImport("__Internal")]
	private static extern string _GetPasteBoardContent();
	
	[DllImport("__Internal")]
	private static extern void _CopyToPasteBoard(string exportData);
#endif // UNITY_IOS
	
	public static void CopyToClipboard( string _Str )
	{
#if UNITY_IOS
		_CopyToPasteBoard( _Str ) ;
#endif // UNITY_IOS
	}
	
}
