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
