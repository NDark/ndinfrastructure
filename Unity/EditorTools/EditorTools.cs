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
@file EditorTools.cs
@author NDark
@date 20170509 . file started.

*/
using UnityEngine;

public static partial class EditorTools
{
	public static void CachingCleanCache()
	{
		#if UNITY_2017_1_OR_NEWER
		if( Caching.ClearCache () )
		#else
		if( Caching.CleanCache () )
		#endif 
		{
			Debug.Log("EditorTools::CachingCleanCache() succeed.");
		}
		else 
		{
			Debug.LogWarning("EditorTools::CachingCleanCache() failed.");
		}
	}

	public static void PlayerPrefsDeleteAll()
	{
		Debug.LogWarning("EditorTools::PlayerPrefsDeleteAll() remember this just remove PlayerPrefs of editor platform.");
		PlayerPrefs.DeleteAll() ;
		PlayerPrefs.Save();

	}

}
