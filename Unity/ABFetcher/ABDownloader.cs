/**
@file ABDownloader.cs
@author NDark
@date 20171225 . file started.
*/
// #define ENABLE_NDINFRA_SIMULATE_PROGRESS

// #define ENABLE_NDINFRA_NOT_CHANGE_SCENE

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ABDownloader : ABDownloaderBase
{
	public string m_InteractiveABKey = string.Empty ;
	public string m_InteractiveSceneName = string.Empty ;

	public void SetupBundleSetups( Dictionary<string,ABSetupInfo> _Table )
	{
		m_BundleInfos = _Table ;
	}
	public void SetupBundlesDirectoryURL( string _BundlesDirectoryURL )
	{
		m_ABDirURL = _BundlesDirectoryURL ;
	}

	// create a list m_Checks
	protected virtual bool Flow_Initialize_CheckList()
	{
		Dictionary<string,ABSetupInfo> table = m_BundleInfos ;

		if( 0 == table.Count )
		{
			Debug.Log("0 == table.Count"  );

#if !ENABLE_NDINFRA_NOT_CHANGE_SCENE
			this.State = ProgressState.ChangeScene ;
			return false ;
#endif 
// !ENABLE_NDINFRA_NOT_CHANGE_SCENE

		}
		
		CheckItem addItem = null ;
		var iEnum = table.GetEnumerator() ;
		while( iEnum.MoveNext() )
		{
			string bundleKey = iEnum.Current.Value.Key ;
#if ENABLE_NDINFRA_CUSTOM
			AssetBundles.AssetBundleManager.m_VersionTable.Add( bundleKey , iEnum.Current.Value.Version ) ;
#endif 			
			string url = AssetBundles.AssetBundleManager.BaseDownloadingURL + bundleKey ;

			if( iEnum.Current.Value.ReleaseTiming != ABReleaseTiming.Expired.ToString()
			   && false == Caching.IsVersionCached( url , iEnum.Current.Value.Version )
			)
			{
				addItem = new CheckItem() ;
				addItem.m_BundleKey = iEnum.Current.Value.Key ;
				m_Checks.Add( addItem.m_BundleKey, addItem ) ;
			}
		}
		
		m_TotalRequestedSize = m_Checks.Count ;
		if( 0 == m_TotalRequestedSize )
		{
			Debug.Log("Flow_Initialize_CheckList() 0 == m_TotalRequestedSize" );
		}

		return true ;	
		
	}
	
	protected virtual bool Flow_Initialize_AssetBundleFetcher()
	{
		string bundlesDirectoryURL = m_ABDirURL ;
		
		// bundlesDirectoryURL = "file:///D:/.../" ;
		if( null == bundlesDirectoryURL
		   || string.Empty == bundlesDirectoryURL  )
		{
			GoException("string.Empty == bundlesDirectoryURL") ;
			return false ;
		}
		
		this.AssetbundleFolderURL = bundlesDirectoryURL ;
		this.StartInitialize() ;
		this.onError += DoErrorInLoading ;
		this.bundleLoadHandler += DoBundleLoadHandler ;
		return true ;
	}

	void OnDestroy()
	{
		this.bundleLoadHandler -= DoBundleLoadHandler ;
		this.onError -= DoErrorInLoading ;
	}
	
	protected override void Flow_Initializing()
	{

#if ENABLE_NDINFRA_SIMULATE_PROGRESS
		StartCoroutine( WaitForSec( DEBUG_ProgressTickSec ) ) ;
#else
        // Debug.LogWarning("Flow_Initializing");

		// initailize request table
		if( false  == Flow_Initialize_CheckList() )
		{
			return ;
		}
		
		// initialize loader
		if( false  == Flow_Initialize_AssetBundleFetcher() )
		{
			return ;
		}

#endif 
// ENABLE_NDINFRA_SIMULATE_PROGRESS

		this.State = ProgressState.Checking ;
		
	}
	

	protected override void Flow_Checking()
	{
		
#if ENABLE_NDINFRA_SIMULATE_PROGRESS
		UpdateProgressUI( (float)DEBUG_ProgressIndex/ (float) DEBUG_ProgressSize 
		                 , string.Format("[DEBUG] Loading {0}/{1}" 
		                , DEBUG_ProgressIndex 
		                , DEBUG_ProgressSize ) ) ;
		                
		if( DEBUG_ProgressIndex >= DEBUG_ProgressSize )
		{
			this.State = ProgressState.ChangeScene ;
		}
#else
// ENABLE_NDINFRA_SIMULATE_PROGRESS

		if( false == this.IsInitialized )
		{
			// this.LogDownloadSystem( "false == this.IsInitialized" , LogType.Warning );
			return ;
		}

		if( false == m_IsSendInteractiveRequest )
		{
			CheckAndLoadInteractiveScene() ;
			m_IsSendInteractiveRequest = true ;
		}
		
		var iEnum1 = m_Checks.GetEnumerator() ;
		
		m_CompleteCount = 0 ;
		m_RequestingCount = 0 ;
		m_WaitingCount = 0 ;
		
		while( iEnum1.MoveNext() )
		{
			if( iEnum1.Current.Value.m_CurrentState == CheckState.CheckComplete )
			{
				++m_CompleteCount ;
			}
			else if( iEnum1.Current.Value.m_CurrentState == CheckState.Requesting )
			{
				++m_RequestingCount ;
			}
			else 
			{
				++m_WaitingCount ;
			}
		}

		this.State = ProgressState.Pending ;

		// Debug.Log("completeCount=" + m_CompleteCount );
		// Debug.Log("requestingCount=" + m_RequestingCount );
		// Debug.Log("m_Checks.Count=" + m_Checks.Count );
		if( m_CompleteCount >= m_Checks.Count )
		{
			UpdateProgressUI() ;
			Debug.Log( "Flow_Checking() download complete m_Checks.Count=" + m_Checks.Count  );
			this.State = ProgressState.ChangeScene ;
			return ;
		}
		else if( m_WaitingCount > 0 )
		{
			var iEnum2 = m_Checks.GetEnumerator() ;
			while( iEnum2.MoveNext() && m_RequestingCount < m_RequestLimit )
			{
				if( iEnum2.Current.Value.m_CurrentState == CheckState.Invalid )
				{
					iEnum2.Current.Value.m_CurrentState = CheckState.Requesting ;
					Debug.Log( "Flow_Checking() TryStartLoadBundle=" + iEnum2.Current.Value.m_BundleKey  );
					this.CheckAndLoadBundle_Delegate( iEnum2.Current.Value.m_BundleKey ) ;
					++m_RequestingCount ;
				}
			}
		}
		

#endif 
// ENABLE_NDINFRA_SIMULATE_PROGRESS

		
		
	}
	
	protected override void Flow_Pending()
	{
		
#if ENABLE_NDINFRA_SIMULATE_PROGRESS	
		UpdateProgressUI( (float)DEBUG_ProgressIndex/ (float) DEBUG_ProgressSize 
		                 , string.Format("[DEBUG] Loading {0}/{1}" 
		                 	, DEBUG_ProgressIndex 
		                 	, DEBUG_ProgressSize ) ) ;
#else
// ENABLE_NDINFRA_SIMULATE_PROGRESS
		UpdateProgressUI() ;
		
#endif 
// ENABLE_NDINFRA_SIMULATE_PROGRESS

	}

	protected virtual void UpdateProgressUI()
	{
		if( 0 != m_TotalRequestedSize )
		{
			UpdateProgressUI( (float)m_CompleteCount/ (float) m_TotalRequestedSize 
			                 , string.Format("Loading {0}/{1}" 
			                , m_CompleteCount 
			                , m_TotalRequestedSize ) ) ;
		}
		
	}
	
	protected override void Flow_ChangeScene()
	{
		if( 0 != m_TotalRequestedSize )
		{
			UpdateProgressUI( (float)m_CompleteCount/ (float) m_TotalRequestedSize 
			                 , string.Format("Loading Complete" ) ) ;
		}
		
		this.State = ProgressState.End ;
	}
	
	protected override void DoBundleLoadHandler( string _BundleKey , AssetBundles.LoadedAssetBundle _Bundle )
	{
		if( null == _Bundle )
		{
			#if UNITY_EDITOR
			if (!AssetBundles.AssetBundleManager.SimulateAssetBundleInEditor)
			{
				Debug.LogError("DoBundleLoadHandler() Fatal Error, Bundle missed" );
			}
			#else
			Debug.LogError("DoBundleLoadHandler() Fatal Error, Bundle missed" );
			#endif
		}

		Debug.Log( "DoBundleLoadHandler=" + _BundleKey  );

		if( true == m_Checks.ContainsKey( _BundleKey ) )
		{
			m_Checks[ _BundleKey ].m_CurrentState = CheckState.CheckComplete ;
		}
		
		// check unload
		ABSetupInfo setupData = null ;
		m_BundleInfos.TryGetValue( _BundleKey , out setupData ) ;

		if( null == setupData )
		{
			Debug.Log( "DoBundleLoadHandler() null == setting _Bundle.m_BundleKey=" + _BundleKey );
		}
		else
		{
			if( setupData.ReleaseTiming == ABReleaseTiming.LoadByDemand.ToString()
				|| setupData.ReleaseTiming  == ABReleaseTiming.KeepUnload.ToString()
			)
			{
				Debug.Log( "DoBundleLoadHandler() UnloadAssetBundle=" + _BundleKey  );
				AssetBundles.AssetBundleManager.UnloadAssetBundle( _BundleKey ) ;
			}
		}

		this.State = ProgressState.Checking ;

	}
	

	protected void CheckAndLoadInteractiveScene()
	{
		if( string.Empty == m_InteractiveABKey 
		   || string.Empty == m_InteractiveSceneName )
		{
			Debug.Log( "string.Empty == m_InteractiveABKey" );
			return ;
		}
		
		this.levelLoadHandler += DoLevelLoadHandler ;
		this.CheckAndLoadLevel_Delegate( m_InteractiveABKey 
			, m_InteractiveSceneName 
			, true ) ;

	}
	
	protected void DoLevelLoadHandler()
	{
		// Debug.Log("DoLevelLoadHandler"  ) ;
		Debug.Log( "DoLevelLoadHandler" );
		this.levelLoadHandler -= DoLevelLoadHandler ;

	}

	protected virtual void DoErrorInLoading( string _ErrorMessage , string _Param )
	{
		Debug.LogError("DoErrorInLoading() _ErrorMessage=" + _ErrorMessage  + " _Param=" + _Param );

		// error but keep loading the others
		if( true == m_Checks.ContainsKey( _Param ) )
		{
			m_Checks[ _Param ].m_CurrentState = CheckState.CheckComplete ;
		}

		this.State = ProgressState.Checking ;
	}
	
#if ENABLE_NDINFRA_SIMULATE_PROGRESS	
	protected System.Collections.IEnumerator WaitForSec( float _Sec )
	{
		yield return new WaitForSeconds ( _Sec ) ;
		++DEBUG_ProgressIndex ;
		
		StartCoroutine( WaitForSec( DEBUG_ProgressTickSec ) ) ;
	}
#endif 
// ENABLE_NDINFRA_SIMULATE_PROGRESS

#if ENABLE_NDINFRA_SIMULATE_PROGRESS	
	private float DEBUG_ProgressTickSec = 0.05f ;
	private int DEBUG_ProgressIndex = 0 ;
	private int DEBUG_ProgressSize = 220 ;
#endif 
// ENABLE_NDINFRA_SIMULATE_PROGRESS

	protected int m_RequestLimit = 1 ;
	protected int m_CompleteCount = 0 ;
	protected int m_RequestingCount = 0 ;
	protected int m_WaitingCount = 0 ;
	protected int m_TotalRequestedSize = 0 ;

#if !ENABLE_NDINFRA_SIMULATE_PROGRESS
	private bool m_IsSendInteractiveRequest = false ;
#endif 
// ENABLE_NDINFRA_SIMULATE_PROGRESS	

	protected Dictionary<string,ABSetupInfo> m_BundleInfos = new Dictionary<string, ABSetupInfo>() ;
	protected string m_ABDirURL = string.Empty ;
}

