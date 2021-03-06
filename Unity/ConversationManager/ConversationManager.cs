/**

MIT License

Copyright (c) 2017 - 2021 NDark

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
@file ConversationManager.cs
@author NDark

@date 20140308 file started.
@date 20150405 by NDark . add class method StoryIsPlayed()

*/
// #define ENABLE_ConversationGUISystem

// #define ENABLE_USE_TIME
using UnityEngine;
using System.Collections.Generic ;

public enum ConversationManagerState
{
	UnActive = 0 ,
	Starting ,
	WaitEnd ,
	WaitForInput , 
	Closing ,
	Close ,
} ;

public class ConversationManager : MonoBehaviour 
{
#if ENABLE_ConversationGUISystem
	public ConversationUIBase m_ConversationGUIManager = null ;
#endif

	public ConversationManagerState State
	{
		get { return m_State ; }
	}
	private ConversationManagerState m_State = ConversationManagerState.UnActive ;

	protected int m_CurrentStoryUID = 0 ;
	protected int m_CurrentTakeUID = 0 ;
#if ENABLE_USE_TIME	
	private float m_StartTime = 0.0f ;
#endif	
	protected bool m_MouseIsDown = false ;
	
	public bool StoryIsPlayed( int _StoryUID )
	{
		bool ret = false ;
		Story story = GetStory( _StoryUID );
		if( null != story )
		{
			ret = story.IsPlayed ;
		}
		return ret ;
	}

	public List<Story> Stories
	{ 
		get { return m_Stories ; } 
		set { m_Stories = value ; } 
	}
	private List<Story> m_Stories = new List<Story>() ;

	public List<Take> Takes
	{ 
		get { return m_Takes ; } 
		set { m_Takes = value ; } 
	}
	private List<Take> m_Takes = new List<Take>() ;

	private List<int> m_StartingQueue = new List<int>() ;
	
	public void ActiveConversation( int _StoryUID )
	{
		// Debug.Log( "ActiveConversation()" + _StoryUID ) ;
		m_StartingQueue.Add( _StoryUID ) ;
	}
	
	// Use this for initialization
	void Start () 
	{
#if ENABLE_ConversationGUISystem	
		m_ConversationGUIManager = this.gameObject.GetComponent<ConversationUIBase>() ;
		if( null == m_ConversationGUIManager )
		{
			Debug.LogError( "null == m_ConversationGUIManager" ) ;
		}
#endif
		ShowDialogUI( false ) ;
	}
	
	// Update is called once per frame
	void Update () 
	{
		switch( m_State )
		{
		case ConversationManagerState.UnActive :
			CheckQueue() ;
			break ;
		case ConversationManagerState.Starting :
			ShowDialogUI( true ) ;
#if ENABLE_USE_TIME			
			m_State = ConversationManagerState.WaitEnd ;
#else
			m_State = ConversationManagerState.WaitForInput ;
#endif			
			break ;
		case ConversationManagerState.WaitEnd :
			WaitEnd() ;
			break ;
		case ConversationManagerState.WaitForInput :
			if( true == CheckIfPress() )
			{
				PlayNext() ;
			}
			break ;
		case ConversationManagerState.Closing :
			ShowDialogUI( false ) ;
			m_State = ConversationManagerState.Close ;
			break ;
		case ConversationManagerState.Close :
			m_State = ConversationManagerState.UnActive ;
			break ;			
		}
	
	}
	
	protected virtual bool CheckIfPress()
	{
		bool ret = false ;
		if( false == m_MouseIsDown &&
		    true == Input.GetMouseButtonDown( 0 ) )
		{
			m_MouseIsDown = true ;
			ret = true ;
		}
		else if( true == m_MouseIsDown && 
		         false == Input.GetMouseButtonDown( 0 ))
		{
			m_MouseIsDown = false ;
		}
		return ret ; 
	}
	
	protected virtual void PlayNext()
	{
		Story story = GetStory( m_CurrentStoryUID ) ;
		if( m_CurrentTakeUID == story.EndTakeUID )
		{
			// no more next
			// Debug.Log( "m_CurrentTakeUID == story.EndTakeUID" ) ;
			story.IsPlayed = true ;
			m_State = ConversationManagerState.Closing ;
		}
		else
		{
			int takeIndex = GetTakeIndex( m_CurrentTakeUID ) ;
			++takeIndex ;
			if( takeIndex >= m_Takes.Count )
			{
				// no more next
				// Debug.Log( "takeIndex >= m_Takes.Count" ) ;
				story.IsPlayed = true ;
				m_State = ConversationManagerState.Closing ;
			}
			else
			{
				m_CurrentTakeUID = m_Takes[ takeIndex ].TakeUID ;

				ShowDialogUI( true ) ;

				#if ENABLE_USE_TIME			
				m_State = ConversationManagerState.WaitEnd ;
				#else
				m_State = ConversationManagerState.WaitForInput ;
				#endif							
			}
		}
	}
	
