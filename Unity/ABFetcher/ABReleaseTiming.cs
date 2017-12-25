/**
@file ABReleaseTiming.cs
@author NDark
@date 20171225 . file started.
*/

public enum ABReleaseTiming : int
{
	KeepUnload = 0 
	, LoadByDemand 
	, UnloadByDemand
	, KeepLoaded
	, Expired 
}

