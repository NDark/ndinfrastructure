/**

MIT License

Copyright (c) 2017 - 2025 NDark

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
@file PreTimeUpdator.cs
@author NDark
@date 20241018 . file started.

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreTimeUpdator : MonoBehaviour 
{
	public bool FlowAsTime = true;
	public static float TimeTime ;
	public static float TimeDeltaTime ;
	public static int FrameCount = 0 ;
	public static int RecordedTurn = 0 ;
	public static bool s_FlowAsTime = true;

	public static void CallUpdateOnce()
	{
		TimeFlow (Time.deltaTime);
	}

	public static void TimeFlow( float deltaTime )
	{
		PreTimeUpdator.TimeTime += deltaTime;
		PreTimeUpdator.TimeDeltaTime = deltaTime;
		++PreTimeUpdator.FrameCount;
		// Debug.Log("TimeTime=" + TimeTime );
	}

	void Awake()
	{
		PreTimeUpdator.s_FlowAsTime = this.FlowAsTime;
		PreTimeUpdator.TimeTime = Time.time; // init
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if ( this.FlowAsTime && true == PreTimeUpdator.s_FlowAsTime) 
		{
			TimeFlow (Time.deltaTime);
		} 
		else 
		{
			PreTimeUpdator.TimeDeltaTime = 0.0f ;
		}
	}

}
