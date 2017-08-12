/**

MIT License

Copyright (c) 2017 NDark

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

public class OnClickOpenBrower : MonoBehaviour 
{
	public string m_Url = string.Empty ;

	public void OpenBrower()
	{
		OpenBrowerWithSpecifiedTabName() ;// aNewWindow
	}

	public void RefreshBrower()
	{
		_OpenBrower( GetRefreshBrowserJSString() ) ;
	}

	public void OpenBrowerNewTab()
	{
		_OpenBrower( GenerateOpenBrowserJSString( "_blank" ) ) ;
	}

	public void OpenBrowerAtSelf()
	{
		_OpenBrower( GenerateOpenBrowserJSString( "_self" ) ) ;
	}

	public void OpenBrowerWithSpecifiedTabName( string _WindowName = "aNewWindow" )
	{
		_OpenBrower( GenerateOpenBrowserJSString( _WindowName ) ) ;
	}


	// _CustomKey _blank , _self , or other specified window name(will use the same name to open the same tab).
	void _OpenBrower( string _JSCall )
	{
		// Debug.Log( Application.platform ) ;
		if( Application.platform == RuntimePlatform.WebGLPlayer )
		{
			// Debug.Log( jsCall ) ;
			Application.ExternalEval( _JSCall );
		}
#if !UNITY_5_4_OR_NEWER
		else if( Application.platform == RuntimePlatform.WindowsWebPlayer )
		{
			// Debug.Log( jsCall ) ;
			Application.ExternalEval( _JSCall );
		}
#endif		
		else /*if( Application.platform == RuntimePlatform.WindowsPlayer ||
				 Application.platform == RuntimePlatform.WindowsEditor )*/
		{
			Application.OpenURL( m_Url ) ;
		}
	}
	
	void OnClick()
	{
		OpenBrower() ;
	}

	string GenerateOpenBrowserJSString( string _CustomKey )
	{
		return "window.open('" + m_Url + "','"+_CustomKey+"')" ;
	}

	string GetRefreshBrowserJSString()
	{
		return "document.location.reload(true)" ;
	}

}
