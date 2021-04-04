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
 * https://wenrongdev.com/unity53-native-system-language/
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public static class PlatformRegion
{

	public static string CheckUnityApplicationSystemLanguage()
	{
		string ret = string.Empty;
		SystemLanguage unitySystemLangauge = Application.systemLanguage;
		ret = unitySystemLangauge.ToString();
		// Debug.Log("CheckApplicationSystemLanguage() ret=" + ret);
		return ret ;
	}

#if UNITY_ANDROID
	public static string CurrentAndroidLanguage()
	{
		string result = "";
		using (AndroidJavaClass cls = new AndroidJavaClass("java.util.Locale"))
		{
			if (cls != null)
			{
				using (AndroidJavaObject locale = cls.CallStatic<AndroidJavaObject>("getDefault"))
				{
					if (locale != null)
					{
						result = locale.Call<string>("getLanguage") + "_" + locale.Call<string>("getDefault");
						Debug.Log("CurrentAndroidLanguage() Android lang: " + result);
					}
					else
					{
						Debug.LogError("CurrentAndroidLanguage() locale null");
					}
				}
			}
			else
			{
				Debug.LogError("CurrentAndroidLanguage() cls null");
			}
		}

		Debug.LogWarning("CurrentAndroidLanguage() result" + result);
		return result;
	}
#endif


#if UNITY_IPHONE
	[DllImport("__Internal")]
	private static extern string CurIOSLang();

	public static string CurrentiOSLanguage()
	{
		string ret = CurIOSLang();
		Debug.LogWarning("CurrentAndroidLanguage() ret" + ret);
		return ret;
	}
#endif


}
