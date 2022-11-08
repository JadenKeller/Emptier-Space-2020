using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceFromPlayer : MonoBehaviour
{

    public GameObject center;
    public GameObject player;
    Vector3 lastPosition = new Vector3(0, 0, 0);
    Vector3 offsetVector = new Vector3(0, 0, 134);
    public GameObject lotPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distance = center.transform.position - player.transform.position;
        print(distance.magnitude);

        if (distance.magnitude >= 5){
          //  MyFunction(); 
        }
    }
    void MyFunction()
    {
        GameObject lotPrefabInstance = GameObject.Instantiate(lotPrefab, lastPosition + offsetVector, Quaternion.identity);
        lastPosition = lotPrefabInstance.transform.position;
    }
}
