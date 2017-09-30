using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeWithAnswer : Take 
{

	public string Background
	{
		get { return m_Background ; }
		set { m_Background = value ; }
	}
	private string m_Background = string.Empty ;

	public string Answer0
	{
		get { return m_Answer0 ; }
		set { m_Answer0 = value ; }
	}
	private string m_Answer0 = string.Empty ;

	public string Answer1
	{
		get { return m_Answer1 ; }
		set { m_Answer1 = value ; }
	}
	private string m_Answer1 = string.Empty ;


	public int Direction0
	{
		get { return m_Direction0 ; }
		set { m_Direction0 = value ; }
	}
	private int m_Direction0 = 0 ;

	public int Direction1
	{
		get { return m_Direction1 ; }
		set { m_Direction1 = value ; }
	}
	private int m_Direction1 = 0 ;

}
