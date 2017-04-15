using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON ;

public static partial class JSONParseUtility 
{

	/*

	{"Take":{"TakeUID":2,"PotraitLeft":"Orc","PotraitRight":"","ContentString":"Cowbay"} }
	*/
	public static bool ParseTake( JSONNode _node ,
	                              ref Take _Take )
	{
		const string TAKE_KEY = "Take" ;
		const string TAKE_UID_KEY = "TakeUID" ;
		const string POTRAIT_LEFT_KEY = "PotraitLeft" ;
		const string POTRAIT_RIGHT_KEY = "PotraitRight" ;
		const string CONTENT_STRING_KEY = "ContentString" ;

		if( false == _node.IsContains( TAKE_KEY ) )
		{
			return false;
		}

		JSONNode contentNode = _node[ TAKE_KEY ] ;
		if( true == contentNode.IsContains( TAKE_UID_KEY ) )
		{
			int takeUID = 0 ;
			int.TryParse( contentNode[ TAKE_UID_KEY ].Value , out takeUID ) ;
			_Take.TakeUID = takeUID ;
		}
		
		if( true == contentNode.IsContains( POTRAIT_LEFT_KEY ) )
		{
			_Take.PotraitLeft = contentNode[ POTRAIT_LEFT_KEY ].Value ;
		}
					
		if( true == contentNode.IsContains( POTRAIT_RIGHT_KEY ) )
		{
			_Take.PotraitRight = contentNode[ POTRAIT_RIGHT_KEY ].Value ;
		}
		
		if( true == contentNode.IsContains( CONTENT_STRING_KEY ) )
		{
			_Take.ContentString = contentNode[ CONTENT_STRING_KEY ].Value ;
		}

		return true ;

	}
	
	/**
	{"Story":{"StoryUID":1,"StartTakeUID":1,"EndTakeUID":5}}
	*/
	public static bool ParseStory( JSONNode _node ,
	                             ref Story _Story )
	{
		const string STORY_KEY = "Story" ;
		const string STORY_UID_KEY = "StoryUID" ;
		const string START_TAKE_UID_KEY = "StartTakeUID" ;
		const string END_TAKE_UID_KEY = "EndTakeUID" ;

		if( false == _node.IsContains( STORY_KEY ) )
		{
			return false;
		}

		JSONNode contentNode = _node[ STORY_KEY ] ;

		if( true == contentNode.IsContains( STORY_UID_KEY ) )
		{
			int storyUID = 0 ;
			int.TryParse( contentNode[ STORY_UID_KEY ].Value , out storyUID ) ;
			_Story.StoryUID = storyUID ;
		}
		
		if( true == contentNode.IsContains( START_TAKE_UID_KEY )  )
		{
			int StartTakeUID = 0 ;
			int.TryParse( contentNode[ START_TAKE_UID_KEY ].Value , out StartTakeUID ) ;
			_Story.StartTakeUID = StartTakeUID ;
		}
		
		if( true == contentNode.IsContains( END_TAKE_UID_KEY ) )
		{
			int EndTakeUID = 0 ;
			int.TryParse( contentNode[ END_TAKE_UID_KEY ].Value , out EndTakeUID ) ;			
			_Story.EndTakeUID = EndTakeUID ;
		}
		
		return true ;

	}
}
