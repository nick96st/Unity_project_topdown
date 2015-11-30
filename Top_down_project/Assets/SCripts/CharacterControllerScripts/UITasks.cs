using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// #### FIND FIX FOR WHEN U CLICK BOTH BUTTON AND OBJECT to run script only once; 

public class UITasks : MonoBehaviour {
	public static byte task;
	public static bool spawnedUI;// controls so that it hasnt 2 instance of the buttons
	public static GameObject Target;
	public static Vector3 mousePos;
	public GameObject ButtonInstance;
	RectTransform UIRect=new RectTransform();
	Rect UIRect1;
	GUILayout LayoutUI;
	byte buttonNeeded;
	GameObject[] ActionUI = new GameObject[4];
	Button[] ActionUIButton=new Button[4];

	public void unEnableThis()
	{   
		for(int j=0;j<4;j++)
			if(ActionUI[j]!=null)
		Destroy(ActionUI[j]);
		spawnedUI = false;
		GameObject.Find ("ScriptHolder").GetComponent<UITasks> ().enabled = false;
		}

	// Use this for initialization
	void Awake () {
		

		UIRect1.x = mousePos.x;
		UIRect1.y = mousePos.y;
		UIRect1.width = Screen.width  / 10;
		UIRect1.height = Screen.height/ 10;
		UIRect1.position.x.Equals (100);
		UIRect1.position.y.Equals (100);
		buttonNeeded = 4;

			//ActionUI[i].enabled=false;
			//ActionUI[i].GetComponent<RectTransform>().=UIRect;


		}

	void Start()
	{
		}

    public void SpawnUI()
	{  
		spawnedUI = true;

		Debug.Log ("Start UI TAsks");
		if (STATICS.ScreenResX == 1080) {
			// Set Size according to Res and ratio;
						UIRect1.width = Screen.width/10;
			UIRect1.height =Screen.height/100*5+Screen.height%10;

				}
	
		for (int i=0; i<buttonNeeded; i++) {
			ActionUI[i] = GameObject.Instantiate(ButtonInstance,new Vector3(mousePos.x,mousePos.y-UIRect1.height*i,100),Quaternion.identity) as GameObject;
			ActionUI[i].transform.SetParent(GameObject.Find( "Canvas").transform);
		//	fixes bugs with SetParent.transform
			ActionUI[i].GetComponent<RectTransform>().sizeDelta =Vector2.zero ;
			ActionUI[i].GetComponent<RectTransform>().sizeDelta = new Vector2(UIRect1.width,UIRect1.height);
			// setup listener for Onclick to despawn +act
			// ####ADD LISTENER FOR ACTIONS
			ActionUIButton[i]= ActionUI[i].GetComponent<Button>();
			ActionUIButton[i].onClick.RemoveAllListeners();
			ActionUIButton[i].onClick.AddListener(() => unEnableThis());
	
		}

	
	
	}
     void Update()
	{
		}


}
