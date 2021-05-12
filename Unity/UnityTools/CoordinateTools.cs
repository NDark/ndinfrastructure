/**

MIT License

Copyright (c) 2017 - 2021 NDark

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
/**
@file CoordinateTools.cs
@date 20180922 . add UpdateRectFrom3DWorldPos().

*/
using UnityEngine;

public static class CoordinateTools 
{
	public static Vector3 Get2DLocalPosFrom3DWorldPos(Camera _3DCamera
										, Camera _2DCamera
										, Vector3 _3DWorldPos
										, GameObject _Ref2DObj )
	{
		Vector3 screen = _3DCamera.WorldToScreenPoint(_3DWorldPos);
		screen.z = 0;
		Vector3 world = _2DCamera.ScreenToWorldPoint(screen);
		Vector3 local = _Ref2DObj.transform.InverseTransformPoint( new Vector3(world.x, world.y) ) ;
		return local;
	}

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

	public static void UpdateRectFrom3DWorldPos( Camera _3DCamera
		, Vector3 _3DWorldPos
		, RectTransform _2DRect )
	{
		Vector3 screen = _3DCamera.WorldToScreenPoint( _3DWorldPos ) ;
		_2DRect.position = screen;
	}
}
