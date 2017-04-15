using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPage
{
	public bool Has( string _Label ) 
	{
		return ( m_Datas.ContainsKey( _Label ) ) ;
	}

	public string Get( string _Label ) 
	{
		string ret = string.Empty ;
		m_Datas.TryGetValue (_Label, out ret);
		return ret;
	}

	public void Set( string _Label , string _Value ) 
	{
		if( m_Datas.ContainsKey( _Label ) )
		{
			m_Datas[ _Label ] = _Value ;
		}
		else
		{
			m_Datas.Add( _Label , _Value ) ;
		}
	}

	Dictionary<string,string> m_Datas = new Dictionary<string, string>() ;
}

public class DataCenter 
{
	public bool HasPage( string _PageLabel ) 
	{
		return ( m_Pages.ContainsKey( _PageLabel ) ) ;
	}

	public DataPage GetPage( string _PageLabel ) 
	{
		DataPage ret = null ;
		m_Pages.TryGetValue (_PageLabel, out ret);
		return ret;
	}

	public bool Has( string _PageLabel , string _Label ) 
	{
		DataPage page = GetPage (_PageLabel); 
		return ( null != page && page.Has( _Label ) );
	}
	
	public string Get( string _PageLabel , string _Label ) 
	{
		string ret = string.Empty ;
		DataPage page = GetPage (_PageLabel); 
		if( null != page )
		{
			ret = page.Get( _Label ) ;
		}
		return ret;
	}
	
	public void Set( string _PageLabel , string _Label , string _Value ) 
	{
		DataPage page = GetPage (_PageLabel); 
		if( null == page )
		{
			page = new DataPage() ;
			m_Pages.Add( _PageLabel , page ) ;
		}

		page.Set( _Label , _Value ) ;

	}

	Dictionary<string,DataPage> m_Pages = new Dictionary<string, DataPage>() ;
}
