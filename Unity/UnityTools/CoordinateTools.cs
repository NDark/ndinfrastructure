using UnityEngine;

public static class CoordinateTools 
{

	public static void Update2DFrom3DWorldPos( Camera _3DCamera
	                                        , Camera _2DCamera
	                                        , Vector3 _3DWorldPos
	                                        , GameObject _2DObj )
	{
		Vector3 screen = _3DCamera.WorldToScreenPoint( _3DWorldPos ) ;
		screen.z = 0 ;
		Vector3 world = _2DCamera.ScreenToWorldPoint( screen ); 
		_2DObj.transform.position = new Vector3( world.x , world.y ) ;

		Vector3 local = _2DObj.transform.localPosition ;
		local.z = 0 ;
		_2DObj.transform.localPosition = local ;
	}

}
