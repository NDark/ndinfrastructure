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
