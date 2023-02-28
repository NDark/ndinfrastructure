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
	const string m_BuildVersionAssetPath = "Versions/BuildVersion";
	const string m_BuildVersionSaveAssetFullPath = "Assets/Resources/Versions/BuildVersion.txt";

	[MenuItem("Tools/PlayerSettings/IncrementBuildVersion")]
	public static void IncrementBuildVersion()
	{
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX
		Debug.LogWarning("EditorTools::IncrementEndingVersion");
		int buildVersionInt = 0;

		TextAsset assignedVersionTextAsset = null;
		assignedVersionTextAsset = Resources.Load(m_BuildVersionAssetPath) as TextAsset;

		if (null == assignedVersionTextAsset)
		{
			Debug.LogError("null == assignedVersionTextAsset");
			return;
		}

		if (false == System.IO.File.Exists(m_BuildVersionSaveAssetFullPath))
		{
			Debug.LogError("_SaveAssetRelativePath not exist _SaveAssetRelativePath=" + m_BuildVersionSaveAssetFullPath);
			return;
		}

		string versionString = assignedVersionTextAsset.text;
		if (int.TryParse(versionString, out buildVersionInt))
		{
			++buildVersionInt;
		}
		
		System.IO.StreamWriter SW = new System.IO.StreamWriter(m_BuildVersionSaveAssetFullPath);
		if (null != SW)
		{
			Debug.LogWarning("IncrementEndingVersion() versionPath=" + m_BuildVersionSaveAssetFullPath);
			SW.Write(buildVersionInt.ToString());
			SW.Close();
		}

		UnityEditor.AssetDatabase.Refresh();

#endif // UNITY_EDITOR_WIN || UNITY_EDITOR_OSX


	}

	const string m_BuildDateStringSaveAssetFullPath = "Assets/Resources/Versions/BuildDateString.txt";

	[MenuItem("Tools/PlayerSettings/RefreshBuildDateString")]
	public static void RefreshBuildDateString()
	{
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX
		if (false == System.IO.File.Exists(m_BuildDateStringSaveAssetFullPath))
		{
			Debug.LogError("_SaveAssetRelativePath not exist _SaveAssetRelativePath=" + m_BuildDateStringSaveAssetFullPath);
			return;
		}

		System.IO.StreamWriter SW = new System.IO.StreamWriter(m_BuildDateStringSaveAssetFullPath);
		if (null != SW)
		{
			Debug.LogWarning("RefreshBuildDateString() m_BuildDateStringSaveAssetFullPath=" + m_BuildDateStringSaveAssetFullPath);
			SW.Write(System.DateTime.Now.ToString("yyyyMMdd") );
			SW.Close();
		}

		UnityEditor.AssetDatabase.Refresh();

#endif
	}

}
