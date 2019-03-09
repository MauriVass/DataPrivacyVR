using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerScript : MonoBehaviour
{
    public bool canMove, Active=false;
    Vector3 xpos,messagePos;
    public GameObject drawer,message;
    float transition, speed = 0.7f;
    bool canShow;
    float posini;
    // Start is called before the first frame update
    void Start()
    {
        xpos = drawer.transform.localPosition;
        if (!message) {

          messagePos = message.transform.localPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
      if (canMove) {
        transition+=Time.deltaTime*speed;
        if (transition<1) {
          posini = -60f;//transform.position.x;
          xpos.x = Mathf.Lerp(posini,posini*2.6f,transition);
          drawer.transform.localPosition = xpos;
        }else{
          canMove=false;
          canShow = true;
          transition = 1;

          transition=0;
          posini = message.transform.localPosition.z;
          speed = 0.6f;
        }
      }

      if (canShow) {
        message.SetActive(true);
        transition+=Time.deltaTime*speed;
        if (transition<1) {
          messagePos.y = Mathf.Lerp(-100f,0f,transition);
          message.transform.localPosition = messagePos;

          //print(messagePos + " " + message.transform.localPosition + " " + transition);
        }else{
          canShow = false;
          //transition = 0;
        }
      }
    }
}
