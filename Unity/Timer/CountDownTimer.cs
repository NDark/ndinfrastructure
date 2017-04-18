using UnityEngine;

public class CountDownTimer
{
	public float IntervalSec { get{return m_IntervalSec;} set{ m_IntervalSec = value ;} } 

	public void Rewind()
	{
		m_NextTime = Time.time + m_IntervalSec;
	}

	public bool IsReady() 
	{
		return ( Time.time > m_NextTime ) ;
	}

	float m_NextTime = 0.0f ;
	float m_IntervalSec = float.MaxValue ;
}
