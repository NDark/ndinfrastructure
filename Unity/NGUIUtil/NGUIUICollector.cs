
/**
@file NGUIUICollector.cs
@author NDark
@date 20170227 . file started.

*/
using UnityEngine;
using System.Collections.Generic;

public class NGUIUICollector {

	public GameObject Obj
	{
		get{ return m_Obj ; }
	}
	
	public void SetupObj( GameObject _Root )
	{
		m_Obj = _Root ;
		ParseUIs ();
	}
	
	public void ParseUIs()
	{
		if( null == m_Obj )
		{
			Debug.LogWarning( "ParseUIs() null == m_Obj" ) ;
			return ;
		}
		
		m_Labels.Clear() ;
		UILabel [] labels = m_Obj.GetComponentsInChildren<UILabel>() ;
		foreach( UILabel label in labels )
		{
			if( false == m_Labels.ContainsKey ( label.name ) )
			{
				List<UILabel> labelList = new List<UILabel>() ;
				labelList.Add( label ) ;
				m_Labels.Add( label.name , labelList ) ;
			}
			else
			{
				m_Labels[ label.name ].Add( label ) ;
			}
		}
		
		m_Sprites.Clear() ;
		UISprite [] sprites = m_Obj.GetComponentsInChildren<UISprite>() ;
		foreach( UISprite sprite in sprites )
		{
			if( false == m_Sprites.ContainsKey ( sprite.name ) )
			{
				m_Sprites.Add( sprite.name , sprite ) ;
			}
			else
			{
				m_Sprites[ sprite.name ] = sprite  ;
			}
		}
	}
	
	public UISprite GetSprite( string _Key )
	{
		UISprite ret = null ;
		if( false == m_Sprites.ContainsKey( _Key ) )
		{
			Debug.LogWarning( "GetSprite() _Key doesn't exist _Key=" + _Key ) ;
		}
		else
		{
			ret = m_Sprites[ _Key ] ;
		}
		return ret ;
	}

	public UILabel GetFirstLabel( string _Key )
	{
		UILabel ret = null ;
		if( false == m_Labels.ContainsKey( _Key ) )
		{
			Debug.LogWarning( "GetFirstLabel() _Key doesn't exist _Key=" + _Key ) ;
		}
		else
		{
			var listLabel = m_Labels[ _Key ] ;
			var iEnum = listLabel.GetEnumerator() ;
			while( iEnum.MoveNext() )
			{
				ret = iEnum.Current ;
				break ;
			}
		}
		return ret ;
	}
	public List<UILabel> GetLabels( string _Key )
	{
		List<UILabel> ret = null ;
		if( false == m_Labels.ContainsKey( _Key ) )
		{
			Debug.LogWarning( "GetLabels() _Key doesn't exist _Key=" + _Key ) ;
		}
		else
		{
			ret = m_Labels[ _Key ] ;
		}
		return ret ;
	}
	
	public void SetLabel( string _Key , string _Str )
	{
		List<UILabel> labels = GetLabels( _Key ) ;
		if( null == labels )
		{
			Debug.LogWarning("null == labels");
			return ;
		}
		
		List<UILabel>.Enumerator i = labels.GetEnumerator() ;
		while( i.MoveNext() )
		{
			i.Current.text = _Str ;
		}
	}
	
	public void SetSpriteName( string _Key , string _SpriteName )
	{
		UISprite sprite = GetSprite( _Key ) ;
		if( null == sprite )
		{
			return ;
		}
		
		sprite.spriteName = _SpriteName ;
	}
	
	protected GameObject m_Obj = null ;
	protected Dictionary<string , List<UILabel> > m_Labels = new Dictionary<string, List<UILabel>>() ;
	protected Dictionary<string , UISprite > m_Sprites = new Dictionary<string, UISprite>() ;
}
