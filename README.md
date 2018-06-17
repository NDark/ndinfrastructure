# ndinfrastructure

An infrastructure libraries for Unity & C#

## Brief 

Clone and checkout specified branch of this repository, use only limited functionality of following features without checkout entire irrelavant class and libraries.

## Usage

Use git submodule to add submodule from this repository and specify a branch name to use only that feature.

1. F_ABFetcher : Asset Bundle Loader ( official plugin included: https://assetstore.unity.com/packages/tools/utilities/assetbundle-manager-example-scenes-45836 )
    1. Provide a asset bundle loader ABFetcherLoaderBase to initialized asset bundle, and to be called as a loader.
	1. Provide a loading script ABDownloaderBase with states to check all specified bundle files.
	1. Inherited Classes : 
	    1. AssetBundleManager: Official asset bundle manager (static).
	    1. LoaderExample: use AssetBundleManager, to provide handler after the protected methods are called. ( ex. LoadAssetAsync_Callback )
		1. ABFetcherLoaderBase: Inherited from LoaderExample, and provide public method to be called by other process.
		1. ABDownloaderBase: Abstract class that is inherited from ABFetcherLoaderBase with states to be ready to check a list of CheckItem.
		1. ABDownloader: Inherited from ABDownloaderBase to use ABSetupInfo to check the versions of each bundles.
	1. Besides load asset handler and level handler, provide bundle loading handler. 
1. F_ConversationManager : Conversation(dialogs) manager
    1. A conversation manager traverse all stories and takes.
	1. Story: a indices of takes.
	1. Take: all information to present a take.
1. F_DataCenter : Generic data storage to save all data as string.
    1. Use data storage to check basic conditions be triggered.
1. F_EditorTools : 
    1. version incrementation and set to project setting. by a file Assets/Resources/version.txt
    1. Clean caching by Caching.CleanCache() or Caching.ClearCache().
	1. Delete playerprefs by PlayerPrefs.DeleteAll()
    1. font replacement among UnityEngine.UI.Text or GUIText by selected Font
1. F_EnumConverter : Genric enum converter to integer EnumIntConverter and string EnumStrConverter
1. F_MathTools : [DotNet] float equal by specified value and float.Epsilon
1. F_SpreadSheetLoader : 
    1. load a tab base table to List< string [] >. 
1. F_StateMachine : State machine with recording time and calling transition methods.
1. F_SystemDateTime : [DotNet] Time convertion from Date(-62135596800000) to System.DateTime
1. F_Timer : count down timer CountDownTimer with functionalities of Active(), Rewind(), Pospone(), ElapsedTime(), RemainingTime()
1. Platform(iOS&Android)
    1. F_PlatformString: Conversation between NSString* and char* _String in iOS
    1. F_Clipboard: Clip and paste between clipboard (iOS by UIPasteboard, Android by android.content.ClipData.)
    1. F_PlayerSettingTools: project setting tools, set UnityEditor.PlayerSettings.bundleVersion, and short vertion of iOS by CFBundleShortVersionString


# F_NGUIUTil 

An utility for NGUI (need to depend on NGUI plugin)

1. DisplayFPS.cs : use UILabel to display a average/min/max FPS of Time.deltaTime.
1. NGUIPanelHelper.cs : Use NGUIUICollector to collect UI component and update them.
1. NGUIUICollector.cs : To collect UILabel and UISprite in dictionary.
1. NGUIInvokeButton.cs : As OnClick() has been called, call the OnClick() of specified UIButton.
1. OnEscapeInvokeNGUIButtons.cs : Vis KeyCode.Escapem calling OnClick() to a button by a stack with push/pop.
1. SetNGUILocalization and NGUISetLocalization.cs : set Localization.language.


# F_UnityTools

1. ClickOpenFacebookApp.cs : OnClick() to open facebook with checking app existence.
1. CoordinateTools.cs : Update2DFrom3DWorldPos() Coordinate calculation from 2d to 3d.
1. DontDestroyGameObject.cs : Automatically set not destroy game object at beginning by using GameObject.DontDestroyOnLoad()
1. OnClickChangeScene.cs : By OnClick() to change scene by UnityEngine.SceneManagement.SceneManager.LoadScene()
1. OnClickOpenBrower.cs : By OnClick() to open browswer, support web player, WebGL player, and other platforms.
1. OnDoubleEscapeLeaveGame.cs : double escape leaving game by Application.Quit().
1. OnEscapeLeaveGame.cs : Chheck pressing escape(KeyCode.Escape) to leave game by Application.Quit().
1. UnityFind.cs : find gameobject and component under gameobject.
1. WaitSecChangeScene.cs : wait seconds and change scene by using UnityEngine.SceneManagement.SceneManager.LoadScene()



# P_ClassGen

1. A console project which generates C# class by a definition file.
1. Export SimpleJSONHelper to parse from SimpleJSON.JSONNode to class.
1. Export a SeqOperatorSimpleJSON from a collector of SeqOperatorBase

## Definition of format 

> Class:DataClass
> Protocol:DataController
> int a
> string b
> float c


# P_CSVToJSON 

1. Execute file.
1. Parse csv file to JSON structure array.

# P_GoogleSpreedSheetToJSON 

1. (need to logon google account to access file)
1. Execute file.
1. Load google spreed sheet to a JSON file.

# P_JSONParsersPerformance

1. Execute file.
1. Benchmark of performance of several C# compatible JSON methods

# P_LocalConversationManager

1. Execute file.
1. An implementation of Conversation Manager.

# T_SystemDateTime 

1. need to depend on Unity Test Environment
1. A Test of F_SystemDateTime.