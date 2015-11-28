using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ClickPlay : MonoBehaviour {
	//static public byte playerCount;
	public Slider PlayerC;
	public Button Starter;
	public Text CharCountNumber;
	 
	//"
	// Use this for initialization
	void Start () {

	}
	public void SliderV ()
	{STATICS.playerCounts = (byte)PlayerC.value;
		CharCountNumber.text = PlayerC.value.ToString(); 
	}
	// Update is called once per frame
	void Update () {
		Debug.Log ("HELIPP");

	}
}
