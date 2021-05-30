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
@file ShakeGameObject.cs
@author NDark
@date 20210530 . file started.

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeGameObject : MonoBehaviour 
{
	public float ShakeSec = 0.5f ;
	public float ShakeDistance = 0.1f;
	public bool IsDestroyAtTheEnd = false;

	public void Active()
	{
		m_ShakerTimer.Active(true);
		m_ShakerTimer.IntervalSec = ShakeSec;
		m_ShakerTimer.Rewind(Time.time);
	}

	public void Reset()
	{
		m_ShakerTimer.Active(false);
		this.Init();	
	}

	public void Init()
	{
		this.orgLocalPos = this.transform.localPosition;
	}

	void Awake() 
	{
		m_ShakerTimer.Active(false);
	}

	// Use this for initialization
	void Start () 
	{
		Init();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (m_ShakerTimer.IsActive )
		{
			if (m_ShakerTimer.IsReady(Time.time))
			{
				// stop
				this.Reset();
				if (IsDestroyAtTheEnd)
				{
					Component.Destroy(this);
				}
				return ;
			}

			ShakeLocalPosition();
		}
	}

	void ShakeLocalPosition()
	{
		Vector3 offset = Random.onUnitSphere * this.ShakeDistance;
		offset.y = 0;// local y
		this.transform.localPosition = orgLocalPos + offset;
	}

	Vector3 orgLocalPos = Vector3.zero ;
	CountDownTimer m_ShakerTimer = new CountDownTimer() ;

}
