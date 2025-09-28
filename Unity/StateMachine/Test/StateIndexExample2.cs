/**

MIT License

Copyright (c) 2017 - 2025 NDark

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

public class StateIndexExample2 : MonoBehaviour 
{
	public enum ExampleState 
	{
		Init 
		, Check
		, Wait
		, End
	}

	public class UStateExample2 : UState<ExampleState> 
	{
		public override void ChangeState(ExampleState _Next)
		{

			if (m_CurrentValue.Equals(_Next))
			{
				return;
			}
			if (this.m_NextValue.Equals(_Next))
			{
				return;
			}

			bool allowedTransit =
				m_AllowTransitions.TryGetValue(m_CurrentValue, out AllowTransitionData allowData)
				&& null != allowData
				&& allowData.AllowTargetStates.Contains(_Next) ;
			if (!allowedTransit)
			{
				Debug.LogError($"not allowed allowData.AllowTargetStates from {this.m_CurrentValue} to {_Next}");
				return;
			}

			m_NextValue = _Next;
			m_IsInTransition = true;
			m_ChangeTime = Time.time;


		}
	}

	UStateExample2 m_State = new UStateExample2() ;

	// Use this for initialization
	void Start () 
	{
		Dictionary<ExampleState,TransitionSet> transitions = new Dictionary<ExampleState, TransitionSet>() ;

		transitions.Add( ExampleState.Init , new TransitionSet{ OnExit = ()=>{Debug.Log("Init exits");} } ) ;
		transitions.Add( ExampleState.Check , new TransitionSet{ OnEnter = ()=>{Debug.Log("Check enters");} , OnUpdate = CheckUpdate , OnExit = ()=>{Debug.Log("Check exits");} } ) ;
		transitions.Add( ExampleState.Wait , new TransitionSet{ OnEnter = ()=>{Debug.Log("Wait enters");} , OnExit = ()=>{Debug.Log("Wait exits");} } ) ;
		transitions.Add( ExampleState.End , new TransitionSet{ OnEnter = ()=>{Debug.Log("End enters");} } );

		Dictionary<ExampleState, StateIndexBase<ExampleState>.AllowTransitionData > allowedTransitionData = new Dictionary<ExampleState, StateIndexBase<ExampleState>.AllowTransitionData>();

		m_State.CallInit( ExampleState.Init , transitions , allowedTransitionData ) ;

		StartCoroutine( StartSimulateChangeState() ) ;
	}
	
	// Update is called once per frame
	void Update () 
	{
		m_State.CallUpdate( Time.deltaTime ) ;
		
	}

	void CheckUpdate( float _DeltaTime )
	{
		Debug.Log("Check updates");
	}

	IEnumerator StartSimulateChangeState()
	{

		yield return null ;

		Debug.LogWarning("ChangeState ExampleState.Check m_State.CurrentValue=" + m_State.CurrentValue );
		m_State.ChangeState(ExampleState.Check ) ;
		Debug.LogWarning("ChangeState ExampleState.Check m_State.CurrentValue=" + m_State.CurrentValue );
		Debug.LogWarning("ChangeState ExampleState.Check m_State.PreviousValue=" + m_State.PreviousValue );
		Debug.LogWarning("ChangeState ExampleState.Check m_State.NextValue=" + m_State.NextValue );

		yield return new WaitForSeconds( 1 ) ;

		Debug.LogWarning("GetElapsedTime=" + m_State.GetElapsedTime( Time.time ) );
		Debug.LogWarning("ChangeState ExampleState.Wait m_State.CurrentValue=" + m_State.CurrentValue );
		m_State.ChangeState(ExampleState.Wait ) ;

		yield return new WaitForSeconds( 2 ) ;

		Debug.LogWarning("ChangeState ExampleState.End m_State.CurrentValue=" + m_State.CurrentValue );
		m_State.ChangeState(ExampleState.End ) ;

		yield return null ;
		Debug.LogWarning("ChangeState ExampleState.End m_State.CurrentValue=" + m_State.CurrentValue );

	}

}
