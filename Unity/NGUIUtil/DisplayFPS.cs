/**

MIT License

Copyright (c) 2017 - 2020 NDark

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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayFPS : MonoBehaviour 
{
	public UILabel m_Label = null ;

	// Use this for initialization
	void Start () 
	{
		
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if( null != m_Label )
		{
			if( fpsVec.Count < m_Length )
			{
				fpsVec.Add( Time.deltaTime ) ;
			}
			else
			{
				fpsVec[ m_Index++ ] = Time.deltaTime ;
				if( m_Index >= m_Length )
				{
					m_Index = 0 ;
				}
			}
			
			float max = float.MinValue ;
			float min = float.MaxValue ;
			float sum = 0.0f ;
			for( int i = 0 ; i < fpsVec.Count ; ++i )
			{
				sum += fpsVec[ i ] ;
				
				if( fpsVec[ i ] > max )
				{
					max = fpsVec[ i ] ;
				}
				if( fpsVec[ i ] < min )
				{
					min = fpsVec[ i ] ;
				}
				
			}
			
			
			m_Label.text = string.Format( "avg:{0:#.##}/M:{1:#.##}/m:{2:#.##}" 
			                             , fpsVec.Count / sum 
			                             , 1.0f / min 
			                             , 1.0f / max );
		}
	}
	
	int m_Length = 20 ;
	int m_Index = 0 ;
	List<float> fpsVec = new List<float>() ;
}
