/**
@file Take.cs
@author NDark
@date 20140308 file started.

@date 20150402 by NDark . copy from Ntust2013Unity.

 */
using UnityEngine;

public class Take
{
	public int TakeUID
	{
		get { return m_TakeUID ; }
		set { m_TakeUID = value ; }
	}
	private int m_TakeUID = 0 ;
	
	public string PotraitLeft
	{
		get { return m_PotraitLeft ; }
		set { m_PotraitLeft = value ; }
	}
	private string m_PotraitLeft = "" ;

	public string PotraitRight
	{
		get { return m_PotraitRight ; }
		set { m_PotraitRight = value ; }
	}
	private string m_PotraitRight = "" ;
	
	public string ContentString
	{
		get { return m_ContentString ; }
		set { m_ContentString = value ; }
	}
	private string m_ContentString = "" ;
}
