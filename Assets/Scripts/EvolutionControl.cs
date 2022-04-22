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

    GameObject currentHeadphone;
    GameObject previousHeadphone;

    int currentHeadphoneLevel;
    int previousHeadphoneLevel;

  
    
    void Start()
    {
        currentHeadphone = headphones[0];
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

        Debug.Log(year);
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

   /*

        if (currentHeadphoneLevel < previousHeadphoneLevel && currentHeadphone != previousHeadphone)
        {
            sadFace.Play();
          

        }
        else if (currentHeadphoneLevel > previousHeadphoneLevel && currentHeadphone != previousHeadphone && headphones[0].activeSelf)
        {
            happyFace.Play();
            upgradeEffect.Play();
            playerAnim.SetBool("turnAround", true);
           
        }
   */

    }

    void ChangeHeadphone()  //Her kaç yýlda bir kulaklýk deðiþecek kodu;
    {
        /*
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
                if (headphones[i-1].activeSelf)
                {
                    happyFace.Play();
                    upgradeEffect.Play();
                    StartCoroutine(AnimatorControl());
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

    IEnumerator AnimatorControl()
    {
        playerAnim.SetBool("turnAround", true);
        yield return new WaitForSeconds(1);
        playerAnim.SetBool("turnAround", false);
    }
        */
        }
 
}
