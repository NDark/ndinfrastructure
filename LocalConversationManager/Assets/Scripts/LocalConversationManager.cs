﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalConversationManager : ConversationManager 
{
	public LocalConversationManagerUI m_LocalGUI = null ;

	// Use this for initialization
	void Start () 
	{
		m_LocalGUI = this.gameObject.GetComponent<LocalConversationManagerUI>() ;
		if( null == m_LocalGUI )
		{
			Debug.LogError( "null == m_LocalGUI" ) ;
		}

		ShowDialogUI( false ) ;
	}

	protected override void CloseConversationGUI()
	{
		m_LocalGUI.TryInitializedStructure() ;
		m_LocalGUI.ShowDialog( false ) ;
		m_LocalGUI.ShowPotraitLeft( false ) ;
		m_LocalGUI.ShowPotraitRight( false ) ;
		m_LocalGUI.ShowAnswer0( false ) ;
		m_LocalGUI.ShowAnswer1( false ) ;

	}

	protected override void ShowDialogUI( bool _Show )
	{

		if( false == _Show )
		{
			CloseConversationGUI() ;
		}
		else
		{
			int takeIndex = GetTakeIndex( m_CurrentTakeUID ) ;

			if( takeIndex < 0 || takeIndex >= this.Takes.Count )
			{
				Debug.LogError( "takeIndex >= m_Takes.Count takeIndex=" + takeIndex ) ;
				return ;
			}

			Take take = this.Takes[ takeIndex ] ;
			if( null == take )
			{
				Debug.LogError( "null == take" ) ;
				return ;
			}
			else
			{

				// potrait
				bool showLeft = ( string.Empty != take.PotraitLeft ) ;
				m_LocalGUI.ShowPotraitLeft( showLeft ) ;

				bool showRight = ( string.Empty != take.PotraitRight ) ;
				m_LocalGUI.ShowPotraitRight( showRight ) ;


				if( true == showLeft )
				{
					m_LocalGUI.SetPotraitLeft( take.PotraitLeft ) ;
				}

				if( true == showRight )
				{
					m_LocalGUI.SetPotraitRight( take.PotraitRight ) ;
				}

				// content
				bool showDialog = ( string.Empty != take.ContentString ) ;
				m_LocalGUI.ShowDialog( showDialog ) ;

				if( true == showDialog )
				{
					m_LocalGUI.SetContent( take.ContentString ) ;
				}


				TakeWithAnswer tA = take as TakeWithAnswer ;
				if( null != tA )
				{
					bool showAnswer0 = ( string.Empty != tA.Answer0 ) ;
					m_LocalGUI.ShowAnswer0( showAnswer0 ) ;
					if( true == showAnswer0 )
					{
						m_LocalGUI.SetAnswer0( tA.Answer0 ) ;
					}

					bool showAnswer1 = ( string.Empty != tA.Answer1 ) ;
					m_LocalGUI.ShowAnswer1( showAnswer1 ) ;
					if( true == showAnswer1 )
					{
						m_LocalGUI.SetAnswer1( tA.Answer1 ) ;
					}

				}

			}


		}
	}

}
