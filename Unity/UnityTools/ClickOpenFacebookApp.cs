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
@file OnClickOpenBrower.cs
@author NDark
@date 20170501 . file started.
@date 20170620 by NDark
. add class method OpenBrowerWithSpecifiedTabName(), OpenBrowerNewTab(), OpenBrowerAtSelf(), RefreshBrower()

*/
using UnityEngine;

public class ClickOpenFacebookApp : MonoBehaviour 
{
	public string m_PageID = string.Empty ;
	const string CONST_FB_MobilePrefix = "fb://page/" ;
	const string CONST_FB_WWWPrefix = "http://facebook.com/" ;

	/**
	https://forum.unity.com/threads/open-facebook-app-instead-safari-ios-c.143623/
	*/
	private bool checkPackageAppIsPresent(string package)
	{
	       AndroidJavaClass up = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
	       AndroidJavaObject ca = up.GetStatic<AndroidJavaObject>("currentActivity");
	       AndroidJavaObject packageManager = ca.Call<AndroidJavaObject>("getPackageManager");
	 
	      //take the list of all packages on the device
	       AndroidJavaObject appList = packageManager.Call<AndroidJavaObject>("getInstalledPackages",0);
	       int num = appList.Call<int>("size");
	       for(int i = 0; i < num; i++)
	       {
	            AndroidJavaObject appInfo = appList.Call<AndroidJavaObject>("get", i);
	            string packageNew = appInfo.Get<string>("packageName");
	            if(packageNew.CompareTo(package) == 0)
	            {
	                return true;
	            }
	       }
	       return false;
	}

	public void Click()
	{
		string url = string.Empty ;
		if( Application.platform == RuntimePlatform.Android && checkPackageAppIsPresent("com.facebook.katana") )
		{
			// Debug.LogWarning("CONST_FB_MobilePrefix+m_PageID");
			url = (CONST_FB_MobilePrefix+m_PageID); //there is Facebook app installed so let's use it
		}
		else
		{
			// Debug.LogWarning("CONST_FB_WWWPrefix+m_PageID");
			url = (CONST_FB_WWWPrefix+m_PageID); // no Facebook app - use built-in web browser
		}
		Application.OpenURL(url);
	}


	void OnClick()
	{
		Click() ;
	}

}
