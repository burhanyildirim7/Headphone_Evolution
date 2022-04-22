using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DoorControl : MonoBehaviour
{
    public Text valueOfDoorText;
    public string valueOfDoor;
    public int intValueOfDoor;

    public bool day;
    public bool week;
    public bool month;
    public bool year;

    GameObject EvolutionControl;

    void Start()
    {
        valueOfDoorText.text = "" + valueOfDoor;

        EvolutionControl = GameObject.FindGameObjectWithTag("Player");

      

        if (day)
        {
            valueOfDoorText.text = "" + valueOfDoor + " DAY";
            intValueOfDoor = int.Parse(valueOfDoor)/365;
        }

        else if (week)
        {
            valueOfDoorText.text = "" + valueOfDoor + " WEEK";
            intValueOfDoor = int.Parse(valueOfDoor) / 54;
        }

        else if (month)
        {
            valueOfDoorText.text = "" + valueOfDoor + " MONTH";
            intValueOfDoor = int.Parse(valueOfDoor) / 12;
        }

        else if (year)
        {
            valueOfDoorText.text = "" + valueOfDoor + " YEAR";
            intValueOfDoor = int.Parse(valueOfDoor);
        }
    }

    


}
