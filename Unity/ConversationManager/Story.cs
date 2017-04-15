/**
@file Story.cs
@author NDark
@date 20140308 file started.

@date 20150402 by NDark . copy from Ntust2013Unity.

*/
using UnityEngine;

public class Story
{
	public bool IsPlayed = false ;
	
	public int StoryUID
	{
		get { return m_StoryUID ; }
		set { m_StoryUID = value ; }
	}
	private int m_StoryUID = 0 ;
	
	public int StartTakeUID
	{
		get { return m_StartTakeUID ; }
		set { m_StartTakeUID = value ; }
	}
	private int m_StartTakeUID = 0 ;
	
	public int EndTakeUID
	{
		get { return m_EndTakeUID ; }
		set { m_EndTakeUID = value ; }
	}
	private int m_EndTakeUID = 0 ;
}
