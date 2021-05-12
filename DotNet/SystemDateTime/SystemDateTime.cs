/**

MIT License

Copyright (c) 2017 - 2021 NDark

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

*/
/**
@file SystemDateTime.cs
@author NDark
@date 201705118 file started.

*/

using UnityEngine;

public static class SystemDateTime 
{

	// \/Date(-62135596800000)\/
	// \/Date(1494837421000)\/
	// \/Date(1494815636900)\/
	// \/Date(1453789341467)\/
	public static System.DateTime ConvertFromJSONDate( string _Str )
	{
		
		const string KEY_Date = "Date" ;
		const string KEY_LeftBrace = "(" ;
		const string KEY_RightBrace = ")" ;

		if( -1 == _Str.IndexOf( KEY_Date ) )
		{
			return m_Identity ;
		}

		int index1 = _Str.IndexOf( KEY_LeftBrace ) ;
		int index2 = _Str.IndexOf( KEY_RightBrace ) ;

		string milliSecStr = _Str.Substring( index1 + 1 , index2 - index1 - 1) ;
		string secStr = milliSecStr.Substring( 0 , milliSecStr.Length - 3 ) ;


		double sec = 0 ;
		if( false == double.TryParse( secStr , out sec ) )
		{
			return m_Identity ;
		}

		System.DateTime ret = ConvertFromSec( (double) sec ) ;
		return ret ;
	}

	/**
	Int32.MaxValue = 2,147,483,647
	one year has 31536000 sec
	40 years have 1,261,440,000
	*/
	private static System.DateTime m_Identity = new System.DateTime(1970,1,1,0,0,0,0,System.DateTimeKind.Utc);
	private static System.TimeZone m_LocalTimeZone = System.TimeZone.CurrentTimeZone ; 

	public static double GetSystemDateTimeSec_Local_ByNow( System.DateTime _LocalTime )
	{
		System.TimeSpan timeSpan = (_LocalTime - System.DateTime.Now);
		double ret = timeSpan.TotalSeconds ;
		return ret ;
	}

	public static double GetSystemDateTimeSec_ByNow( System.DateTime _SpecifiedTime )
	{
		System.DateTime timeStampUTC = m_LocalTimeZone.ToUniversalTime( _SpecifiedTime );
		System.TimeSpan timeSpan = (timeStampUTC - System.DateTime.Now);
		double ret = timeSpan.TotalSeconds ;
		return ret ;
	}


	public static double GetSystemDateTimeSec( System.DateTime _SpecifiedTime )
	{
		System.DateTime timeStampUTC = m_LocalTimeZone.ToUniversalTime( _SpecifiedTime );
		System.TimeSpan timeSpan = (timeStampUTC - m_Identity);
		double ret = timeSpan.TotalSeconds ;
		return ret ;
	}
	
	public static double GetSystemDateTimeSecNow()
	{
		return GetSystemDateTimeSec( System.DateTime.Now ) ;
	}
	
	public static System.DateTime ConvertFromSec( double _Sec )
	{
		System.DateTime ret = m_Identity.AddSeconds( _Sec ).ToLocalTime();
		return ret ;
	}
	
	public static System.DateTime ConvertFromSec_ByNow( double _Sec )
	{
		System.DateTime ret = System.DateTime.Now.AddSeconds( _Sec ).ToLocalTime();
		return ret ;
	}
	
}
