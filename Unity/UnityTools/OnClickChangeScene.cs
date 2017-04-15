/**
@file OnClickChangeScene.cs
@author NDark
@date 20170402 . file started.

*/
using UnityEngine;

public class OnClickChangeScene : MonoBehaviour 
{
	public string m_SceneName = string.Empty ;

	void OnClick()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene ( m_SceneName );
	}
}
