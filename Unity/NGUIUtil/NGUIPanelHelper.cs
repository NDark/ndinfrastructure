/**

MIT License

Copyright (c) 2017 - 2019 NDark

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
@file NGUIUICollector.cs
@author NDark
@date 20180112 . file started.

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NGUIPanelHelper : MonoBehaviour 
{

	public string CloseButtonPath = string.Empty;

	public UIPanel Panel { get { return m_Panel ; } }
	public float PanelAlpha { get { return (null!=m_Panel) ? m_Panel.alpha : 0.0f ; } }
	public UIButton CloseButton { get { return m_CloseButton ; } } 

	public NGUIUICollector UIs { get { return m_UIs ; } }

	public void Show( bool _Show )
	{
		if( null == m_TweenAlpha )
		{
			return ;
		}

		if( _Show )
		{
			m_TweenAlpha.PlayForward();
		}
		else
		{
			m_TweenAlpha.PlayReverse() ;
		}
	}

	void Awake() 
	{
		SetupStructure() ;
	}

	protected virtual void SetupStructure() 
	{
		m_Panel = this.gameObject.GetComponent<UIPanel>() ;
		m_TweenAlpha = this.gameObject.GetComponent<TweenAlpha>() ;
		if( string.Empty != this.CloseButtonPath )
		{
			SetupCloseButton( this.CloseButtonPath ) ;
		}

		m_UIs.SetupObj( this.gameObject ) ;
	}

	public void SetupCloseButton( string _Path )
	{
		m_CloseButton = UnityFind.ComponentFind<UIButton>( this.transform , _Path ) ;
	}

	NGUIUICollector m_UIs = new NGUIUICollector() ;
	UIButton m_CloseButton = null ;
	UIPanel m_Panel = null ;
	TweenAlpha m_TweenAlpha = null ;

}
