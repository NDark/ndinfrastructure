using UnityEngine;

public static class UnityFind 
{
	public static GameObject GameObjectFind( GameObject _Obj , string _Name )
	{
		if( null != _Obj )
		{
			var trans = _Obj.transform.Find( _Name );
			if( null != trans )
			{
				return trans.gameObject ;
			}
		}
		return null ;
	}
	
	public static T ComponentFind<T>( Transform _Root , string _Name )
	{
		var trans = _Root.Find( _Name );
		if( null == trans )
		{
			Debug.LogError( _Name );
			return default(T) ;
		}
		
		var c = trans.gameObject.GetComponent<T>();
		if( null == c )
		{
			Debug.LogError( "null == c" );
			return default(T) ;
		}
		return c;
	}
	
	
}

