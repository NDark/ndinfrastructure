/**
@file NGUIInfrastructure.cs
@author NDark
@date 20170402 file started.

*/
#define NDU_INFRASTRUCTURE_USE_NGUI
using UnityEngine;

public static partial class NGUIInfrastructure
{

	public static void SetNGUILocalization( string _Language )
	{
		#if NDU_INFRASTRUCTURE_USE_NGUI		
		Localization.language = _Language ;
		#endif // NDU_INFRASTRUCTURE_USE_NGUI
	}
	
	

}
