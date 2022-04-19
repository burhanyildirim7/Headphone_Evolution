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

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        yearText.text = "Þu Anki Yýl = " + year;

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
                for (int a = 0; a < headphones.Count; a++)
                {
                    headphones[a].SetActive(false);
                }
                headphones[i].SetActive(true);
             
            }
            else
            {
                headphones[i].SetActive(false);
            }
        }
    }
}
