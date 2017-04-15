/**
@file NGUISetLocalization.cs
@author NDark
@date 20170402 . file started.

*/
using UnityEngine;


public class NGUISetLocalization : MonoBehaviour 
{
	public string m_LanguageKey = string.Empty ;
	
	public void SetLanguage()
	{
		NGUIInfrastructure.SetNGUILocalization( m_LanguageKey ) ;
	}
	

}
