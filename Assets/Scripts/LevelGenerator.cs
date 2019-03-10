using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    /*
     * Questo script è una semplice modifica dello script LevelGenerator.cs
     */

    // Numero di server
    public int nCabinet;

    public List<GameObject> allServer;
    // Il prefab
    public GameObject[] server;
    public int[] forward;
    float X;
    float Y;
    public float offset;
    float sizeZ;

    void CreateLevel(){
        allServer = new List<GameObject>();

        for (int i=0; i<server.Length; i++) {

              X = server[i].transform.position.x;
              Y = server[i].transform.position.y;
              sizeZ = server[i].GetComponent<BoxCollider>().size.z*server[i].transform.localScale.z;

              float lastZ = server[i].transform.position.z;
              float newZ = 0;

              // Questo ciclo eseguirà il pezzo di codice fra {} un numero di volte pari a nPlane
              for (int j = 0; j < nCabinet; j++)
              {
                  // Generiamo un nuovo piano con le caratteristiche del prefab che abbiamo assegnato in Editor
                  GameObject newPlane = Instantiate(server[i]);
                  newPlane.transform.name = "Server " + (i+j);
                  allServer.Add(newPlane);

                  newZ = lastZ - (sizeZ + offset) * forward[i];

                  // Assegniamo al nuovo server la posizione che abbiamo calcolato.
                  newPlane.transform.position = new Vector3(X, Y, newZ);

                  lastZ = newZ;
              }
      }
    }

    void Start()
    {
      //server = GameObject.FindGameObjectsWithTag("Server");
      /*
      for (int i=0; i<allServer.Count; i++) {
        GameObject g = allServer[i];
        print(g.transform.name);
      }
      */
      ///int ran = Random.Range(1,server.Count);
      //allServer[ran].transform.GetChild(1).gameObject.SetActive(true);
    //  allServer[ran].transform.GetChild(0).gameObject.SetActive(false);
      //print(ran);
    }


      /*CursorLockMode wantedMode;
       // Apply requested cursor state
       void SetCursorState()
       {
           Cursor.lockState = wantedMode;
           // Hide cursor when locking
           Cursor.visible = (CursorLockMode.Locked != wantedMode);
       }


    void Update(){
      if (Input.GetKeyDown(KeyCode.Escape))
              Cursor.lockState = wantedMode = CursorLockMode.None;
      if (Input.GetKeyDown(KeyCode.B))
              wantedMode = CursorLockMode.Confined;
          SetCursorState();
    }*/
}
