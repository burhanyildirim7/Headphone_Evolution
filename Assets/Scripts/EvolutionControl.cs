using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolutionControl : MonoBehaviour
{
    private int year = 0;
    public int changeHeadphoneYear;

    public GameObject headphone1;
    public GameObject headphone2;
    public GameObject headphone3;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(year);

        ChangeHeadphone();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "collectible")
        {
            year += 10;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "engel")
        {
            year -= 10;
            Destroy(other.gameObject);
          
        }


    }

    void ChangeHeadphone()  //Her kaç yýlda bir kulaklýk deðiþecek kodu;
    {
      
            if (year >= changeHeadphoneYear && year < changeHeadphoneYear*2)
            {
                headphone1.SetActive(true);
                headphone2.SetActive(false);
                headphone3.SetActive(false);
            }

            else if (year >= changeHeadphoneYear*2 && year< changeHeadphoneYear * 3)
            {
                headphone1.SetActive(false);
                headphone2.SetActive(true);
                headphone3.SetActive(false);
            }

            else if (year >= changeHeadphoneYear*3)
            {
                headphone1.SetActive(false);
                headphone2.SetActive(false);
                headphone3.SetActive(true);
            }
     
    }
}
