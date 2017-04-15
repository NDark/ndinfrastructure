using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public static partial class JSONParseUtility 
{
	
	/*

	{"TriggerChecker":{"Label":"PlayerLV","Value":"10","Operator":"=","TriggerState":"Active","TriggerValue":1001} }
	*/
	public static bool ParseTriggerChecker( JSONNode _node ,
	                             ref TriggerChecker _Checker )
	{
		const string TriggerChecker_KEY = "TriggerChecker" ;
		const string Label_KEY = "Label" ;
		const string Value_KEY = "Value" ;
		const string Operator_KEY = "Operator" ;
		const string TriggerState_KEY = "TriggerState" ;
		const string TriggerValue_KEY = "TriggerValue" ;
		
		if( false == _node.IsContains( TriggerChecker_KEY ) )
		{
			return false;
		}
		
		JSONNode contentNode = _node[ TriggerChecker_KEY ] ;

		if( true == contentNode.IsContains( Label_KEY ) )
		{
			_Checker.Label= contentNode[ Label_KEY ].Value ;
		}
		
		if( true == contentNode.IsContains( Value_KEY ) )
		{
			_Checker.Value = contentNode[ Value_KEY ].Value ;
		}
		
		if( true == contentNode.IsContains( Operator_KEY ) )
		{
			_Checker.Operator = contentNode[ Operator_KEY ].Value ;
		}
		
		if( true == contentNode.IsContains( TriggerState_KEY ) )
		{
			switch( contentNode[ TriggerState_KEY ].Value ) 
			{
			case "Disable" :
				_Checker.TriggerState = TriggerCheckerState.Disable ;
				break ;
			case "Active" :
				_Checker.TriggerState = TriggerCheckerState.Active ;
				break ;
			case "IsTriggered" :
				_Checker.TriggerState = TriggerCheckerState.IsTriggered ;
				break ;
			}

		}
		
		if( true == contentNode.IsContains( TriggerValue_KEY ) )
		{
			_Checker.Value = contentNode[ TriggerValue_KEY ].Value ;
		}

		return true ;
		
	}

}
