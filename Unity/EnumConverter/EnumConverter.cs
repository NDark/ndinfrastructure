/*
@file EnumConverter.cs
@author NDark
@date 20170220 file started.
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
		return _Enum.ToString() ;
	}
	
	protected bool m_IsInitialized = false ;
}
