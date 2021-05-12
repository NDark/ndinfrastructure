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
@file ABChangeSceneReleaser.cs
@author NDark
@date 20171225 . file started.
*/

using UnityEngine;
using System.Collections.Generic;

public class ABChangeSceneReleaser : ABDownloader
{
	
	public void SetupOperators( List<ABReleaseAction> _Operators )
	{
		m_AssignedAction = _Operators ;
	}

	public void TryStart()
	{
		if( this.State == ProgressState.Invalid )
		{
			this.State = ProgressState.Initializing ;
		}
	}
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	void OnDestroy()
	{
		this.bundleLoadHandler -= DoBundleLoadHandler ;
	}

	// Update is called once per frame
	void Update () 
	{
		switch( this.State )
		{
		// case ProgressState.Invalid : break ; // stay unactive
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

	// create m_Checks
	protected override bool Flow_Initialize_CheckList()
	{
		var markers = m_AssignedAction ;
		
		var iEnum = markers.GetEnumerator() ;
		while( iEnum.MoveNext() )
		{
			if( iEnum.Current.Command == ABReleaseCommand.Load )
			{
				Debug.Log( "ABChangeSceneReleaser::Flow_Initialize_CheckList() A load command is marked:" + iEnum.Current.Key );
				m_LoadKeys.Add( iEnum.Current.Key ) ;
			}
			else if( iEnum.Current.Command == ABReleaseCommand.Unload )
			{
				Debug.Log( "ABChangeSceneReleaser::Flow_Initialize_CheckList() A unload command is marked:" + iEnum.Current.Key );
				m_UnloadKeys.Add( iEnum.Current.Key ) ;
			}
		}
		
		// clear conflict from m_LoadKeys and m_UnloadKeys.
		for( int i = 0 ; i < m_UnloadKeys.Count ; ++i )
		{
			if( string.Empty != m_UnloadKeys[ i ] 
			   && m_LoadKeys.Contains( m_UnloadKeys[ i ] ) )
			{
				Debug.Log( "ABChangeSceneReleaser::Flow_Initialize_CheckList() A unload command is skipped by conflict:" + iEnum.Current.Key ) ;
				m_UnloadKeys[ i ] = string.Empty ;
			}
		}
		
		// check setting
		var setting = m_BundleInfos ;
		var jEnum = setting.GetEnumerator() ;
		while( jEnum.MoveNext() )
		{
			string errorStr = string.Empty ;
			
			if( null != AssetBundles.AssetBundleManager.GetLoadedAssetBundle( jEnum.Current.Key 
				, out errorStr ) 
			   && 
				( jEnum.Current.Value.ReleaseTiming  == ABReleaseTiming.KeepUnload.ToString()
					|| jEnum.Current.Value.ReleaseTiming  == ABReleaseTiming.LoadByDemand.ToString() )
			    
				 )
			{
				if( m_LoadKeys.Contains( jEnum.Current.Key ) )
				{
					Debug.Log( "ABChangeSceneReleaser::Flow_Initialize_CheckList() A load command override KeepUnload:" + jEnum.Current.Key  ) ;
				}
				else if( false == m_UnloadKeys.Contains( jEnum.Current.Key ) )
				{
					Debug.Log( "ABChangeSceneReleaser::Flow_Initialize_CheckList() A un load command is added by KeepUnload:" + jEnum.Current.Key ) ;
					m_UnloadKeys.Add( jEnum.Current.Key ) ;
				}
			}
		}

		CheckItem addItem = null ;
		
		var kEnum = m_LoadKeys.GetEnumerator() ;
		while( kEnum.MoveNext() )
		{
			addItem = new CheckItem() ;
			addItem.m_BundleKey = kEnum.Current ;
			Debug.Log( "ABChangeSceneReleaser::Flow_Initialize_CheckList() final m_Checks.Add:" + kEnum.Current  ) ;
			m_Checks.Add( addItem.m_BundleKey, addItem ) ;
		}
		
		markers.Clear() ;
		
		return true ;	
	}
	
	
	protected override void Flow_Checking()
	{
		
		if( false == this.IsInitialized )
		{
			Debug.Log( "false == m_Loader.IsInitialized"  ) ;
			return ;
		}

		// unload first
		if( m_UnloadKeys.Count > 0 )
		{
			foreach( var key in m_UnloadKeys )
			{
				Debug.Log( "ABChangeSceneReleaser::Flow_Checking() UnloadAssetBundle:" + key  ) ;
				AssetBundles.AssetBundleManager.UnloadAssetBundle( key ) ;
			}
			m_UnloadKeys.Clear() ;
		}

		// load later
		var iEnum1 = m_Checks.GetEnumerator() ;
		
		int completeCount = 0 ;
		int requestingCount = 0 ;
		int inAciveCount = 0 ;
		
		while( iEnum1.MoveNext() )
		{
			if( iEnum1.Current.Value.m_CurrentState == CheckState.CheckComplete )
			{
				++completeCount ;
			}
			else if( iEnum1.Current.Value.m_CurrentState == CheckState.Requesting )
			{
				++requestingCount ;
			}
			else 
			{
				++inAciveCount ;
			}
		}
		
		if( completeCount >= m_Checks.Count )
		{
			this.State = ProgressState.ChangeScene ;
			return ;
		}
		else if( inAciveCount > 0 )
		{
			var iEnum2 = m_Checks.GetEnumerator() ;
			while( iEnum2.MoveNext() && requestingCount < m_RequestLimit )
			{
				if( iEnum2.Current.Value.m_CurrentState == CheckState.Invalid )
				{
					iEnum2.Current.Value.m_CurrentState = CheckState.Requesting ;
					Debug.Log( "Flow_Checking() TryStartLoadBundle=" + iEnum2.Current.Value.m_BundleKey );
					this.CheckAndLoadBundle_Delegate( iEnum2.Current.Value.m_BundleKey ) ;
					++requestingCount ;
				}
			}
		}
		
		this.State = ProgressState.Pending ;
	}
	
	
	protected override void Flow_Pending()
	{
		
	}
	
	protected override void Flow_ChangeScene()
	{
		Debug.Log( "ABChangeSceneReleaser::Flow_ChangeScene() ProgressState.End" ) ;
		this.State = ProgressState.End ;
	}
	
	protected override void DoBundleLoadHandler( string _BundleKey , AssetBundles.LoadedAssetBundle _Bundle , string [] pathArray )
	{
		Debug.Log( "DoBundleLoadHandler() " + _BundleKey  ) ;

		if( true == m_Checks.ContainsKey( _BundleKey ) )
		{
			m_Checks[ _BundleKey ].m_CurrentState =  CheckState.CheckComplete ;
		}
		
		this.State = ProgressState.Checking ;
	}
	
	
	protected List< string > m_LoadKeys = new List<string>() ;// will set to m_Checks
	protected List<string > m_UnloadKeys = new List<string>() ;

	protected List<ABReleaseAction> m_AssignedAction = new List<ABReleaseAction>() ;// action assigned from outside.

}

