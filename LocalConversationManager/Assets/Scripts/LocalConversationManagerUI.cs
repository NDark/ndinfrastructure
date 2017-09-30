using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalConversationManagerUI : ConversationUIBase 
{
	public Image m_Background = null ;
	public Image m_PotraitLeft = null ;
	public Image m_PotraitRight = null ;
	public Text m_Dialog = null ;
	public Text m_Answer0 = null ;
	public Text m_Answer1 = null ;

	public System.Action onPressAnswer0 = new System.Action( () => {} ) ;
	public System.Action onPressAnswer1 = new System.Action( () => {} ) ;

	public void PressAnswer0()
	{
		onPressAnswer0() ;
	}

	public void PressAnswer1()
	{
		onPressAnswer1() ;
	}

	public override void ShowDialog( bool _Show )
	{
		m_Dialog.transform.parent.gameObject.SetActive( _Show ) ;
	}

	public override void ShowPotraitLeft( bool _Show )
	{
		m_PotraitLeft.gameObject.SetActive( _Show ) ;
	}

	public override void SetPotraitLeft( string _SpriteName )
	{

	}

	public override void ShowPotraitRight( bool _Show )
	{
		m_PotraitRight.gameObject.SetActive( _Show ) ;
	}

	public override void SetPotraitRight( string _SpriteName )
	{

	}

	public override void SetContent( string _Content )
	{
		m_Dialog.text = _Content ;
	}

	public virtual void ShowAnswer0( bool _Show )
	{
		m_Answer0.transform.parent.gameObject.SetActive( _Show ) ;
	}

	public virtual void SetAnswer0( string _Content )
	{
		m_Answer0.text = _Content ;
	}

	public virtual void ShowAnswer1( bool _Show )
	{
		m_Answer1.transform.parent.gameObject.SetActive( _Show ) ;
	}

	public virtual void SetAnswer1( string _Content )
	{
		m_Answer1.text = _Content ;
	}
}
