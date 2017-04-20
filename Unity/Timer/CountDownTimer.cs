/**

MIT License

Copyright (c) 2017 NDark

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
@file CountDownTimer.cs
@author NDark

@date 20170420 by NDark 
. add IsActive
. add Active()
. add Elapsedtime()
. add RemainingTime()
. add NextTime

*/
using UnityEngine;

public class CountDownTimer
{

	public bool IsActive { get; set; }

	public void Active( bool _Set )
	{
		this.IsActive = _Set;
	}

	public void Rewind()
	{
		m_NextTime = Time.time + m_IntervalSec;
	}

	public bool IsReady() 
	{
		return ( Time.time > m_NextTime ) ;
	}

	public float Elapsedtime( float _NowTime , bool _AlwaysNoneNegative )
	{
		float ret = this.IntervalSec - this.RemainingTime( _NowTime , false ) ;
		if( true == _AlwaysNoneNegative && ret < 0.0f )
		{
			ret = 0.0f ;
		}
		return ret ; 
	}

	public float RemainingTime( float _NowTime , bool _AlwaysNoneNegative )
	{
		float ret = m_NextTime - _NowTime ;
		if( true == _AlwaysNoneNegative && ret < 0.0f )
		{
			ret = 0.0f ;
		}
		return ret ; 
	}

	public float NextTime
	{
		get { return m_NextTime ; }
	}
	float m_NextTime = 0.0f ;

	public float IntervalSec 
	{ 
		get
		{
			return m_IntervalSec;
		} 
		set
		{ 
			m_IntervalSec = value ;
		} 
	} 
	float m_IntervalSec = float.MaxValue ;
}
