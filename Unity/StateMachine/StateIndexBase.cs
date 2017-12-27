/**

MIT License

Copyright (c) 2017 NDark

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
using System.Collections.Generic;

public class StateIndexBase<T>
{
	public StateIndexBase()
	{
	}

	public StateIndexBase( T _InitState )
	{
		m_NextValue = m_CurrentValue = m_PreviousValue = _InitState ;
	}

	public virtual void CallInit( T _InitState , Dictionary<T,TransitionSet>  _Transitions )
	{
		m_NextValue = m_CurrentValue = m_PreviousValue = _InitState ;
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

	public virtual void ChangeState( T _Next , float _TimeNow )
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
		m_ChangeTime = _TimeNow ;


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
			m_Transitions.TryGetValue( m_CurrentValue , out currentStateFuncs ) ;
			if( null != currentStateFuncs )
			{
				currentStateFuncs.OnExit() ;
			}

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

	public float ChangeTime
	{
		get { return m_ChangeTime ;}
	}
	public float GetElapsedTime( float _TimeNow )
	{
		return _TimeNow - m_ChangeTime ;
	}

	bool m_IsInTransition = false ;

	T m_CurrentValue ;
	T m_PreviousValue ;
	T m_NextValue ;

	Dictionary<T,TransitionSet> m_Transitions = new Dictionary<T, TransitionSet>() ;
	float m_ChangeTime = 0.0f ;
}

public class TransitionSet
{
	public System.Action OnEnter = new System.Action( ()=>{} ) ;
	public System.Action<float> OnUpdate = new System.Action<float>( (deltaTime)=>{} ) ;
	public System.Action OnExit = new System.Action( ()=>{} ) ;
}