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
@file WaitDisableGameObject.cs
@author NDark
@date 20210530 . file started.

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitDisableGameObject : MonoBehaviour 
{
	public bool IsDestroyAtTheEnd = false;
	public float WaitSec = 1.0f ;

	void Update () 
	{
		if( float.MaxValue == m_CheckTime )
		{
			if( this.gameObject.activeSelf )
			{
				SetupTime() ;
			}
		}
		else
		{
			if( Time.time > m_CheckTime )
			{
				if (true == IsDestroyAtTheEnd)
				{
					GameObject.Destroy(this.gameObject);
				}
				else
				{
					this.gameObject.SetActive(false);
				}
				m_CheckTime = float.MaxValue ;// never check again
			}
		}
	}
	
	public void SetupTime() 
	{
		m_CheckTime = Time.time + this.WaitSec;
	}
	
	float m_CheckTime = float.MaxValue ;
}
