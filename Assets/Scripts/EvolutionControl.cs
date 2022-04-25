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

        year = 1850;
    }

    // Update is called once per frame
    void Update()
    {
        yearText.text = "" + year;

        if (year >= 2022)
        {
            year = 2022;
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "increaseDoor")
        {
            MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);

            other.gameObject.GetComponent<DoorControl>().EfektPatlat();

            year += other.gameObject.GetComponent<DoorControl>().intValueOfDoor;

            ChangeHeadphone();



            Destroy(other.gameObject);

        }

        if (other.tag == "decreaseDoor")
        {
            MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);

            other.gameObject.GetComponent<DoorControl>().EfektPatlat();

            if (Mathf.Abs(other.gameObject.GetComponent<DoorControl>().intValueOfDoor) > year)  // GameOver
            {
                GameController.instance.isContinue = false;
                Invoke("LoseAc", 1f);
            }

            year += other.gameObject.GetComponent<DoorControl>().intValueOfDoor;

            ChangeHeadphone();

            Destroy(other.gameObject);



        }






    }

    private void LoseAc()
    {
        UIController.instance.ActivateLooseScreen();
    }

    public void ChangeHeadphone()  //Her ka? y?lda bir kulakl?k de?i?ecek kodu;
    {
        
        previousHeadphoneLevel = currentHeadphoneLevel;


        for (int i = 1; i < headphones.Count; i++)
        {


            if (year >=1850 + changeHeadphoneYear * i )
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
            upgradeEffect.Play();
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

    public void Resetle()
    {
        year = 0;
        previousHeadphoneLevel = 0;
        currentHeadphoneLevel = 0;
        ChangeHeadphone();
        headphones[0].SetActive(true);
    }

}


