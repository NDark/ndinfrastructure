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

*/
using UnityEngine;

public class OnClickOpenBrower : MonoBehaviour 
{
	public string m_Url = string.Empty ;

	public void OpenBrower()
	{
		// Debug.Log( Application.platform ) ;
		if( Application.platform == RuntimePlatform.WebGLPlayer )
		{
			string url = "window.open('" + m_Url + "','aNewWindow')" ;
			// Debug.Log( url ) ;
			Application.ExternalEval( url );
		}
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
}
