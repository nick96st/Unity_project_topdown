using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UICotrollerPlaying : MonoBehaviour {
	//static byte playerCount;
	public Text Info;
	public GameObject CharactersPrefab;
	GameObject [] Players=new GameObject[5];
	 private int player_count;
	// Use this for initialization
	void Start () {
		player_count = STATICS.playerCounts;
		Info.text = player_count.ToString();
		for (int i=0; i<player_count; i++)
			Players [i] = Instantiate (CharactersPrefab, new Vector3 (5*i, 5*i, 5*i), 
			                                     //edit proper coordinate as __StartPoint
			                          CharactersPrefab.transform.rotation )as GameObject;
			                            
	
	}
	
	// Update is called once per frame
	void Update () {

	}
}