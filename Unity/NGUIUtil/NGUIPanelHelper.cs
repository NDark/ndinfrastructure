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
