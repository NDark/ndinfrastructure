/**
@file ABDownloaderBase.cs
@author NDark
@date 20171225 . file started.
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ABDownloaderBase : ABFetcherLoaderBase 
{
	
	public enum ProgressState
	{
		Invalid = 0 
		, Initializing
		, Checking
		, Pending
		, ChangeScene
		, End
	}
	
	public enum CheckState
	{
		Invalid = 0 
		, Requesting 
		, CheckComplete
	}
	
	public class CheckItem
	{
		public string m_BundleKey = string.Empty ;
		public CheckState m_CurrentState = CheckState.Invalid ;
	}

	public ProgressState State
	{
		get { return m_PState ; }
		set { m_PState = value ; }
	}
	

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		switch( this.State )
		{
		case ProgressState.Invalid :
			this.State = ProgressState.Initializing ;
			break ;
		case ProgressState.Initializing :
			Flow_Initializing() ;
			break ;
		case ProgressState.Checking :
			Flow_Checking() ;
			break ;
		case ProgressState.Pending :
			Flow_Pending() ;
			break ;
		case ProgressState.ChangeScene :
			Flow_ChangeScene() ;
			break ;
		// case ProgressState.End : break ; // do nothing 
			
		}
	}
		
	
	protected virtual void Flow_Initializing()
	{
		this.State = ProgressState.Checking ;
		
	}
	

	protected virtual void Flow_Checking()
	{
		
	}
	
	protected virtual void Flow_Pending()
	{

	}
	
	protected virtual void UpdateProgressUI( float _Ratio , string _Message )
	{
	}
	
	protected virtual void Flow_ChangeScene()
	{
		// to do : change scene here
		
		this.State = ProgressState.End ;
	}
	
	protected virtual void DoBundleLoadHandler( string _BundleKey , AssetBundles.LoadedAssetBundle _Bundle )
	{
		// UnityEngine.Debug.Log("DoBundleLoadHandler() _BundleKey=" + _BundleKey ) ;

	}

	
	protected void GoException( string _LogStr )
	{
		UnityEngine.Debug.LogError( _LogStr );
		this.State = ProgressState.End ;
	}
	

	private ProgressState m_PState = ProgressState.Invalid ;	
	protected Dictionary<string, CheckItem > m_Checks = new Dictionary<string, CheckItem>() ;

}

