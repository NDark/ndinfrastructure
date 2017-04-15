using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TriggerCheckerState
{
	Disable ,
	Active ,
	IsTriggered ,
}

public class TriggerChecker 
{
	public string Label { get; set; }
	public string Value { get; set; }
	public string Operator { get; set; }
	public TriggerCheckerState TriggerState { get { return m_TriggerState; } set { m_TriggerState = value; } } 
	public int TriggerValue { get; set; }

	TriggerCheckerState m_TriggerState = TriggerCheckerState.Disable ;
}
