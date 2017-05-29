/**
@file AutoTest_SystemDateTime.cs
@author NDark

@date 20170529 file started.

*/
using System;
using UnityEngine;

public class AutoTest_SystemDateTime : MonoBehaviour 
{

	public string m_LocalZoneStandardName = string.Empty ;
	public string m_LocalZoneDaylightName = string.Empty ;
	public string m_DateTimeNow = string.Empty ;
	public bool m_IsDateTimeNowDaylightSavingTime = false ;
	public string m_DateTimeNowUniversalTime = string.Empty ;
	
	public string m_CurrentTimeZoneUniversalTime = string.Empty ;
	public bool m_IsUTCLightSavingTime = false ;
	public string m_CurrentOffset = string.Empty ;
	
	// 1470991811000 => 8/12/2016 4:50:11 PM
	public string m_TimeStamp1 = string.Empty ;
	public double m_TimeStamp1Sec = 0.0 ;
	
	// 1474966691000 => 9/27/2016 4:58:11 PM
	public string m_TimeStampPlus8H = string.Empty ;
	public double m_TimeStampPlus8HSec = 0.0 ;
	
	void Awake()
	{
		TimeZone localZone = TimeZone.CurrentTimeZone ; 
		
		m_LocalZoneStandardName = localZone.StandardName ;
		m_LocalZoneDaylightName = localZone.DaylightName ;
		
		DateTime currentDate = DateTime.Now;
		m_DateTimeNow = currentDate.ToString() ;
		DateTime universalTime = currentDate.ToUniversalTime() ;
		m_DateTimeNowUniversalTime = universalTime.ToString() ;
		
		m_IsDateTimeNowDaylightSavingTime = currentDate.IsDaylightSavingTime() ;
		
		DateTime currentUTC = localZone.ToUniversalTime( currentDate );
			
		
		m_CurrentTimeZoneUniversalTime = currentUTC.ToString() ;
		
		m_IsUTCLightSavingTime = currentUTC.IsDaylightSavingTime() ;
		
		TimeSpan currentOffset = 
			localZone.GetUtcOffset( currentDate );
		m_CurrentOffset = currentOffset.ToString() ;
		
		
		
		
		// 1496028203 sec
		// 5/29/2017 11:23:23 AM
		System.DateTime identityDateTime = new DateTime(1970,1,1,0,0,0,0,System.DateTimeKind.Utc);
		
		// TimeSpan currentUTCSpan = (currentUTC - identityDateTime);
		// Debug.Log ( currentUTCSpan.TotalSeconds ) ;
		
		System.DateTime timeStamp1 = identityDateTime.AddSeconds( 1496028203 ).ToLocalTime();
		m_TimeStamp1 = timeStamp1.ToString() ;
		
		DateTime timeStamp1UTC = localZone.ToUniversalTime( timeStamp1 );
		TimeSpan timeSpan1 = (timeStamp1UTC - identityDateTime);
		m_TimeStamp1Sec = timeSpan1.TotalSeconds ;
		
		// 1496028203 + 28800(+8Hours) = 1496057003 sec
		// 5/29/2017 7:23:23 PM
		System.DateTime timeStampPlus8H = identityDateTime.AddSeconds( 1496057003 ).ToLocalTime();
		m_TimeStampPlus8H = timeStampPlus8H.ToString() ;
		
		DateTime timeStampPlus8HUTC = localZone.ToUniversalTime( timeStampPlus8H );
		TimeSpan timeSpanPlus8 = (timeStampPlus8HUTC - identityDateTime) ;
		m_TimeStampPlus8HSec = timeSpanPlus8.TotalSeconds ;
		
	}	
}
