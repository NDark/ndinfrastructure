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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NGUILoadTextToLabel : MonoBehaviour 
{
	public string m_AsssetPath = string.Empty ;
	public UILabel m_Label = null ;

	// Use this for initialization
	void Start () 
	{
		LoadAndSet() ;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void LoadAndSet()
	{
		if( null == m_Label 
		|| m_AsssetPath == string.Empty 
		)
		{
			Debug.Log("LoadAndSet null pointer");
			return; 
		}
		
		TextAsset ta = Resources.Load<TextAsset>(m_AsssetPath) ;
		if( null != ta )
		{
			m_Label.text = ta.text ;
		}
	}
}
