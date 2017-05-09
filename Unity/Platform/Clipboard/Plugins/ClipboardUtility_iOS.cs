using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

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
