using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EvolutionControl : MonoBehaviour
{

    public int year = 0;
    public Text yearText;
    public int changeHeadphoneYear;

    public List<GameObject> headphones = new List<GameObject>();

    public ParticleSystem sadFace;
    public ParticleSystem happyFace;


    GameObject currentHeadphone;
    GameObject previousHeadphone;

    int currentHeadphoneLevel;
    int previousHeadphoneLevel;


    
    void Start()
    {
        currentHeadphone = headphones[0];
    }

    // Update is called once per frame
    void Update()
    {
        yearText.text = "" + year;

        if (year<=0)
        {
            year = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        /*
        if (other.tag == "increaseDoor")
        {
            year += other.gameObject.GetComponent<DoorControl>().intValueOfDoor;
         
            ChangeHeadphone();

        }

        if (other.tag == "decreaseDoor")
        {
            year += other.gameObject.GetComponent<DoorControl>().intValueOfDoor;
            ChangeHeadphone();

            
   
        }

         if (currentHeadphoneLevel < previousHeadphoneLevel && currentHeadphoneLevel!=previousHeadphoneLevel)
        {
            sadFace.Play();
        }
        else if (currentHeadphoneLevel > previousHeadphoneLevel && currentHeadphoneLevel != previousHeadphoneLevel)
        {
            happyFace.Play();
        }
        */

        if (other.tag == "increaseDoor")
        {
            year += other.gameObject.GetComponent<DoorControl>().intValueOfDoor;

            ChangeHeadphone();

        }

        if (other.tag == "decreaseDoor")
        {
            year += other.gameObject.GetComponent<DoorControl>().intValueOfDoor;
            ChangeHeadphone();



        }

        if (currentHeadphoneLevel < previousHeadphoneLevel && currentHeadphone != previousHeadphone)
        {
            sadFace.Play();
        }
        else if (currentHeadphoneLevel > previousHeadphoneLevel && currentHeadphone != previousHeadphone && headphones[0].activeSelf)
        {
            happyFace.Play();
        }


    }

    void ChangeHeadphone()  //Her kaç yýlda bir kulaklýk deðiþecek kodu;
    {

        previousHeadphoneLevel = currentHeadphoneLevel;
        previousHeadphone = currentHeadphone;

        if (year <= changeHeadphoneYear)
        {
            headphones[0].SetActive(true);
            currentHeadphone = headphones[0].gameObject;
            sadFace.Play();
        }
        for (int i = 1; i < headphones.Count; i++)
        {


            if (year >= changeHeadphoneYear * i)
            {
                if (headphones[0].activeSelf)
                {
                    happyFace.Play();
                }
                headphones[i - 1].SetActive(false);
                headphones[i].SetActive(true);
                currentHeadphoneLevel = i;
                currentHeadphone = headphones[i].gameObject;

            }
            else
            {
                headphones[i].SetActive(false);
            }
        }
       
       





    }

 
}
