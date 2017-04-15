/**
@file ConversationUIBase.cs
@author NDark

@date 20170401 file started.

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationUIBase : MonoBehaviour 
{
	public virtual void ShowDialog( bool _Show )
	{
		// Debug.Log( "null != m_DialogBackground" + (null != m_DialogBackground)) ;
	}

	public virtual void ShowPotraitLeft( bool _Show )
	{

	}
	
	public virtual void SetPotraitLeft( string _SpriteName )
	{

	}
		
	public virtual void ShowPotraitRight( bool _Show )
	{

	}
	
	public virtual void SetPotraitRight( string _SpriteName )
	{

	}
	
	public virtual void SetContent( string _Content )
	{

	}

	public virtual void TryInitializedStructure()
	{
	}
}
