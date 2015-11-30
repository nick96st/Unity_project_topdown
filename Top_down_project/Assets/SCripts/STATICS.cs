using UnityEngine;
using System.Collections;

public class STATICS : MonoBehaviour {

	static public int playerCounts;
	static public int ScreenResX;
	static public int ScreenResY;
	static public int ScreenRatioX;
	static public int ScreenRatioY;
	struct playerTraits{

	};


	void Start ()
	{playerCounts = 3;
		ScreenResX = 1080;
		ScreenResY = 860; 
		ScreenRatioX = 16;
		ScreenRatioY = 9;
	}
}
