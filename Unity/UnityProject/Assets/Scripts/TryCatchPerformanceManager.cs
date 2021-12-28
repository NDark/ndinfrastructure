using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryCatchPerformanceManager : MonoBehaviour
{
	public bool m_IsLog = true;
	public bool m_IsTrigger = false;
	public bool m_IsDestroy = true;
	public UnityEngine.UI.Text m_DebugText = null;
	public UnityEngine.UI.Text m_BrokenText = null; 
	public GameObject m_Prefab = null;

	public void SwitchTrigger()
	{
		m_IsTrigger = !m_IsTrigger;
		Debug.Log("m_IsTrigger" + m_IsTrigger);
		m_DebugText.text = "m_IsTrigger" + m_IsTrigger;
	}

    // Start is called before the first frame update
    void Start()
    {
		Application.targetFrameRate = -1;
		Debug.Log("Application.targetFrameRate"+ Application.targetFrameRate);
    }

    // Update is called once per frame
    void Update()
    {
		TryTriggerTryCatch();
    }

	List<GameObject> objs = new List<GameObject>();

	void TryTriggerTryCatch()
	{


		try
		{
			for (int i = 0; i < 100; ++i)
			{
				objs.Add(GameObject.Instantiate(m_Prefab));
			}

			if (m_IsTrigger)
			{
				m_BrokenText.text = objs.Count.ToString();
			}

		}
		catch (System.Exception e)
		{
			if (m_IsLog)
			{
				// Debug.LogWarning(e.ToString());
			}
		}

		if (m_IsDestroy)
		{
			foreach (var o in objs)
			{
				GameObject.Destroy(o);
			}
			objs.Clear();
		}

	}


}
