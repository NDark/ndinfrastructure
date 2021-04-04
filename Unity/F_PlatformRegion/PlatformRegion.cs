using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlatformRegion
{

	public static string GetDeviceLanguage()
	{
		string ret = string.Empty;
		SystemLanguage unitySystemLangauge = Application.systemLanguage;
		if (unitySystemLangauge == SystemLanguage.ChineseSimplified)
		{
			ret = VTacticConst.CONST_Languages_TraditionalChinese;
		}
		else if (unitySystemLangauge == SystemLanguage.Chinese)
		{
			ret = VTacticConst.CONST_Languages_TraditionalChinese;
		}
		else if (unitySystemLangauge == SystemLanguage.German)
		{
			ret = VTacticConst.CONST_Languages_German;
		}
		else if (unitySystemLangauge == SystemLanguage.Spanish)
		{
			ret = VTacticConst.CONST_Languages_Spanish;
		}

		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
#if UNITY_IPHONE
			ret = CurIOSLang();
#endif

		}
		else if (Application.platform == RuntimePlatform.Android)
		{
#if UNITY_ANDROID
			ret = CurrentAndroidLanguage();
#endif

		}
		else if (Application.platform == RuntimePlatform.WindowsEditor
			|| Application.platform == RuntimePlatform.OSXEditor)
		{
			ret = CheckUnityApplicationSystemLanguage();
		}
		else
		{
			Debug.LogWarning("unknown platform=" + Application.platform );
		}

		Debug.Log("CheckApplicationSystemLanguage() ret=" + ret);
		return ret;
	}

	public static string CheckUnityApplicationSystemLanguage()
	{
		string ret = string.Empty;
		SystemLanguage unitySystemLangauge = Application.systemLanguage;
		if (unitySystemLangauge == SystemLanguage.ChineseSimplified)
		{
			ret = VTacticConst.CONST_Languages_TraditionalChinese;
		}
		else if (unitySystemLangauge == SystemLanguage.Chinese)
		{
			ret = VTacticConst.CONST_Languages_TraditionalChinese;
		}
		else if (unitySystemLangauge == SystemLanguage.German)
		{
			ret = VTacticConst.CONST_Languages_German;
		}
		else if (unitySystemLangauge == SystemLanguage.Spanish)
		{
			ret = VTacticConst.CONST_Languages_Spanish;
		}
		else // malay { }
		{
			Debug.Log("CheckApplicationSystemLanguage() Application.systemLanguage=" + Application.systemLanguage.ToString() );
		}

		Debug.Log("CheckApplicationSystemLanguage() ret=" + ret);
		return ret;
	}

#if UNITY_ANDROID
	private static string CurrentAndroidLanguage()
	{
		string result = "";
		using (AndroidJavaClass cls = new AndroidJavaClass("java.util.Locale"))
		{
			if (cls != null)
			{
				using (AndroidJavaObject locale = cls.CallStatic("getDefault"))
				{
					if (locale != null)
					{
						result = locale.Call("getLanguage") + "_" + locale.Call("getDefault");
						Debug.Log("Android lang: " + result);
					}
					else
					{
						Debug.Log("locale null");
					}
				}
			}
			else
			{
				Debug.Log("cls null");
			}
		}
		return result;
	}
#endif


#if UNITY_IPHONE
	[DllImport("__Internal")]
	private static extern string CurIOSLang();
#endif


}
