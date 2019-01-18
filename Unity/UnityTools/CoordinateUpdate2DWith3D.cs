using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinateUpdate2DWith3D : MonoBehaviour 
{
	public Camera m_3DCamera = null ;
	public Camera m_2DCamera = null ;
	public GameObject m_3DObj = null ;
	public GameObject m_2DObj = null ;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		UpdatePosition() ;
	}

	public void UpdatePosition()
	{
		if( null != m_3DCamera 
			&& null != m_2DCamera
			&& null != m_3DObj
			&& null != m_2DObj
		)
		{
			CoordinateTools.Update2DFrom3DWorldPos( m_3DCamera 
				, m_2DCamera 
				, m_3DObj.transform.position 
				, m_2DObj ) ;
			
		}
	}
}
