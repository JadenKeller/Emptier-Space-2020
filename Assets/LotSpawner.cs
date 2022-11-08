using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LotSpawner : MonoBehaviour
{

    public GameObject[] lots; 
    // Start is called before the first frame update
    void Start()
    {
        GameObject piClone = Instantiate(lots[Random.Range(0, lots.Length)], transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
