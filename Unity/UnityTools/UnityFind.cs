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
@file UnityFind.cs
@author NDark
@date 20170812 . file started.

*/
using UnityEngine;

public static class UnityFind 
{
	public static GameObject GameObjectFind( GameObject _Obj , string _Name )
	{
		if( null != _Obj )
		{
			var trans = _Obj.transform.Find( _Name );
			if( null != trans )
			{
				return trans.gameObject ;
			}
		}
		return null ;
	}
	
	public static T ComponentFind<T>( Transform _Root , string _Name )
	{
		var trans = _Root.Find( _Name );
		if( null == trans )
		{
			Debug.LogError( "ComponentFind() null == trans _Name=" + _Name );
			return default(T) ;
		}
		
		var c = trans.gameObject.GetComponent<T>();
		if( null == c )
		{
			Debug.LogError( "ComponentFind() null == component _Name=" + _Name ) ;
			return default(T) ;
		}
		return c;
	}
	
	
}

