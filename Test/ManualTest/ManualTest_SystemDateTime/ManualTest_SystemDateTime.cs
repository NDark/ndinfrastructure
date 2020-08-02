/**

MIT License

Copyright (c) 2017 - 2020 NDark

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
@file ManualTest_SystemDateTime.cs
@author NDark

@date 20170529 file started.

*/
using UnityEngine;
using UnityEngine.UI ;


public class ManualTest_SystemDateTime : MonoBehaviour 
{
	public AutoTest_SystemDateTime m_Data = null ;
	
	public Text m_LocalZoneStandardName = null ;
	public Text m_LocalZoneDaylightName = null ;
	public Text m_DateTimeNow = null ;
	public Text m_IsDateTimeNowDaylightSavingTime = null ;
	public Text m_DateTimeNowUniversalTime = null ;
	public Text m_CurrentTimeZoneUniversalTime = null ;
	public Text m_IsUTCLightSavingTime = null ;
	public Text m_CurrentOffset = null ;
	
	// 1470991811000 => 8/12/2016 4:50:11 PM
	public Text m_TimeStamp1 = null ;
	public Text m_TimeStamp1Sec = null ;
	
	// 1474966691000 => 9/27/2016 4:58:11 PM
	public Text m_TimeStampPlus8H = null ;
	public Text m_TimeStampPlus8HSec = null;

	// Use this for initialization
	void Start () 
	{
		if( null != m_Data )
		{
			
			m_LocalZoneStandardName.text = m_Data.m_LocalZoneStandardName ;
			
			m_LocalZoneDaylightName.text = m_Data.m_LocalZoneDaylightName ;
			m_DateTimeNow.text = m_Data.m_DateTimeNow ;
			m_IsDateTimeNowDaylightSavingTime.text = m_Data.m_IsDateTimeNowDaylightSavingTime.ToString() ;
			m_DateTimeNowUniversalTime.text = m_Data.m_DateTimeNowUniversalTime ;
			
			m_CurrentTimeZoneUniversalTime.text = m_Data.m_CurrentTimeZoneUniversalTime ;
			m_IsUTCLightSavingTime.text = m_Data.m_IsUTCLightSavingTime.ToString() ;
			m_CurrentOffset.text = m_Data.m_CurrentOffset ;
			
			m_TimeStamp1.text = m_Data.m_TimeStamp1 ;
			m_TimeStamp1Sec.text = m_Data.m_TimeStamp1Sec.ToString() ;
			m_TimeStampPlus8H.text = m_Data.m_TimeStampPlus8H ;
			m_TimeStampPlus8HSec.text = m_Data.m_TimeStampPlus8HSec.ToString() ;
			
			
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
