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

		protected string [] m_SimulatPathArray;
		public string [] GetSimulatPathArray()
		{
			return m_SimulatPathArray;
		}

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
		
		public ABOneBundleLoaderSimulation ( string _BundleName , string [] simulatPathArray) : base( _BundleName )
		{
			m_SimulatPathArray = simulatPathArray;
		}

		public override T GetAsset<T>()
		{
			return m_SimulatPathArray as T;
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
