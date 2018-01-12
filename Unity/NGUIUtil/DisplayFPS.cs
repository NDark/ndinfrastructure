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
