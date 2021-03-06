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
@file OnEscapeInvokeNGUIButtons.cs
@author NDark
@date 20170910 . file started.

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NGUIButtonInvokeChain
{
	public static Stack<UIButton> m_Stack = new Stack<UIButton>() ;

	public static void PopSpecifiedUIButton( UIButton _UIButton )
	{
		if( null != _UIButton && m_Stack.Count > 0 )
		{
			var button = m_Stack.Peek() ;
			if( button == _UIButton )
			{
				m_Stack.Pop() ;
			}

		}
	}

	public static void PushUIButton( UIButton _UIButton )
	{
		if( null != _UIButton )
		{
			m_Stack.Push( _UIButton ) ;
		}
	}

	public static void PushUIButton( GameObject _UIButtonObJ )
	{
		if( null != _UIButtonObJ )
		{
			var button = _UIButtonObJ.GetComponent<UIButton>() ;
			if( null != button )
			{
				m_Stack.Push( button ) ;
			}
		}
	}

}

public class OnEscapeInvokeNGUIButtons : MonoBehaviour 
{
	public bool IsActiveOnUpdate = true ;

	public virtual void InvokeAndPopButton()
	{
		var button = InvokeButton() ;
		if( NGUIButtonInvokeChain.m_Stack.Count> 0 && button == NGUIButtonInvokeChain.m_Stack.Peek() )
		{
			NGUIButtonInvokeChain.m_Stack.Pop(); 
		}
	}

	public virtual UIButton InvokeButton()
	{
		UIButton ret = null ;
		if( NGUIButtonInvokeChain.m_Stack.Count> 0 )
		{
			ret = NGUIButtonInvokeChain.m_Stack.Peek() ;
			
			if( null != ret )
			{
				ret.SendMessage( "OnClick" );
			}
		}
		return ret ;
	}

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( this.IsActiveOnUpdate && Input.GetKeyUp(KeyCode.Escape) )
		{
			InvokeAndPopButton() ;
		}
		
	}
}
