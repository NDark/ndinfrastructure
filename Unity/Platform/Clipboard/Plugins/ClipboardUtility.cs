using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ClipboardUtility 
{
	
	public static void CopyToClipboard( string _Str )
	{
		if( Application.platform == RuntimePlatform.IPhonePlayer )
		{
			#if UNITY_IOS
			ClipboardUtility_iOS.CopyToClipboard( _Str ) ;
			#endif // UNITY_IOS
		}
		else if( Application.platform == RuntimePlatform.Android )
		{
			#if UNITY_ANDROID		
			ClipboardUtility_Android.CopyToClipboard( _Str ) ;
			#endif // UNITY_ANDROID	
		}
		else if( Application.platform == RuntimePlatform.OSXEditor 
		        || Application.platform == RuntimePlatform.WindowsEditor
		        || Application.platform == RuntimePlatform.WindowsPlayer
		        )
		{
			#if UNITY_EDITOR_WIN
			GUIUtility.systemCopyBuffer = _Str ;
			#else
			GUIUtility.systemCopyBuffer = _Str ;
			#endif 
		}
		else
		{
			Debug.LogError("PlayerSettingUtility::GetBundleVersion() Haven't supported this platform.") ;
		}
	}
}
