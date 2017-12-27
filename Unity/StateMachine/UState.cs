using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UState<T> : StateIndexBase<T>
{
	public virtual void ChangeState( T _State )
	{
		this.ChangeState( _State , Time.time ) ;
	}
}
