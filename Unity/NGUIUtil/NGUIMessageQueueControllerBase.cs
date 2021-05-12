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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NGUIMessageQueueControllerBase : MonoBehaviour 
{
	public void ClearQueue()
	{
		m_MessageQueue.Clear();
	}

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
