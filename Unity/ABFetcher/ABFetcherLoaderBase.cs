/**

MIT License

Copyright (c) 2017 NDark

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
@file ABFetcherLoaderBase.cs
@author NDark
@date 20171225 . file started.
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ABFetcherLoaderBase : AssetBundles.LoaderExample 
{
	// this will be set into AssetBundles.AssetBundleManager.SetSourceAssetBundleURL()
	// be sure to set this before initialize or load any bundle.
	public string AssetbundleFolderURL
	{
		set { m_AssetbundleFolderURL = value ;}
		get 
		{ 
			return (s_IsActiveOverrideBundleFolder) 
					? s_OverrideBundleFolderURL : m_AssetbundleFolderURL ; 
		}
	}

	// force to override bundle folder at any cause.
	public static void ActiveOverrideBundleFolderURL( bool _Active , string _URL )
	{
		Debug.LogWarning("ActiveOverrideBundleFolderURL() _URL" + _URL);
		s_IsActiveOverrideBundleFolder = _Active ;
		s_OverrideBundleFolderURL = _URL ;
	}

	// check m_InitRequest
	public bool HasInitRequest()
	{
		return (null != m_InitRequest );
	}

	public bool IsInitialized 
	{
		get 
		{ 
			return 
			(
#if UNITY_EDITOR	
				AssetBundles.AssetBundleManager.SimulateAssetBundleInEditor ||
#endif // UNITY_EDITOR

#if ENABLE_NDINFRA_CUSTOM
				true == IsAssetBundleManifestObjectNotNull() ||
#endif 
				( ( null == m_InitRequest && s_OnceRequestReceived ) 
				|| ( null != m_InitRequest && m_InitRequest.IsDone() ) )
			) ;
		}
	}


#if ENABLE_NDINFRA_CUSTOM
	public bool IsAssetBundleManifestObjectNotNull()
	{
		return AssetBundles.AssetBundleManager.IsAssetBundleManifestNotNull() ;
	}
#endif //
	
	IEnumerator Start ()
	{
		// don't start automatically, must call StartInitialize() to start initialized
		yield return null ;
	}

	public void StartInitialize()
	{
		StartCoroutine( Initialize() ) ;
	}


	public virtual void CheckAndLoadBundle_Delegate( string _Key )
	{
		string error = string.Empty ;
		var loadedBundle = AssetBundles.AssetBundleManager.GetLoadedAssetBundle( _Key , out error ) ;
		if( null != loadedBundle )
		{
			bundleLoadHandler( _Key , loadedBundle ) ;
		}
		else
		{
#if ENABLE_NDINFRA_ONE_BUNDLE
			StartCoroutine( LoadOneBundle_Delegate( _Key ) ) ;
#else 
			Debug.LogError("Not suppurt this method.");
#endif
		}
	}
	
	public virtual void CheckAndLoadAsset_Callback(string _BundleName
		, string _AssetName
		, System.Action<UnityEngine.Object> _CallbackFunc )
	{
		string error = string.Empty ;
		var loadedBundle = AssetBundles.AssetBundleManager.GetLoadedAssetBundle( _BundleName , out error ) ;
		if( null != loadedBundle )
		{
			StartCoroutine( LoadAssetFromExistBundle_Callback( loadedBundle 
				, _AssetName 
				, _CallbackFunc ) ) ;
		}
		else
		{
			StartCoroutine( LoadAssetAsync_Callback( _BundleName , _AssetName , _CallbackFunc ) ) ;
		}
	}

	protected virtual IEnumerator LoadAssetFromExistBundle_Callback ( AssetBundles.LoadedAssetBundle _LoadedBundle
		, string assetName 
		, System.Action<UnityEngine.Object> _CallbackFunc )
	{
		// Load asset from assetBundle.
		var request = _LoadedBundle.m_AssetBundle.LoadAssetAsync<UnityEngine.Object>( assetName ) ;
		
		yield return request;
		
		// Get the asset.
		var assetObject = request.asset ;
		
		_CallbackFunc( assetObject ) ;
	}
	
	public virtual void CheckAndLoadAsset_Delegate (string _BundleName, string _AssetName)
	{
		string error = string.Empty ;
		var loadedBundle = AssetBundles.AssetBundleManager.GetLoadedAssetBundle( _BundleName , out error ) ;
		if( null != loadedBundle )
		{
			StartCoroutine( LoadAssetFromExistBundle_Delegate( loadedBundle , _AssetName  ) ) ;
		}
		else
		{
			StartCoroutine( LoadAssetAsync_Delegate( _BundleName , _AssetName ) ) ;
		}
		
	}
	
	protected virtual IEnumerator LoadAssetFromExistBundle_Delegate ( AssetBundles.LoadedAssetBundle _LoadedBundle
		, string _AssetName )
	{
		var request = _LoadedBundle.m_AssetBundle.LoadAssetAsync<UnityEngine.Object>( _AssetName ) ;
		
		yield return request;
		
		// Get the asset.
		var assetObject = request.asset ;
		
		assetLoadHandler( assetObject ) ;
	}
	
	protected virtual IEnumerator LoadLevelFromExistBundle_Callback ( string _LevelName
	                                                       , bool _IsAdditive
	                                                       , System.Action _CallbackFunc )
	{
		
		AsyncOperation request = null ;
		if (_IsAdditive)
			request = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync (_LevelName , UnityEngine.SceneManagement.LoadSceneMode.Additive );
		else
			request = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync (_LevelName);
			
		yield return request ;
		
		_CallbackFunc() ;
		
	}
	
	protected virtual IEnumerator LoadLevelFromExistBundle_Delegate ( string _LevelName
		, bool _IsAdditive )
	{
		
		AsyncOperation request = null ;
		if (_IsAdditive)
			request = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync (_LevelName , UnityEngine.SceneManagement.LoadSceneMode.Additive );
		else
			request = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync (_LevelName);
		
		yield return request ;
		
		levelLoadHandler() ;
		
	}
	
	public virtual void CheckAndLoadLevel_Callback (string sceneAssetBundleName 
	                                        , string levelName
	                                        , bool isAdditive
		, System.Action _CallbackFunc)
	{
		string error = string.Empty ;
		var loadedBundle = AssetBundles.AssetBundleManager.GetLoadedAssetBundle( sceneAssetBundleName 
			, out error ) ;
		if( null != loadedBundle )
		{
			StartCoroutine ( LoadLevelFromExistBundle_Callback( levelName
			                                       , isAdditive
				,  _CallbackFunc ) ) ;
		}
		else
		{
			
			StartCoroutine( LoadLevelAsync_Callback( sceneAssetBundleName 
			                                        , levelName 
			                                        , isAdditive 
				, _CallbackFunc ) ) ;
		}
	}
	
	public virtual void CheckAndLoadLevel_Delegate(string sceneAssetBundleName 
		, string levelName
		, bool isAdditive )
	{
		string error = string.Empty ;
		var loadedBundle = AssetBundles.AssetBundleManager.GetLoadedAssetBundle( sceneAssetBundleName 
		                                                                        , out error ) ;
		if( null != loadedBundle )
		{
			StartCoroutine ( LoadLevelFromExistBundle_Delegate( levelName , isAdditive ) ) ;
		}
		else
		{
			StartCoroutine( LoadLevelAsync_Delegate( sceneAssetBundleName , levelName , isAdditive ) ) ;
		}
	}
	

	// Initialize the downloading url and AssetBundleManifest object.
	protected override IEnumerator Initialize()
	{
		// override this method for customizing your purpose.
		
		// Step 2. 
		// Set the url before you initialize AssetBundleManager
		AssetBundles.AssetBundleManager.SetSourceAssetBundleURL( this.AssetbundleFolderURL );
		
		// Initialize AssetBundleManifest which loads the AssetBundleManifest object.
		
		if( false == this.IsInitialized )
		{
			m_InitRequest = AssetBundles.AssetBundleManager.Initialize();

			if (m_InitRequest != null)
			{
				yield return StartCoroutine(m_InitRequest);
				s_OnceRequestReceived = true ;
			}	

		}
		
	}
	
	protected string m_AssetbundleFolderURL = string.Empty ;
	protected AssetBundles.AssetBundleLoadManifestOperation m_InitRequest = null ;	

	protected static bool s_IsActiveOverrideBundleFolder = false ;
	protected static string s_OverrideBundleFolderURL = string.Empty ;
	static bool s_OnceRequestReceived = false ;
}
