using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMoreLots : MonoBehaviour  //script will load more lots in chunks when used correctly with the Large Lot prefab. 15 lots per each Large Lot. Lots spawn themselves from an array. Large Lot loads new lots with collision triggers. 
{
   // public GameObject moreLots;
   // public Bounds bounds; 

    public GameObject center;
    public GameObject player;
    Vector3 lastPosition = new Vector3(0, 0, 0);
    Vector3 offsetVector = new Vector3(0, 0, 1400);
    public GameObject lotPrefab;
    public GameObject target;
    public bool exited;
    public bool entered; 
    public GameObject despawn;
    private bool back;
    private bool front;
    private bool side; 


   

    // Start is called before the first frame update
    void Start()
    {
        exited = false;
        entered = false;
        front = false;      
        back = false;
        side = false; 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distance = center.transform.position - player.transform.position;
    //    print(distance.magnitude);
    }
    void OnTriggerEnter(Collider other) {
        if (other.tag == "Player"){ 
            
                Vector3 distance = center.transform.position - player.transform.position; //used to get distance of player from a gameobject used to define the "center" of the world 
                entered = true; 
                Vector3 direction = other.transform.position - transform.position;   //used to get direction of player 

            if (Vector3.Dot(transform.forward, direction) > 0) //determines the side of player approach (important to avoid double pasting lots or erasing the wrong lots) 
            {
                print("Back");
                back = true; 
            }
            if (Vector3.Dot(transform.forward, direction) < 0)
            {
                print("Front");
                front = true;
            }
            if (Vector3.Dot(transform.forward, direction) == 0)
            {
                print("Side");
                side = true; 
            }
                if (front == true)  //only spawns a lot if player is apporaching empty space from the front 
                {
                    MyFunction();
                    front = false; 
                    
                }
            }
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Player")
        {

            Vector3 distance = center.transform.position - player.transform.position;
            exited = true;
            entered = false;
            Vector3 direction = other.transform.position - transform.position;

            if (Vector3.Dot(transform.forward, direction) > 0)
            {
                print("Back");
                back = true;
            }
            if (Vector3.Dot(transform.forward, direction) < 0)
            {
                print("Front");
                front = true;
            }
            if (Vector3.Dot(transform.forward, direction) == 0)
            {
                print("Side");
                side = true;
            }

            if (front == true)   //only despawns the lot if the player is returning to where they came, before reaching the new lot 
            {
                
                GameObject piClone = Instantiate(despawn, target.transform.position, target.transform.rotation);
                front = false; 
            }
        }
    }
            void MyFunction()
            {
               GameObject piClone = Instantiate(lotPrefab, target.transform.position, target.transform.rotation);
               // GameObject lotPrefabInstance = GameObject.Instantiate(lotPrefab, lastPosition + offsetVector, Quaternion.identity);
              //  lastPosition = lotPrefabInstance.transform.position;
                
            }
        }


