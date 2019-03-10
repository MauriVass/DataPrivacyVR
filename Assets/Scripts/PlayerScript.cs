using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
	  public GameObject camera, player;

		float timeTouch, velocity=4f, threshold = 0.4f;
		public float force;
		bool touched = false, haveMagnifier, collectedText;
		Vector3 pos,vel;
		public Text[] testi;
		public GameObject[] image;

		public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpc;

		public bool playerMoving;

		RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
			  haveMagnifier = false;
				pos = player.transform.position;
				Cursor.visible=false;
    }

    // Update is called once per frame
    void Update()
    {
			if (Input.touchCount > 0)
			{
						Touch touch = Input.GetTouch(0);

						// Move the cube if the screen has the finger moving.
						if (touch.phase == TouchPhase.Began)
						{
							//timeTouch+=Time.deltaTime;
							testi[0].text = "Began";
							testi[1].text = "Began";
							touched=true;
						}
						if (touch.phase == TouchPhase.Stationary)
						{
							timeTouch+=Time.deltaTime;
							if (timeTouch>1) {
								fpc.canMove = true;
							}

							testi[0].text = "Stationary";
							testi[1].text = "Stationary";
						}
						if (touch.phase == TouchPhase.Ended)
						{
							fpc.canMove = false;

							timeTouch = 0;
							testi[0].text = "Ended";
							testi[1].text = "Ended";
						}

/*
						if ( (timeTouch > threshold) || (touch.phase == TouchPhase.Stationary) ) {
							//pos.x+=GOcamera.transform.forward.x*velocity*Time.deltaTime;
							//pos.y+=GOcamera.transform.forward.y*velocity*Time.deltaTime;
							//pos.z+=GOcamera.transform.forward.z*velocity*Time.deltaTime;
							//vel = GOcamera.transform.forward;

							//player.transform.position=pos;

							vel = GOcamera.transform.forward;
							player.GetComponent<Rigidbody>().AddForce(vel*force);

							timeTouch=threshold-0.001f;
							testi[0].text = "Moving";
							testi[1].text = "Moving";
						}
						else{
							 //thisPlayer.GetComponent<FirstPersonController>().canMove=false;
							 //touched=true;
						}
						//pos=pos+vel;
			}else{
				player.GetComponent<Rigidbody>().velocity=Vector3.zero;
*/
			}


///*
						if (Input.GetKey(KeyCode.W)) {
							fpc.canMove = true;
						}else{
							fpc.canMove = false;
						}
						if (Input.GetMouseButtonDown(1))
						{
							touched = true;
						}
//*/

				//Debug.DrawRay(GOcamera.transform.position,GOcamera.transform.forward*100,Color.green);
				if (Input.GetMouseButtonDown(0)||touched)
				{//camera.transform.TransformDirection(Vector3.forward)
					if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, Mathf.Infinity))
					{
						Debug.Log("Did Hit :" + hit.collider.transform.tag);

						float distance = Vector3.Distance(player.transform.position,hit.point);
						float dist = 10;

						if (hit.collider.transform.tag == "Server" && distance < dist) {
							if(!hit.transform.gameObject.GetComponent<ServerScript>().Active){
								hit.transform.gameObject.GetComponent<ServerScript>().Active = true;
								hit.transform.gameObject.GetComponent<ServerScript>().canMove=true;
							}
							print("Moved");
						}

						if (hit.collider.transform.tag == "Magnifier" && distance < dist) {
							//hit.transform.gameObject.GetComponent<ServerScript>().canMove=true;
							hit.collider.transform.gameObject.SetActive(false);
							haveMagnifier = true;

							image[0].SetActive(true);
							image[1].SetActive(true);

							print("Collected Magnifier");
						}

						if (hit.collider.transform.tag == "CryptedNumbers" && distance < dist) {
								print("numbers");

								if (haveMagnifier) {
									hit.collider.transform.gameObject.SetActive(false);
									collectedText = true;

									print("Collected");
								}
								else{
									print("Need a Magnifier");
								}
						}
						
					}
					else
					{
						Debug.DrawRay(transform.position, camera.transform.TransformDirection(Vector3.forward) * 1000, Color.white);
						Debug.Log("Did not Hit");

					}
					touched = false;
				}
				else if (Physics.Raycast(camera.transform.position, camera.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
				{
				}

   }

}
