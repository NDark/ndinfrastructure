/**
@file ABSetupInfo.cs
@author NDark
@date 20171225 . file started.

*/
using UnityEngine;

public class ABSetupInfo
{
	public string Key { get; set; }
	public int Version { get; set; }
	public string ReleaseTiming = string.Empty ;

	public void DEBUG()
	{
		Debug.Log( "DEBUG_Print(): " + this.ToString() );
	}
	
	public override string ToString ()
	{
		return base.ToString() + string.Format (
			"\n [ABSetupInfo]" 
			+ "\n Key=" + this.Key
			+ "\n Version=" + this.Version
			+ "\n ReleaseTiming=" + this.ReleaseTiming
		);
	}
}

