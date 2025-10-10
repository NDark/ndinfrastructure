/**

MIT License

Copyright (c) 2017 - 2025 NDark

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
@file EditorTools_AssetsBundleStreamingAssets.cs
@author NDark
@date 20251010 . file created.

*/
using System.IO;
using UnityEditor;
using UnityEngine;

public static partial class EditorTools
{
	[MenuItem("Tools/AssetsBundle/MoveAssetsBundleStreamingAssets")]
	public static void MoveAssetsBundleStreamingAssets()
	{
		Debug.LogWarning("EditorTools::MoveAssetsBundleStreamingAssets");

		string sourceDirectory = Path.Combine(AssetBundles.Utility.AssetBundlesOutputPath, AssetBundles.Utility.GetPlatformName());
		if (!Directory.Exists(sourceDirectory))
		{ 
			Debug.LogError("!Directory.Exists(sourceDirectory="+ sourceDirectory);
			return ;
		}

		var allFiles = System.IO.Directory.GetFiles(sourceDirectory);
		

		string assetsBundleDir = Path.Combine(UnityEngine.Application.streamingAssetsPath, "AssetBundles2/" + AssetBundles.Utility.GetPlatformName());
		if (!Directory.Exists(assetsBundleDir))
			Directory.CreateDirectory(assetsBundleDir);

		int count = 0 ;
		foreach( var filePath in allFiles)
		{ 
			if( !File.Exists(filePath))
			{
				Debug.LogError("!File.Exists(filePath=" + filePath);
				continue ;
			}

			var fileInto = new System.IO.FileInfo(filePath);
			if( fileInto.Extension == ".manifest")
			{ 
				continue;
			}
			var destinationFile = Path.Combine(assetsBundleDir, fileInto.Name);

			if (File.Exists(destinationFile))
			{ 
				System.IO.File.Delete(destinationFile);
			}
			++count;
			System.IO.File.Copy(filePath , destinationFile);

		}

		Debug.Log("copy file count=" + count);
	}


}
