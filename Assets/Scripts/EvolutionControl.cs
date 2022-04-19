using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolutionControl : MonoBehaviour
{
    public int year = 0;
    public int changeHeadphoneYear;

    public List<GameObject> headphones = new List<GameObject>();

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



    }

    void ChangeHeadphone()  //Her kaç yýlda bir kulaklýk deðiþecek kodu;
    {
        for (int i = 0; i < headphones.Count; i++)
        {

       
            if (year >= changeHeadphoneYear * (i + 1))
            {
                headphones[i].SetActive(true);
            
              

           
            }
            else
            {
                headphones[i].SetActive(false);
            }

        

        }
    }
}
