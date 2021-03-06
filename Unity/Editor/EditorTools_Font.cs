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
@file EditorTools_Font.cs
@author NDark
@date 20170618 . file started.

*/

// #define NDU_INFRASTRUCTURE_USE_NGUI

using UnityEngine;
using UnityEditor;

public static partial class EditorTools_MenuItem
{
	[MenuItem( "Tools/Font/ReplaceUIText" )]
	public static void ReplaceUIText()
	{
		Debug.LogWarning("ReplaceUIText");
		var objs = GameObject.FindObjectsOfType<UnityEngine.UI.Text>() ;
		Debug.LogWarning("objs.Length=" + objs.Length );
		
		var selectFont = Selection.activeObject ;
		if( selectFont.GetType().Name != typeof(Font).Name )
		{
			Debug.LogError("Select A Font");
			return ;
		}
		
		foreach( var obj in objs )
		{
			var components = obj.GetComponents<Component>();
			foreach( var comp in components )
			{
				if( comp.GetType().Name == "Text")
				{
					var text = comp as UnityEngine.UI.Text ;
					text.font = selectFont as Font ;
				}
			}
		}
		
		UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(
			UnityEngine.SceneManagement.SceneManager.GetActiveScene());
		
	}
	
#if !UNITY_2017_1_OR_NEWER
	[MenuItem( "Tools/Font/ReplaceGUIText" )]
	public static void ReplaceGUIText()
	{
		Debug.LogWarning("ReplaceGUIText");
		
		var objs = GameObject.FindObjectsOfType<GUIText>() ;
		Debug.LogWarning("objs.Length=" + objs.Length );
		
		var selectFont = Selection.activeObject ;
		if( selectFont.GetType().Name != typeof(Font).Name )
		{
			Debug.LogError("Select A Font");
			return ;
		}
		
		foreach( var obj in objs )
		{
			var components = obj.GetComponents<Component>();
			foreach( var comp in components )
			{
				if( comp.GetType().Name == "GUIText")
				{
					var tm = comp as GUIText ;
					tm.font = selectFont as Font ;
				}
			}
		}
		
		UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(
			UnityEngine.SceneManagement.SceneManager.GetActiveScene());
		
	}
#endif

	[MenuItem( "Tools/Font/ReplaceTextMesh" )]
	public static void ReplaceTextMesh()
	{
		Debug.LogWarning("ReplaceTextMesh");
		
		var objs = GameObject.FindObjectsOfType<TextMesh>() ;
		Debug.LogWarning("objs.Length=" + objs.Length );
		
		var selectFont = Selection.activeObject ;
		if( selectFont.GetType().Name != typeof(Font).Name )
		{
			Debug.LogError("Select A Font");
			return ;
		}
		
		foreach( var obj in objs )
		{
			var components = obj.GetComponents<Component>();
			foreach( var comp in components )
			{
				if( comp.GetType().Name == "TextMesh")
				{
					var tm = comp as TextMesh ;
					tm.font = selectFont as Font ;
				}
			}
		}
		
		UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(
			UnityEngine.SceneManagement.SceneManager.GetActiveScene());
		
		
	}

	
#if NDU_INFRASTRUCTURE_USE_NGUI
	[MenuItem( "Tools/Font/ReplaceUILabel" )]
	public static void ReplaceUILabel()
	{
		Debug.LogWarning("ReplaceUILabel");
		
		UILabel []objs = null ;
		// var objs = GameObject.FindObjectsOfType<UILabel>() ;
		// Debug.LogWarning("objs.Length=" + objs.Length );
		
		var selectFont = Selection.activeObject ;
		if( selectFont.GetType().Name != typeof(Font).Name )
		{
			Debug.LogError("Select A Font");
			return ;
		}
		
		foreach( var obj in objs )
		{
			var components = obj.GetComponents<Component>();
			foreach( var comp in components )
			{
				if( comp.GetType().Name == "UILabel")
				{
					// var uiLabel = comp as UILabel ;
					// uiLabel.trueTypeFont = selectFont  as Font;
				}
			}
		}
		
		UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(
			UnityEngine.SceneManagement.SceneManager.GetActiveScene());
		
	}
#endif 
// NDU_INFRASTRUCTURE_USE_NGUI


}
