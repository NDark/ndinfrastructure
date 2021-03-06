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
@file EditorTools_PlayerSetting.cs
@author NDark
@date 20170509 . file started.

*/
using UnityEngine;
using UnityEditor;

public static partial class EditorTools_PlayerSetting
{
	const string m_AssetPath = "version" ;
	const string m_SaveAssetFullPath = "Assets/Resources/version.txt" ;

	[MenuItem( "Tools/PlayerSettings/IncrementEndingVersion" )]
	public static void IncrementEndingVersion()
	{
		EditorTools.IncrementEndingVersion( m_AssetPath , m_SaveAssetFullPath ) ;
	}

	/// <summary>
	///  PlayerSettings.Android.bundleVersionCode
	///  PlayerSettings.iOS.buildNumber
	/// </summary>
	[MenuItem("Tools/PlayerSettings/IncrementEndingBuildVersion")]
	public static void IncrementEndingBuildVersion()
	{
		PlayerSettings.Android.bundleVersionCode += 1;
		int iOSbuildNumber = 0;
		if (int.TryParse(PlayerSettings.iOS.buildNumber, out iOSbuildNumber))
		{
			iOSbuildNumber += 1;
			PlayerSettings.iOS.buildNumber = iOSbuildNumber.ToString();
		}
		AssetDatabase.SaveAssets();
	}

	// PlayerSettings.bundleVersion
	[MenuItem( "Tools/PlayerSettings/UpdateBundleVersionFromFile" )]
	public static void UpdateBundleVersionFromFile()
	{
		AssetDatabase.Refresh() ;
		TextAsset ta = Resources.Load(m_AssetPath)as TextAsset;
		if( null != ta )
		{
			Debug.LogWarning("UpdateBundleVersionFromFile() ta.text=" + ta.text );
			PlayerSettings.bundleVersion = ta.text ; 
			AssetDatabase.SaveAssets();
		}

	}

}
