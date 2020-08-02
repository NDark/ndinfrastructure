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
/*
@file EnumConverter.cs
@author NDark
@date 20170220 file started.

@date 20170516 by NDark
. add DoInitialize() at beginning of GetInteger() at EnumIntConverter
. actual implement GetString() at EnumStrConverter

*/
using UnityEngine;

public class EnumIntConverter<S>
{
	protected System.Collections.Generic.Dictionary<int , S > m_Converter 
		= new System.Collections.Generic.Dictionary<int , S > () ;

	public virtual void DoInitialize()
	{
		m_IsInitialized = true ;
	}
	
	public virtual S GetEnum( int _Int )
	{
		if( false == m_IsInitialized )
		{
			DoInitialize() ;
		}
		
		if( true == m_Converter.ContainsKey( _Int ) )
		{
			return m_Converter[ _Int ] ;
		}
		else
		{
			return default(S);
		}
	}
	
	public virtual int GetInteger( S _Enum )
	{
		if( false == m_IsInitialized )
		{
			DoInitialize() ;
		}
		
		int ret = 0;
		var iEnum = m_Converter.GetEnumerator ();
		while (iEnum.MoveNext()) 
		{
			if( iEnum.Current.Value.Equals( _Enum ) )
			{
				ret = iEnum.Current.Key ;
			}
		}
		return ret;
	}

	public virtual string GetString( S _Enum )
	{
		return _Enum.ToString() ;
	}

	protected bool m_IsInitialized = false ;
}


public class EnumStrConverter<S>
{
	protected System.Collections.Generic.Dictionary<string , S > m_Converter 
		= new System.Collections.Generic.Dictionary<string , S > () ;
	
	public virtual void DoInitialize()
	{
		m_IsInitialized = true ;
	}

	public virtual S GetEnum( string _Key )
	{
		if( false == m_IsInitialized )
		{
			DoInitialize() ;
		}
		
		if( true == m_Converter.ContainsKey( _Key ) )
		{
			return m_Converter[ _Key ] ;
		}
		else
		{
			return default(S);
		}
	}
	
	public virtual string GetString( S _Enum )
	{
		if( false == m_IsInitialized )
		{
			DoInitialize() ;
		}
		
		string ret = string.Empty;
		var iEnum = m_Converter.GetEnumerator ();
		while (iEnum.MoveNext()) 
		{
			if( iEnum.Current.Value.Equals( _Enum ) )
			{
				ret = iEnum.Current.Key ;
			}
		}
		return ret;
	}
	
	protected bool m_IsInitialized = false ;
}
