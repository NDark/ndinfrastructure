/**

MIT License

Copyright (c) 2017 - 2019 NDark

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
@file PlayerSettingTools.cs
@author NDark
@date 20170509 . file started.

*/
using System.Collections;
using UnityEngine;

public static partial class PlayerSettingTools
{
	public static string GetBundleVersion()
	{
#if ( UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX ) && !UNITY_EDITOR0_WIN && !UNITY_EDITOR_OSX
		string m_WindowsRunTimeAssetPath = "version" ;
#endif 
// UNITY_STANDALONE_WIN

		string ret = string.Empty ;
		
		if( Application.platform == RuntimePlatform.IPhonePlayer )
		{
#if UNITY_IOS
			ret = PlayerSettingTools_iOS.GetBundleVersion() ;
#endif // UNITY_IOS
		}
		else if( Application.platform == RuntimePlatform.Android )
		{
#if UNITY_ANDROID
#endif // UNITY_ANDROID	
		}
		else if( Application.platform == RuntimePlatform.OSXEditor 
		        || Application.platform == RuntimePlatform.WindowsEditor
		        || Application.platform == RuntimePlatform.WindowsPlayer
		        )
		{
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX
			ret = UnityEditor.PlayerSettings.bundleVersion ;
#else
#if ( UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX )
			TextAsset ta = Resources.Load( m_AssetPath )as TextAsset;
			if( ta )
			{
			ret = ta.text ;
			}
#endif 
// ( UNITY_STANDALONE_WIN || UNITY_STANDALONE_OSX )

#endif
// UNITY_EDITOR_WIN || UNITY_EDITOR_OSX

		}
		else
		{
			Debug.LogError("PlayerSettingTools::GetBundleVersion() Haven't supported this platform.") ;
		}
		
		int index = ret.IndexOf( "\r\n" ) ;
		if( -1 != index 
		   && ret.Length >= 2 
		   && ret.Length - 2 == index )
		{
			ret = ret.Substring( 0 , ret.Length - 2 ) ;
		}
		
		return ret ;
	}
	
}
