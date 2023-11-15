using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOpenPlatform : MonoBehaviour 
{
	public GameObject m_GooglePlayMarket = null;
	public GameObject m_AppStore = null;
	public GameObject m_WindowsStore = null;
	public GameObject m_WebGLStore = null;

	// Use this for initialization
	void Start () 
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			if (null != m_AppStore) { m_AppStore.SetActive(true); }
			if (null != m_GooglePlayMarket) { m_GooglePlayMarket.SetActive(false); }
			if (null != m_WindowsStore) { m_WindowsStore.SetActive(false); }
			if (null != m_WebGLStore) { m_WebGLStore.SetActive(false); }
		}
		else if (Application.platform == RuntimePlatform.Android)
		{
			if (null != m_AppStore) { m_AppStore.SetActive(false); }
			if (null != m_GooglePlayMarket) { m_GooglePlayMarket.SetActive(true); }
			if (null != m_WindowsStore) { m_WindowsStore.SetActive(false); }
			if (null != m_WebGLStore) { m_WebGLStore.SetActive(false); }
		}
		else if (Application.platform == RuntimePlatform.WindowsPlayer)
		{
			if (null != m_AppStore) { m_AppStore.SetActive(false); }
			if (null != m_GooglePlayMarket) { m_GooglePlayMarket.SetActive(false); }
			if (null != m_WindowsStore) { m_WindowsStore.SetActive(true); }
			if (null != m_WebGLStore) { m_WebGLStore.SetActive(false); }
		}
		else if (Application.platform == RuntimePlatform.WebGLPlayer)
		{
			if (null != m_AppStore) { m_AppStore.SetActive(false); }
			if (null != m_GooglePlayMarket) { m_GooglePlayMarket.SetActive(false); }
			if (null != m_WindowsStore) { m_WindowsStore.SetActive(false); }
			if (null != m_WebGLStore) { m_WebGLStore.SetActive(true); }
		}
		else
		{
			if (null != m_AppStore) { m_AppStore.SetActive(false); }
			if (null != m_GooglePlayMarket) { m_GooglePlayMarket.SetActive(true); }
			if (null != m_WindowsStore) { m_WindowsStore.SetActive(false); }
			if (null != m_WebGLStore) { m_WebGLStore.SetActive(false); }
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
