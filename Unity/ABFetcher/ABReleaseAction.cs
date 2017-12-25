/**
@file ABReleaseAction.cs
@author NDark
@date 20171225 . file started.
*/

public enum ABReleaseCommand
{
	Unload 
	, Load
}

public class ABReleaseAction 
{
	public string Key ;
	public ABReleaseCommand Command ;
}
