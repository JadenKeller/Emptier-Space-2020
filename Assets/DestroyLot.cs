using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other) {
        if (other.tag == "Lot" || other.tag == "LargeLot") {
            Destroy(other.gameObject);
            Destroy(this); 
        }
    }
}
