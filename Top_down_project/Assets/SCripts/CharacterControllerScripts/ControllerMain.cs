using UnityEngine;
using System.Collections;

public class ControllerMain : MonoBehaviour {
	public struct command{
		byte vid;
		byte directionX,directionZ;
		GameObject target;
		//GameObject UI;


		public command(byte V,byte X,byte Z,GameObject T)
		{	
			vid=V;
			directionX=X;
			directionZ=Z;
			target=T;
		}
	};// walk obviously,shoot vector,
	Vector3 mousePos; // to be used where the Ui should appear
	command[] listOfCommands=new command[7];//
	command current;
	int begin,end;
	bool inAction;
	RaycastHit hit1;
	Ray mouseRay;
	byte buttonsToggle;//used to note which button command is Toggled so we dont do several checks everytime
	                   // and so that we can access data for it directly
	// Use this for initialization
	void Start () {
		begin = end = 0;
		buttonsToggle = 1;
		inAction = false;
	
	}

	/*
	private void AddCommand(byte V,byte X,byte Y,GameObject T)
	{   
		LastClick.
		end++; 
		listOfCommands [end]= new command (V, X, Y, T);

	}
	void get_click()
	{ addCommand((byte) 1,
	}
     */
	// Update is called once per frame
	void Update () 
	{    mousePos = Input.mousePosition;
		mouseRay = Camera.main.ScreenPointToRay (mousePos);
			if(Input.GetMouseButtonDown(0))
		{ Debug.Log("in IF"+begin.ToString());
			GameObject.Find("ScriptHolder").GetComponent<UITasks>().unEnableThis();

		if(Physics.Raycast(mouseRay,out hit1,10000))
			{ Debug.Log(mousePos.y.ToString());
				Debug.Log(hit1.transform.gameObject.tag.ToString());
				if(hit1.transform.gameObject.tag=="Terrain")
						{
							UITasks.mousePos = mousePos;
							UITasks.task =1;// task 1 is walk navigation UI(move,move and shoot)
							UITasks.Target = hit1.transform.gameObject;
							Debug.Log("clicked on ground");

						}
				else if(hit1.transform.gameObject.tag=="Player")
					{// UI Activate
					UITasks.mousePos = mousePos;
					UITasks.task =2; // task 2 = player to player interation UI control
					UITasks.Target = hit1.transform.gameObject;//
					Debug.Log("clicked on player");
					if(UITasks.spawnedUI==false)
					GameObject.Find("ScriptHolder").GetComponent<UITasks>().SpawnUI();
				

					}
				else if(hit1.transform.gameObject.tag=="Lootable")
				{// UI Activate
					UITasks.mousePos = mousePos;
					UITasks.task =3;//  task 3 =Lootable 
					UITasks.Target = hit1.transform.gameObject;
					Debug.Log("clicked on lootable");

				}
				else if(hit1.transform.gameObject.tag=="NPC")
				{// UI Activate
					UITasks.mousePos = mousePos;
					UITasks.task =4;// task 4 is NPC interaction UI(shoot,talk,daze(if close))
					UITasks.Target = hit1.transform.gameObject;
					Debug.Log("clicked on NPC");
				}
				else if(hit1.transform.gameObject.tag=="Door")
				{// UI activate
					UITasks.mousePos = mousePos;
					UITasks.task =5;// task 5 is door interaction UI(shoot,talk,daze(if close))
					UITasks.Target = hit1.transform.gameObject;
				}
			}

	
		}
	}
}
