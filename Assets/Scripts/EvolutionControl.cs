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
    public ParticleSystem upgradeEffect;

    Animator playerAnim;


    int currentHeadphoneLevel;
    int previousHeadphoneLevel;

    bool headphoneBetter;
    
    void Start()
    {
      
        playerAnim = GetComponent<Animator>();

     
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

        if (other.tag == "increaseDoor")
        {
            year += other.gameObject.GetComponent<DoorControl>().intValueOfDoor;
           
            ChangeHeadphone();

        }

        if (other.tag == "decreaseDoor")
        {
            if (Mathf.Abs(other.gameObject.GetComponent<DoorControl>().intValueOfDoor)>year)  // GameOver
            {
                Time.timeScale = 0;
            }
            year += other.gameObject.GetComponent<DoorControl>().intValueOfDoor;

            ChangeHeadphone();



        }



  
 

    }

    void ChangeHeadphone()  //Her kaç yýlda bir kulaklýk deðiþecek kodu;
    {

        previousHeadphoneLevel = currentHeadphoneLevel;


        for (int i = 1; i < headphones.Count; i++)
        {


            if (year >= changeHeadphoneYear * i)
            {
                
            
              
                headphones[i - 1].SetActive(false);
                headphones[i].SetActive(true);

              

                currentHeadphoneLevel = i;

           
            }
            else
            {
                headphones[i].SetActive(false);
            }

     
        }

        if (previousHeadphoneLevel < currentHeadphoneLevel)
        {
            happyFace.Play();
            StartCoroutine(AnimatorControl());
        }
        else if (previousHeadphoneLevel > currentHeadphoneLevel)
        {
            sadFace.Play();
        }
       






    }

    IEnumerator AnimatorControl()
    {
        playerAnim.SetBool("turnAround", true);
        yield return new WaitForSeconds(1);
        playerAnim.SetBool("turnAround", false);
    }
        
        }
 

