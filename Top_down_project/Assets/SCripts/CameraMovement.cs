

using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	GameObject GameCamera;
	int CameraMoveSpeed;
	int cameraMaxXY=50;
	int CameraRotDisLocation=400;
	float startTime;
	float journeyLength =100;
	short non_inverse=1,inverse=0,negetor=1;// it is reversed to what i wanted but works
	// negetor needed since after Inversing it didnt work properly for Ox

	// Use this for initialization
	void Start () {
	
		CameraMoveSpeed = 100;
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () 
	{   

///////////////////// CAMERA END OF SCREEN MOVEMENT //////////////////////////
				float distCovered = (Time.time - startTime) * CameraMoveSpeed;
				float fracJourney = distCovered / journeyLength;
				//	transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
				if (Input.mousePosition.x > Screen.width - 50 && 
		            this.transform.position.x*non_inverse <cameraMaxXY &&
		    (this.transform.position.z-CameraRotDisLocation)*inverse >-cameraMaxXY) {
						this.transform.position = 
		    Vector3.Lerp 
           (this.transform.position,
  			new Vector3 (this.transform.position.x + non_inverse*negetor *CameraMoveSpeed * Time.deltaTime,
					     this.transform.position.y,
					     this.transform.position.z + inverse* negetor * CameraMoveSpeed * Time.deltaTime),
		    fracJourney);
				}

		else if (Input.mousePosition.x < 0 + 50 && 
		         this.transform.position.x*non_inverse >-cameraMaxXY &&
		         (this.transform.position.z-CameraRotDisLocation)*inverse <cameraMaxXY) {
						this.transform.position = 
		    Vector3.Lerp 
           (this.transform.position,
			new Vector3 (this.transform.position.x - non_inverse*negetor *CameraMoveSpeed * Time.deltaTime,
					     this.transform.position.y,
					     this.transform.position.z - inverse *negetor * CameraMoveSpeed * Time.deltaTime),
			fracJourney);
				}

		if (Input.mousePosition.y > Screen.height - 50 && 
		    (this.transform.position.x+CameraRotDisLocation)*inverse <cameraMaxXY &&
		    (this.transform.position.z) *non_inverse <cameraMaxXY)
						this.transform.position = 
		    Vector3.Lerp 
           (this.transform.position,
				 new Vector3 (this.transform.position.x + inverse *CameraMoveSpeed * Time.deltaTime,
				             this.transform.position.y,
				             this.transform.position.z + non_inverse * CameraMoveSpeed * Time.deltaTime),
		    fracJourney);

		else if (Input.mousePosition.y < 0 + 50 &&
		         (this.transform.position.x+CameraRotDisLocation)*inverse >-(cameraMaxXY) &&
		         this.transform.position.z *non_inverse >-cameraMaxXY)
						this.transform.position = 
				Vector3.Lerp 
				(this.transform.position,
				 new Vector3 (this.transform.position.x - inverse *CameraMoveSpeed * Time.deltaTime,
				             this.transform.position.y,
				             this.transform.position.z - non_inverse * CameraMoveSpeed * Time.deltaTime),
				 fracJourney);

		////////////// CAMERA ROTATION BY 90 DEGREES //////
				if (Input.GetKeyDown (KeyCode.D)) {
						if (transform.eulerAngles != (new Vector3 (30, 90, 0))) {
								transform.eulerAngles = new Vector3 (30, 90, 0);
								transform.position = new Vector3 (this.transform.position.x - CameraRotDisLocation,
			                                this.transform.position.y,
			                                this.transform.position.z+CameraRotDisLocation );
				inverse=1;
				non_inverse=0;
				negetor=-1;
						}
				}
				if (Input.GetKeyDown (KeyCode.A)) {
						if (transform.eulerAngles != (new Vector3 (30, 0, 0))) {
								transform.eulerAngles = new Vector3 (30, 0, 0);
								transform.position = new Vector3 (this.transform.position.x + CameraRotDisLocation,
						                                this.transform.position.y,
						                                this.transform.position.z - CameraRotDisLocation);
				inverse=0;
				non_inverse=1;
				negetor =1;
						}                          
				}
				//transform.eulerAngles.Set(30,0,0);
		}
}
