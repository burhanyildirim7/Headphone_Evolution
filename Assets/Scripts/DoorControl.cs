using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DoorControl : MonoBehaviour
{
    public Text valueOfDoorText;
    public string valueOfDoor;
    public int intValueOfDoor;

    GameObject EvolutionControl;

    void Start()
    {
        valueOfDoorText.text = "" + valueOfDoor;

        EvolutionControl = GameObject.FindGameObjectWithTag("Player");

        intValueOfDoor = int.Parse(valueOfDoor);
   }


}
