/*
@file XMLParseUtility.cs
@author NDark
@date 20170401 file started.

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public static partial class XMLParseUtility 
{

	/*
	<Take TakeUID="2" PotraitLeft="Orc" PotraitRight="" ContentString="Cowbay" />
	*/
	public static bool ParseTake( XmlNode _node ,
	                              ref Take _Take )
	{
		const string TAKE_KEY = "Take" ;
		const string TAKE_UID_KEY = "TakeUID" ;
		const string POTRAIT_LEFT_KEY = "PotraitLeft" ;
		const string POTRAIT_RIGHT_KEY = "PotraitRight" ;
		const string CONTENT_STRING_KEY = "ContentString" ;

		if( TAKE_KEY != _node.Name )
		{
			Debug.LogError("TAKE_KEY != _node.Name ");
			return false ;
		}

		if( null != _node.Attributes[ TAKE_UID_KEY ] )
		{
			int takeUID = 0 ;
			int.TryParse( _node.Attributes[ TAKE_UID_KEY ].Value , out takeUID ) ;
			_Take.TakeUID = takeUID ;
		}
		
		if( null != _node.Attributes[ POTRAIT_LEFT_KEY ] )
		{
			_Take.PotraitLeft = _node.Attributes[ POTRAIT_LEFT_KEY ].Value ;
		}
					
		if( null != _node.Attributes[ POTRAIT_RIGHT_KEY ] )
		{
			_Take.PotraitRight = _node.Attributes[ POTRAIT_RIGHT_KEY ].Value ;
		}
		
		if( null != _node.Attributes[ CONTENT_STRING_KEY ] )
		{
			_Take.ContentString = _node.Attributes[ CONTENT_STRING_KEY ].Value ;
		}

		return true ;

	}
	
	/**
	<Story StoryUID="1" StartTakeUID="1" EndTakeUID="5" />
	*/
	public static bool ParseStory( XmlNode _node ,
	                             ref Story _Story )
	{
		const string STORY_KEY = "Story" ;
		const string STORY_UID_KEY = "StoryUID" ;
		const string START_TAKE_UID_KEY = "StartTakeUID" ;
		const string END_TAKE_UID_KEY = "EndTakeUID" ;

		if( STORY_KEY != _node.Name )
		{
			Debug.LogError("STORY_KEY != _node.Name");
			return false;
		}


		if( null != _node.Attributes[ STORY_UID_KEY ] )
		{
			int storyUID = 0 ;
			int.TryParse( _node.Attributes[ STORY_UID_KEY ].Value , out storyUID ) ;
			_Story.StoryUID = storyUID ;
		}
		
		if( null != _node.Attributes[ START_TAKE_UID_KEY ] )
		{
			int StartTakeUID = 0 ;
			int.TryParse( _node.Attributes[ START_TAKE_UID_KEY ].Value , out StartTakeUID ) ;
			_Story.StartTakeUID = StartTakeUID ;
		}
		
		if( null != _node.Attributes[ END_TAKE_UID_KEY ] )
		{
			int EndTakeUID = 0 ;
			int.TryParse( _node.Attributes[ END_TAKE_UID_KEY ].Value , out EndTakeUID ) ;			
			_Story.EndTakeUID = EndTakeUID ;
		}
		
		return true ;

	}
}
