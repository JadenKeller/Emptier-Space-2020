using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LoadLevelOnTrigger : MonoBehaviour
{
    public string LevelToLoad;
    public GameObject definedButton;
    public UnityEvent OnClick = new UnityEvent();
    // Start is called before the first frame update
    void Start()
    {
        definedButton = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == gameObject)
            {
                Debug.Log("Button Clicked");
                OnClick.Invoke();
            }
        }
    }
}
 /*   void OnTriggerStay(Collider other)
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         RaycastHit Hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == gameObject)
            {
                Debug.Log("Button Clicked");
                OnClick.Invoke();
            }
        }
    }
         
    //    if (other.tag == "Player")
    //    {
          //  Application.LoadLevel(LevelToLoad);
    //    }
    }
} */ 