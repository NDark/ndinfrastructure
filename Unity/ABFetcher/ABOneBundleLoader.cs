/**
@file ABOneBundleLoader.cs
@author NDark
@date 20171225 . file started.
*/

using UnityEngine;
using System.Collections;

namespace AssetBundles
{

#if ENABLE_NDINFRA_ONE_BUNDLE 

	public class ABOneBundleLoader : AssetBundleLoadAssetOperation
	{
		protected string 				m_AssetBundleName;
		protected string 				m_DownloadingError;
		
		public override T GetAsset<T>()
		{
			if ( null != m_Bundle )
				return m_Bundle as T;
			else
				return null;
		}
		
		public LoadedAssetBundle GetBundle()
		{
			return m_Bundle ;
		}
		protected LoadedAssetBundle m_Bundle = null ;
		
		public ABOneBundleLoader (string bundleName)
		{
			m_AssetBundleName = bundleName;
		}
		
		// Returns true if more Update calls are required.
		public override bool Update ()
		{
			if (m_Bundle != null)
				return false;
			
			m_Bundle = AssetBundleManager.GetLoadedAssetBundle (m_AssetBundleName, out m_DownloadingError);
			if (m_Bundle != null)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		
		public override bool IsDone ()
		{
			// Return if meeting downloading error.
			// m_DownloadingError might come from the dependency downloading.
			if (m_Bundle == null && m_DownloadingError != null)
			{
				Debug.LogError(m_DownloadingError);
				return true;
			}
			
			return m_Bundle != null ;
		}
	}

	public class ABOneBundleLoaderSimulation : ABOneBundleLoader
	{
		Object							m_SimulatedObject;

		public ABOneBundleLoaderSimulation ( string _BundleName , Object simulatedObject) : base( _BundleName )
		{
			m_SimulatedObject = simulatedObject;
		}

		public override T GetAsset<T>()
		{
			return m_SimulatedObject as T;
		}

		public override bool Update ()
		{
			return false;
		}

		public override bool IsDone ()
		{
			return true;
		}
	}

#endif 
// ENABLE_NDINFRA_ONE_BUNDLE 

	
}
