using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDataConnector 
{
	public DataPage m_DataPageShare = null ;

	public bool CheckTheFirstAndDisableTrigger( ref int _Result )
	{
		bool ret = false;
		var iEnum = m_ActiveTriggerCheckers.GetEnumerator ();
		while (iEnum.MoveNext() ) 
		{
			if( iEnum.Current.Value.TriggerState == TriggerCheckerState.Active
			   && TriggerCheckUtility.IsTriggered( m_DataPageShare , iEnum.Current.Value ) 
			   ) 
			{
				_Result = iEnum.Current.Value.TriggerValue ;
				iEnum.Current.Value.TriggerState = TriggerCheckerState.IsTriggered ;
				break ;
			}
		}
		return ret ;
	}

	private Dictionary< int , TriggerChecker > m_ActiveTriggerCheckers = new Dictionary<int, TriggerChecker>() ;

}