	protected virtual void CloseConversationGUI()
	{
		Debug.Log( "CloseConversationGUI()" ) ;
#if ENABLE_ConversationGUISystem
		m_ConversationGUIManager.TryInitializedStructure() ;
		m_ConversationGUIManager.ShowDialog( false ) ;
		m_ConversationGUIManager.ShowPotraitLeft( false ) ;
		m_ConversationGUIManager.ShowPotraitRight( false ) ;
#endif	
	}
	
	protected virtual void ShowDialogUI( bool _Show )
	{
		
		if( false == _Show )
		{
			CloseConversationGUI() ;
		}
		else
		{
			int takeIndex = GetTakeIndex( m_CurrentTakeUID ) ;
			
			if( takeIndex < 0 || takeIndex >= m_Takes.Count )
			{
				Debug.LogError( "takeIndex >= m_Takes.Count takeIndex=" + takeIndex ) ;
				return ;
			}

			Take take = m_Takes[ takeIndex ] ;
			if( null == take )
			{
				Debug.LogError( "null == take" ) ;
				return ;
			}
			else
			{
				
				// potrait
				bool showLeft = ( string.Empty != take.PotraitLeft ) ;
				
#if ENABLE_ConversationGUISystem
				m_ConversationGUIManager.ShowPotraitLeft( showLeft ) ;
#endif					
				bool showRight = ( string.Empty != take.PotraitRight ) ;
#if ENABLE_ConversationGUISystem
				m_ConversationGUIManager.ShowPotraitRight( showRight ) ;
#endif				

				if( true == showLeft )
				{
#if ENABLE_ConversationGUISystem					
					string p1 = take.PotraitLeft ;
					m_ConversationGUIManager.SetPotraitLeft( p1 ) ;
#endif
				}
				
				if( true == showRight )
				{
#if ENABLE_ConversationGUISystem				
					string p1 = take.PotraitRight ;
					m_ConversationGUIManager.SetPotraitRight( p1 ) ;
#endif						
				}

				// content
				// Debug.Log( "take.Contents.Count=" + take.Contents.Count ) ;
				bool showDialog = ( string.Empty != take.ContentString ) ;
#if ENABLE_ConversationGUISystem				
				m_ConversationGUIManager.ShowDialog( showDialog ) ;
#endif					
				if( true == showDialog )
				{
#if ENABLE_ConversationGUISystem
					m_ConversationGUIManager.SetContent( take.ContentString ) ;
#endif
				}

#if ENABLE_USE_TIME
				m_StartTime = Time.time ;
#endif 				
			}


		}
	}
	
	private void CheckQueue()
	{
		if( ConversationManagerState.UnActive != m_State )
			return ;
		
		if( m_StartingQueue.Count > 0 )
		{
			int retreiveStoryUID = m_StartingQueue[ 0 ] ;
			m_StartingQueue.RemoveAt( 0 ) ;
			
			Story s = GetStory( retreiveStoryUID ) ;
			if( null != s )
			{
				m_CurrentStoryUID = retreiveStoryUID ;
				m_CurrentTakeUID = s.StartTakeUID ;
				m_State = ConversationManagerState.Starting ;
			}

		}
	}

	protected Story GetStory( int _StoryUID )
	{
		foreach( Story s in m_Stories )
		{
			if( _StoryUID == s.StoryUID )
			{
				return s ;
			}
		}
		return null ;
	}

	protected int GetTakeIndex( int _TakeUID )
	{
		for( int i = 0 ; i < m_Takes.Count ; ++i )
		{
			if( _TakeUID == m_Takes[ i ].TakeUID )
			{
				return i ;
			}
		}
		return -1 ;
	}

	private void WaitEnd()
	{
		int index = GetTakeIndex( m_CurrentTakeUID ) ;
		if( index >= m_Takes.Count )
		{
			// warning
			return ;
		}

		// Take currentTake = m_Takes[ index ] ;
	}
}

