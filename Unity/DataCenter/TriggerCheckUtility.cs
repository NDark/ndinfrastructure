using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TriggerCheckUtility
{
	const string CONST_OPERATOR_EQUAL = "==" ;

	public static bool IsTriggered( DataPage _Center , TriggerChecker _Checker )
	{
		bool ret = false;
		string valueInCenter = _Center.Get( _Checker.Label ) ;
		string valueStandard = _Checker.Value;
		if( string.Empty != valueInCenter )
		{
			ret = IsTriggered( valueInCenter , _Checker.Value , _Checker.Operator ) ;
		}
		return ret;
	}

	public static bool IsTriggered( string _Value , string _Standard , string _Operator )
	{
		bool ret = false;

		switch( _Operator )
		{
		case CONST_OPERATOR_EQUAL :
			ret = (_Value == _Standard) ;
			break ;
		}

		return ret;
	}
}
