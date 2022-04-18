using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DoorControl : MonoBehaviour
{
    public Text valueOfDoorText;
    public string valueOfDoor;

    
    void Start()
    {
        valueOfDoorText.text = "" + valueOfDoor;

   }

    // Update is called once per frame
    void Update()
    {
        
    }
}
