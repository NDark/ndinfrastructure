using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml ;

public class LoadScript : MonoBehaviour 
{
	public LocalConversationManager m_Manager = null ;

	// Use this for initialization
	void Start () 
	{
		this.StartLoadScript() ;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void StartLoadScript() 
	{
		XmlDocument doc = new XmlDocument() ;
		doc.Load( DATA + SCRIPT ) ;

		int firstStoryID = 0 ;
		if( doc.HasChildNodes)
		{
			Story story = new Story() ;
			TakeWithAnswer take = new TakeWithAnswer() ;
			XmlNode root = doc.FirstChild ;
			for( int i = 0 ; i < root.ChildNodes.Count ; ++i)
			{
				if( root.ChildNodes[i].Name == "Story" && 
					true == XMLParseUtility.ParseStory( root.ChildNodes[i] , ref story ) )
				{
					m_Manager.Stories.Add( story ) ;
					firstStoryID = story.StoryUID ;
					story = new Story() ;
				}
				else if( root.ChildNodes[i].Name == "Take" && 
					true == XMLParseUtility.ParseTakeWithAnswer( root.ChildNodes[i] , ref take ) )
				{
					m_Manager.Takes.Add( take ) ;
					take = new TakeWithAnswer() ;
				}
			}

			Debug.LogWarning("m_Manager.Stories.Count=" + m_Manager.Stories.Count ) ;
			Debug.LogWarning("m_Manager.Takes.Count=" + m_Manager.Takes.Count ) ;

			m_Manager.ActiveConversation( firstStoryID ) ;
		}




	}

	const string DATA = "Data/" ;
	const string SCRIPT = "Script.txt" ;
}
