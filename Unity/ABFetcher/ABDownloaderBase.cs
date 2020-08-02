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
	
	protected virtual void DoBundleLoadHandler( string _BundleKey , AssetBundles.LoadedAssetBundle _Bundle , string [] pathArray )
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

