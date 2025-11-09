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
@file SwitchOpenPlatform.cs
@author NDark
@date 20231115. file started.
@date 20250830. add m_MacOSStoreObj.
@date 20251003 . add condition for more compatibility.

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOpenPlatform : MonoBehaviour 
{
	public GameObject m_GooglePlayMarket = null;
	public GameObject m_AppStore = null;
	public GameObject m_WindowsStore = null;
	public GameObject m_WebGLStore = null;
    public GameObject m_MacOSStoreObj = null;

    // Use this for initialization
    void Awake()
	{
		SetupStructure();
	}

    void Start()
    {
        SwitchObject();
    }

	void SwitchObject()
	{
        int validCount = 0;
        foreach (var platform in m_SwitchingObjects)
        {
            bool isShow = (platform.Key == Application.platform);
            if (isShow)
            {
                ++validCount;
            }

			if (null != platform.Value) 
			{
				platform.Value.SetActive(isShow); 
			}
        }


#if UNITY_EDITOR
        if ( Application.isEditor
            && validCount <= 0
            && m_SwitchingObjects.ContainsKey(RuntimePlatform.Android) 
            )
        {
            Debug.LogWarning("SwitchOpenPlatform::SwitchObject() Application.isEditor");
			if(null!= m_SwitchingObjects[RuntimePlatform.Android])
			{
				m_SwitchingObjects[RuntimePlatform.Android].SetActive(true);
			}
        }
#endif 

    }

	void SetupStructure()
	{
        m_SwitchingObjects.Clear();
        if (null != m_AppStore)
        {
            m_SwitchingObjects.Add( RuntimePlatform.IPhonePlayer, m_AppStore);
        }

        if (null != m_GooglePlayMarket)
        {
            m_SwitchingObjects.Add( RuntimePlatform.Android , m_GooglePlayMarket);
        }

        if ( null != m_WindowsStore )
        {
            m_SwitchingObjects.Add( RuntimePlatform.WindowsPlayer , m_WindowsStore);
        }

        if ( null != m_WebGLStore )
        {
            m_SwitchingObjects.Add( RuntimePlatform.WebGLPlayer , m_WebGLStore);
        }

        if (null != m_MacOSStoreObj)
        {
            m_SwitchingObjects.Add(RuntimePlatform.OSXPlayer, m_MacOSStoreObj);
        }

    }

    Dictionary<UnityEngine.RuntimePlatform, GameObject> m_SwitchingObjects = new Dictionary<RuntimePlatform, GameObject>();
}
