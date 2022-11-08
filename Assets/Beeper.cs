using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Beeper : MonoBehaviour
{

    AudioSource audioData;
    public AudioClip beep;
    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            print("beep beep");
            AudioSource.PlayClipAtPoint(beep, transform.position);

        }
    }
}