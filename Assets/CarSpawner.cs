using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{

    public int numberOfObjects;
    public int currentObjects;
    public GameObject treeToPlace;

    private float randomX;
    private float randomZ;
    private Renderer r;

    // Start is called before the first frame update
    void Start()
    {

        r = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (currentObjects <= numberOfObjects || currentObjects == 0)
        {
            randomX = Random.Range(r.bounds.min.x, r.bounds.max.x);
            randomZ = Random.Range(r.bounds.min.z, r.bounds.max.z);

            if (Physics.Raycast(new Vector3(randomX, r.bounds.max.y, randomZ), -Vector3.up, out hit) && hit.transform.tag == "Ground")
            {
                Instantiate(treeToPlace, hit.point, Quaternion.Euler(0, Random.Range(0, 360), 0));
                currentObjects += 1;
            }
            //Instantiate(treeToPlace, new Vector3(randomX, Random.Range(minY, maxY), randomZ), transform.rotation);
            //currentObjects += 1;
        }
    
    }
    void SpawnCar () { 

    }
}

