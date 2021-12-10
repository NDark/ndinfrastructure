using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSDisplay : MonoBehaviour
{
	UnityEngine.UI.Text m_Text = null;

    // Start is called before the first frame update
    void Start()
    {
		m_Text = this.GetComponent<UnityEngine.UI.Text>();

	}

	// Update is called once per frame
	void Update()
	{

		++frame;
		if (null != m_Text)
		{
			if (Time.realtimeSinceStartup - m_LastUpdate > 1.0f)
			{
				float average = frame / ( Time.realtimeSinceStartup - m_LastUpdate) ;
				m_Text.text = string.Format("{0:0.00}", average);
				frame = 0;
				m_LastUpdate = Time.realtimeSinceStartup;
			}
			
		}
    }

	float m_LastUpdate = 0.0f;
	int frame= 0;
}
