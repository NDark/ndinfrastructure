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
@file EditorTools_Version.cs
@author NDark
@date 20170509 . file started.
@date 20210901 . remove define for windows and osx.
@date 20251008 . move file to under folder Editor.
*/
using UnityEngine;

public static partial class EditorTools
{
	public static void IncrementEndingVersion(string _AssetPath, string _SaveAssetRelativePath)
	{
#if UNITY_EDITOR_WIN || UNITY_EDITOR_OSX
		Debug.LogWarning("EditorTools::IncrementEndingVersion");
		int m_BuildVersionInt = 0;

		TextAsset assignedVersionTextAsset = null;
		assignedVersionTextAsset = Resources.Load(_AssetPath) as TextAsset;

		if (null == assignedVersionTextAsset)
		{
			Debug.LogError("null == assignedVersionTextAsset");
			return;
		}

		if (false == System.IO.File.Exists(_SaveAssetRelativePath))
		{
			Debug.LogError("_SaveAssetRelativePath not exist _SaveAssetRelativePath=" + _SaveAssetRelativePath);
			return;
		}

		string versionString = string.Empty;

		string incrementalVersion = "0";
		string finalVersionString = string.Empty;

		string[] strVec = null;
		string[] spliter = { "." };

		versionString = assignedVersionTextAsset.text;

		strVec = versionString.Split(spliter
			, System.StringSplitOptions.RemoveEmptyEntries);

		if (strVec.Length > 0)
		{
			incrementalVersion = strVec[strVec.Length - 1];
			int.TryParse(incrementalVersion, out m_BuildVersionInt);
			finalVersionString = strVec[0];
		}

		++m_BuildVersionInt;

		if (null != strVec)
		{
			for (int i = 1; i < strVec.Length - 1; ++i)
			{
				finalVersionString += "." + strVec[i];
			}
		}

		finalVersionString += "." + m_BuildVersionInt.ToString();


		string projectDir = System.Environment.CurrentDirectory;
		string versionPath = projectDir + "/" + _SaveAssetRelativePath;

		System.IO.StreamWriter SW = new System.IO.StreamWriter(versionPath);
		if (null != SW)
		{
			Debug.LogWarning("IncrementEndingVersion() versionPath=" + versionPath);
			SW.Write(finalVersionString);
			SW.Close();
		}

		UnityEditor.AssetDatabase.Refresh();

#endif // UNITY_EDITOR_WIN || UNITY_EDITOR_OSX

	}


}
