using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CultureInfoExample : MonoBehaviour
{
	const string franceCultureKey = "fr-FR";
	const string englishCultureKey = "en-US";

	[System.Serializable]
	public class floatObj
	{
		public float v = 1.25f;
	}

	// Start is called before the first frame update
	void Start()
	{
		DoCultureInfoTest();
	}

	// Update is called once per frame
	void Update()
	{

	}

	void DoCultureInfoTest()
	{
		float pureFloat = 1.25f;

		// test to string of pure float variable and CreateSpecificCulture()
		{
			string franceFloatStr = pureFloat.ToString(System.Globalization.CultureInfo.CreateSpecificCulture(franceCultureKey));
			Debug.Log("franceFloatStr=" + franceFloatStr);// output is 1,25

			string englishFloatStr = pureFloat.ToString(System.Globalization.CultureInfo.CreateSpecificCulture(englishCultureKey));
			Debug.Log("englishFloatStr=" + englishFloatStr);// output is 1.25

		}

		// test string from json and current culture
		{
			floatObj fObj = new floatObj();

			var frCulture = new System.Globalization.CultureInfo(franceCultureKey);
			System.Threading.Thread.CurrentThread.CurrentCulture = frCulture;

			var franceJsonStr = JsonUtility.ToJson(fObj);
			Debug.Log("franceJsonStr" + franceJsonStr);
			Debug.Log("frCulture pureFloat" + pureFloat.ToString());

			var usCulture = new System.Globalization.CultureInfo(englishCultureKey);
			System.Threading.Thread.CurrentThread.CurrentCulture = usCulture;
			var englishJsonStr = JsonUtility.ToJson(fObj);
			Debug.Log("englishJsonStr=" + englishJsonStr);
			Debug.Log("usCulture pureFloat" + pureFloat.ToString());

		}

		// test NumberDecimalSeparator by cloneCulture of frCulture
		{

			var frCulture = new System.Globalization.CultureInfo(franceCultureKey);
			System.Threading.Thread.CurrentThread.CurrentCulture = frCulture;
			var cloneCulture = System.Globalization.CultureInfo.CurrentUICulture.Clone() as System.Globalization.CultureInfo;

			cloneCulture.NumberFormat.NumberDecimalSeparator = ".";
			System.Threading.Thread.CurrentThread.CurrentCulture = cloneCulture;
			Debug.Log("frCulture pureFloat" + pureFloat.ToString());

		}

	}
}
