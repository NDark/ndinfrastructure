using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public static class ClipboardUtility_Android
{
	public static void CopyToClipboard( string _Str )
	{
		#if UNITY_ANDROID		
		AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
		AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity"); 
		AndroidJavaObject clipboard = jo.Call<AndroidJavaObject>("getSystemService","clipboard");
		
		AndroidJavaClass clipdata = new AndroidJavaClass("android.content.ClipData"); 
		AndroidJavaObject clipObject = clipdata.CallStatic<AndroidJavaObject>("newPlainText","label", 
		                                                                      _Str );
		
		clipboard.Call( "setPrimaryClip" , clipObject );
		#endif // UNITY_ANDROID		
	}
	
}
