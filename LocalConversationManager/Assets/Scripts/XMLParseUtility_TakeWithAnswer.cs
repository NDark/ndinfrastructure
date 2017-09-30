using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;


public static partial class XMLParseUtility 
{
	/*
	<Take TakeUID="2" PotraitLeft="Orc" PotraitRight="" ContentString="Cowbay" />
	*/
	public static bool ParseTakeWithAnswer( XmlNode _node ,
		ref TakeWithAnswer _Take )
	{
		Take t = _Take as Take ;
		if( false == XMLParseUtility.ParseTake( _node , ref t ) )
		{
			return false ;

		}
		const string ANSWER0_KEY = "Answer0" ;
		const string ANSWER1_KEY = "Answer1" ;
		const string DIRECTION0_KEY = "Direction0" ;
		const string DIRECTION1_KEY = "Direction1" ;
		const string BACKGROUND_KEY = "Background" ;


		if( null != _node.Attributes[ ANSWER0_KEY ] )
		{
			_Take.Answer0 = _node.Attributes[ ANSWER0_KEY ].Value ;
		}
		if( null != _node.Attributes[ ANSWER1_KEY ] )
		{
			_Take.Answer1 = _node.Attributes[ ANSWER1_KEY ].Value ;
		}

		if( null != _node.Attributes[ DIRECTION0_KEY ] )
		{
			int direcitonID = 0 ;
			int.TryParse( _node.Attributes[ DIRECTION0_KEY ].Value , out direcitonID ) ;
			_Take.Direction0 = direcitonID ;
		}
		if( null != _node.Attributes[ DIRECTION1_KEY ] )
		{
			int direcitonID = 0 ;
			int.TryParse( _node.Attributes[ DIRECTION1_KEY ].Value , out direcitonID ) ;
			_Take.Direction1 = direcitonID ;
		}
		if( null != _node.Attributes[ BACKGROUND_KEY ] )
		{
			_Take.Background = _node.Attributes[ BACKGROUND_KEY ].Value ;
		}


		return true ;

	}


}
