using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StateIndexBase<T>
{
	public StateIndexBase()
	{
	}

	public StateIndexBase( T _InitState )
	{
		m_NextValue = m_CurrentValue = m_PreviousValue = _InitState ;
	}

	public virtual void CallInit( Dictionary<T,TransitionSet>  _Transitions )
	{
		m_Transitions = _Transitions ;
	}

	public virtual void TryAddTransitionSet( T _State , TransitionSet _Set )
	{
		if( !m_Transitions.ContainsKey( _State) )
		{
			m_Transitions.Add( _State , _Set ) ;
		}
		else
		{
			m_Transitions[_State] = _Set ;
		}
	}

	public virtual void ChangeState( T _Next )
	{
		if( m_CurrentValue.Equals( _Next ) )
		{
			return ;
		}
		if( m_NextValue.Equals( _Next ) )
		{
			return ;
		}
		m_NextValue = _Next ;
		m_IsInTransition = true ;
	}

	// Update is called once per frame
	public virtual void CallUpdate ( float _DeltaTime ) 
	{
		TransitionSet currentStateFuncs = null ;
		m_Transitions.TryGetValue( m_CurrentValue , out currentStateFuncs ) ;

		if( false == m_IsInTransition )
		{
			if( null != currentStateFuncs )
			{
				currentStateFuncs.OnUpdate( _DeltaTime ) ;
			}	
		}
		else
		{
			m_PreviousValue = m_CurrentValue ;
			m_CurrentValue = m_NextValue ;

			m_Transitions.TryGetValue( m_CurrentValue , out currentStateFuncs ) ;
			if( null != currentStateFuncs )
			{
				currentStateFuncs.OnEnter() ;
				currentStateFuncs.OnUpdate( _DeltaTime ) ;
			}

			m_IsInTransition = false ;
		}
	}

	public T CurrentValue
	{
		get { return m_CurrentValue ; } 
	}
	public T PreviousValue
	{
		get { return m_PreviousValue ; } 
	}
	public T NextValue
	{
		get { return m_NextValue ; } 
	}

	bool m_IsInTransition = false ;

	T m_CurrentValue ;
	T m_PreviousValue ;
	T m_NextValue ;

	Dictionary<T,TransitionSet> m_Transitions = new Dictionary<T, TransitionSet>() ;

}

public class TransitionSet
{
	public System.Action OnEnter = new System.Action( ()=>{} ) ;
	public System.Action<float> OnUpdate = new System.Action<float>( (deltaTime)=>{} ) ;
	public System.Action OnExit = new System.Action( ()=>{} ) ;
}