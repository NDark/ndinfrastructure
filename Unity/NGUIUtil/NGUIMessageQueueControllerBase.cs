using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NGUIMessageQueueControllerBase : MonoBehaviour 
{

	public virtual string CurrentText
	{
		get{ return string.Empty;}
		set{ }
	}

	public virtual Vector3 CurrentTextPosition
	{
		get{ return Vector3.zero;}
		set{ }
	}

	public virtual Color CurrentTextColor
	{
		get{ return Color.black;}
		set{ }
	}


	public virtual void ShowUI( bool _Show )
	{

	}

	public void QueueText( string _Text )
	{
		m_MessageQueue.AddLast( _Text ) ;
	}



	void Awake() 
	{
		SetupStructure() ;
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		MessageUpdate();
		
	}

	protected virtual void MessageUpdate()
	{
		if( m_InAnimation )
		{
			CheckAnimationEnd() ;
		}
		else if( m_MessageQueue.Count > 0 )
		{
			RestartAnimation(m_MessageQueue.First.Value) ;
			m_MessageQueue.RemoveFirst() ;
		}
	}


	protected virtual void RestartAnimation( string _Text )
	{
		/** Reset animation position */
		UpdateText( _Text ) ;
		m_InAnimation = true ;
	}


	protected virtual void UpdateText( string _Text )
	{
		// assign text.
	}


	protected virtual void CheckAnimationEnd() 
	{
		// check animation has finished.
		/*
		if( m_MessageTweenPosition.isActiveAndEnabled == false &&
			m_MessageTweenAlpha.isActiveAndEnabled == false )
		{
			m_InAnimation = false ;

			if (0 == m_MessageQueue.Count)
			{
				ShowUI(false);
			}
		}
		*/

	}

	public virtual void TrySetupStructure() 
	{
		if (!m_Initializaed)
		{
			SetupStructure();
		}
	}

	protected virtual void SetupStructure() 
	{
		m_Initializaed = true;
	}

	protected bool m_InAnimation = false ;
	protected LinkedList<string> m_MessageQueue = new LinkedList<string>() ;

	public bool IsInitialized { get { return m_Initializaed; } }
	protected bool m_Initializaed = false ;

}
