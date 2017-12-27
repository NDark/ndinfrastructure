using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateIndexExample : MonoBehaviour 
{
	public enum ExampleState 
	{
		Init 
		, Check
		, Wait
		, End
	}

	public class UStateExample : UState<ExampleState> 
	{

	}

	UStateExample m_State = new UStateExample() ;

	// Use this for initialization
	void Start () 
	{
		Dictionary<ExampleState,TransitionSet> transitions = new Dictionary<ExampleState, TransitionSet>() ;

		transitions.Add( ExampleState.Init , new TransitionSet{ OnExit = ()=>{Debug.Log("Init exits");} } ) ;
		transitions.Add( ExampleState.Check , new TransitionSet{ OnEnter = ()=>{Debug.Log("Check enters");} , OnUpdate = CheckUpdate , OnExit = ()=>{Debug.Log("Check exits");} } ) ;
		transitions.Add( ExampleState.Wait , new TransitionSet{ OnEnter = ()=>{Debug.Log("Wait enters");} , OnExit = ()=>{Debug.Log("Wait exits");} } ) ;
		transitions.Add( ExampleState.End , new TransitionSet{ OnEnter = ()=>{Debug.Log("End enters");} } ) ;
		m_State.CallInit( ExampleState.Init , transitions ) ;

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
