using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DoorControl : MonoBehaviour
{
    public Text valueOfDoorText;
    public string valueOfDoor;

    GameObject EvolutionControl;

    void Start()
    {
        valueOfDoorText.text = "" + valueOfDoor;

        EvolutionControl = GameObject.FindGameObjectWithTag("Player");
   }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<EvolutionControl>().year += int.Parse(valueOfDoor);
        }
    }
}
