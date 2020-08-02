/**

MIT License

Copyright (c) 2017 - 2020 NDark

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
@file ConversationUIBase.cs
@author NDark

@date 20170401 file started.

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationUIBase : MonoBehaviour 
{
	public virtual void ShowDialog( bool _Show )
	{
		// Debug.Log( "null != m_DialogBackground" + (null != m_DialogBackground)) ;
	}

	public virtual void ShowPotraitLeft( bool _Show )
	{

	}
	
	public virtual void SetPotraitLeft( string _SpriteName )
	{

	}
		
	public virtual void ShowPotraitRight( bool _Show )
	{

	}
	
	public virtual void SetPotraitRight( string _SpriteName )
	{

	}
	
	public virtual void SetContent( string _Content )
	{

	}

	public virtual void TryInitializedStructure()
	{
	}
}
