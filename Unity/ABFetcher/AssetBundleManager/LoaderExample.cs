/**
@file LoaderExample.cs
@author NDark
@date 20171225 . file started.
*/

// #define ENABLE_NDINFRA_ONE_BUNDLE 

// #define ENABLE_NDINFRA_EXAMPLE_LOG

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace AssetBundles
{

public class LoaderExample : MonoBehaviour 
{
	public System.Action<string /*key*/ ,LoadedAssetBundle> bundleLoadHandler = new System.Action<string,LoadedAssetBundle>( (s0,b1) => {} ) ;
	public System.Action<UnityEngine.Object> assetLoadHandler = new System.Action<UnityEngine.Object>( (o1) => {} ) ;
	public System.Action levelLoadHandler = new System.Action( () => {} ) ;

	public System.Action<string /*message*/,string /*param*/> onError = new System.Action<string,string>( (m1,p2) => 
		{
			Debug.LogError("onError message=" + m1 + " param=" + p2 );
		} ) ;
	
	// Use this for initialization.
	IEnumerator Start ()
	{
		yield return StartCoroutine(Initialize() );
	}
	
	// Initialize the downloading url and AssetBundleManifest object.
	protected virtual IEnumerator Initialize()
	{
		// override this method for customizing your purpose.
		
		// Step 1. 
		// If this test item intented to load a scene,
		// You may not want this game object (loader) to be destroyed.
		
		// Don't destroy this gameObject as we depend on it to run the loading script.
		DontDestroyOnLoad(gameObject);
		
		// Step 2. 
		// Set the url before you initialize AssetBundleManager
		
		// With this code, when in-editor or using a development builds: Always use the AssetBundle Server
		// (This is very dependent on the production workflow of the project. 
		// 	Another approach would be to make this configurable in the standalone player.)
		#if DEVELOPMENT_BUILD || UNITY_EDITOR
		AssetBundleManager.SetDevelopmentAssetBundleServer ();
		#else
		// Use the following code if AssetBundles are embedded in the project for example via StreamingAssets folder etc:
		AssetBundleManager.SetSourceAssetBundleURL(Application.dataPath + "/");
		// Or customize the URL based on your deployment or configuration
		//AssetBundleManager.SetSourceAssetBundleURL("http://www.MyWebsite/MyAssetBundles");
		#endif
		
		// Step 3.
		// Load the first manifest at Initialize().
		// And defaultly AssetBundleManager will be generated as another game object
		// , and will not be destroyed.
		
		// Initialize AssetBundleManifest which loads the AssetBundleManifest object.
		var request = AssetBundleManager.Initialize();
		if (request != null)
			yield return StartCoroutine(request);
	}
	
	
	protected virtual IEnumerator LoadAssetAsync_Callback (string assetBundleName
		, string assetName 
	                                              , System.Action<UnityEngine.Object> _CallbackFunc)
	{
#if ENABLE_NDINFRA_EXAMPLE_LOG
		// This is simply to get the elapsed time for this phase of AssetLoading.
		float start = Time.realtimeSinceStartup;
#endif

		// Load asset from assetBundle.
		AssetBundleLoadAssetOperation request = 
			AssetBundleManager.LoadAssetAsync(assetBundleName, assetName, typeof(UnityEngine.Object) );
		if (request == null)
		{
			onError("assetBundleName is missing." , assetBundleName ) ;
			yield break;
		}
		
		yield return StartCoroutine(request);
		
		// Get the asset.
		var assetObject = request.GetAsset<UnityEngine.Object> ();
		
		_CallbackFunc( assetObject ) ;

#if ENABLE_NDINFRA_EXAMPLE_LOG
		// Calculate and display the elapsed time.
		float elapsed = Time.realtimeSinceStartup - start;

		Debug.Log(assetName + (null == assetObject ? " was not" : " was")+ " loaded successfully in " + elapsed + " seconds" ) ;
#endif	
		
	}
	
	protected virtual IEnumerator LoadAssetAsync_Delegate (string assetBundleName, string assetName)
	{
#if ENABLE_NDINFRA_EXAMPLE_LOG		
		// This is simply to get the elapsed time for this phase of AssetLoading.
		float start = Time.realtimeSinceStartup;
#endif

		// Load asset from assetBundle.
		AssetBundleLoadAssetOperation request = 
			AssetBundleManager.LoadAssetAsync(assetBundleName, assetName, typeof(UnityEngine.Object) );
		if (request == null)
		{
			onError("assetBundleName is missing." , assetBundleName ) ;
			yield break;
		}
		
		yield return StartCoroutine(request);
		
		// Get the asset.
		var assetObject = request.GetAsset<UnityEngine.Object> ();
		
		assetLoadHandler( assetObject ) ;
		


#if ENABLE_NDINFRA_EXAMPLE_LOG
		// Calculate and display the elapsed time.
		float elapsed = Time.realtimeSinceStartup - start;
		Debug.Log(assetName + (null == assetObject ? " was not" : " was")+ " loaded successfully in " + elapsed + " seconds" ) ;
#endif	
	}
	
#if ENABLE_NDINFRA_ONE_BUNDLE
	protected virtual IEnumerator LoadOneBundle_Delegate (string assetBundleName )
	{
#if ENABLE_NDINFRA_EXAMPLE_LOG		
		// This is simply to get the elapsed time for this phase of AssetLoading.
		float start = Time.realtimeSinceStartup;
#endif
		// Load asset from assetBundle.
		AssetBundleLoadAssetOperation request = AssetBundleManager.LoadBundleAsync(assetBundleName );
		if (request == null)
		{
			onError("assetBundleName is missing." , assetBundleName ) ;
			yield break;
		}
		
		yield return StartCoroutine(request);
		
		// Get the asset.
		var requestBundle = request as OneBundleLoadOperation ;
		var bundleObject = requestBundle.GetBundle() ;

		bundleLoadHandler( assetBundleName , bundleObject ) ;

#if ENABLE_NDINFRA_EXAMPLE_LOG
		// Calculate and display the elapsed time.
		float elapsed = Time.realtimeSinceStartup - start;

		Debug.Log( assetBundleName + " was completed in loading in " + elapsed + " seconds" ) ;
#endif		
	}
#endif 
// ENABLE_NDINFRA_ONE_BUNDLE

	protected virtual IEnumerator LoadLevelAsync_Callback (string sceneAssetBundleName 
	                                                       , string levelName
	                                                       , bool isAdditive
	                                                       , System.Action _CallbackFunc )
	{
#if ENABLE_NDINFRA_EXAMPLE_LOG		
		// This is simply to get the elapsed time for this phase of AssetLoading.
		float start = Time.realtimeSinceStartup;
#endif 
// ENABLE_NDINFRA_EXAMPLE_LOG	

		// Load level from assetBundle.
		AssetBundleLoadOperation request = AssetBundleManager.LoadLevelAsync( sceneAssetBundleName , levelName, isAdditive);
		if (request == null)
		{
			onError("sceneAssetBundleName is missing." , sceneAssetBundleName ) ;
			yield break;
		}

		yield return StartCoroutine(request);
		
		_CallbackFunc() ;

#if ENABLE_NDINFRA_EXAMPLE_LOG
		// Calculate and display the elapsed time.
		float elapsed = Time.realtimeSinceStartup - start;

		Debug.Log("Finished loading scene " + levelName + " in " + elapsed + " seconds" );
#endif 
// ENABLE_NDINFRA_EXAMPLE_LOG		
	}
	
	protected virtual IEnumerator LoadLevelAsync_Delegate (string sceneAssetBundleName 
		, string levelName, bool isAdditive)
	{
#if ENABLE_NDINFRA_EXAMPLE_LOG		
		// This is simply to get the elapsed time for this phase of AssetLoading.
		float start = Time.realtimeSinceStartup;
#endif 
// ENABLE_NDINFRA_EXAMPLE_LOG				

		// Load level from assetBundle.
		AssetBundleLoadOperation request = AssetBundleManager.LoadLevelAsync( sceneAssetBundleName , levelName, isAdditive);
		if (request == null)
		{
			onError("sceneAssetBundleName is missing." , sceneAssetBundleName ) ;
			yield break;
		}
		yield return StartCoroutine(request);
		
		levelLoadHandler() ;

#if ENABLE_NDINFRA_EXAMPLE_LOG
		// Calculate and display the elapsed time.
		float elapsed = Time.realtimeSinceStartup - start;

		Debug.Log("Finished loading scene " + levelName + " in " + elapsed + " seconds" );
#endif 
// ENABLE_NDINFRA_EXAMPLE_LOG				
		
	}

}

}// namespace AssetBundles