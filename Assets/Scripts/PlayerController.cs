using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public int collectibleDegeri;
    public bool xVarMi = true;
    public bool collectibleVarMi = true;

    GameObject karakterPaketi;

    public GameObject _konfetiPaketi;

    private void Awake()
    {
        if (instance == null) instance = this;
        //else Destroy(this);
    }

    void Start()
    {
        StartingEvents();

    }

    /// <summary>
    /// Playerin collider olaylari.. collectible, engel veya finish noktasi icin. Burasi artirilabilir.
    /// elmas icin veya baska herhangi etkilesimler icin tag ekleyerek kontrol dongusune eklenir.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("collectible"))
        {
            // COLLECTIBLE CARPINCA YAPILACAKLAR...
            // ORNEK KULLANIM detaylar icin ctrl+click yapip fonksiyon aciklamasini oku

        }
        else if (other.CompareTag("engel"))
        {
            // ENGELELRE CARPINCA YAPILACAKLAR....
            GameController.instance.SetScore(-collectibleDegeri); // ORNEK KULLANIM detaylar icin ctrl+click yapip fonksiyon aciklamasini oku
            if (GameController.instance.score < 1850) // SKOR SIFIRIN ALTINA DUSTUYSE
            {
                // FAİL EVENTLERİ BURAYA YAZILACAK..
                GameController.instance.isContinue = false; // çarptığı anda oyuncunun yerinde durması ilerlememesi için
                UIController.instance.ActivateLooseScreen(); // Bu fonksiyon direk çağrılada bilir veya herhangi bir effect veya animasyon bitiminde de çağrılabilir..
                                                             // oyuncu fail durumunda bu fonksiyon çağrılacak.. 
            }


        }
        else if (other.gameObject.tag == "finishWall")
        {

            //GameObject.FindGameObjectWithTag("KarakterPaketi").GetComponent<KarakterPaketiMovement>()._speed = 0;

            GameController.instance.isContinue = false;

            //gameObject.transform.parent = null;
            transform.parent.transform.DOMove(other.gameObject.transform.position, 1).OnComplete(() => RaiseControl());



            // Debug.Log("Temas Var");
        }


    }

    void RaiseControl()
    {
        MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);

        // karakterPaketi.transform.DOMoveY(GameObject.FindGameObjectWithTag("Player").GetComponent<EvolutionControl>().year * 0.04f, 3);
        transform.parent = GameObject.FindGameObjectWithTag("finishWall").transform;
        /*
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<EvolutionControl>().year < 500)
        {
            GameObject.FindGameObjectWithTag("finishWall").transform.DOMoveY(GameObject.FindGameObjectWithTag("Player").GetComponent<EvolutionControl>().year * 0.042f, 5).OnComplete(() => FinishScene());
        }
        else if (GameObject.FindGameObjectWithTag("Player").GetComponent<EvolutionControl>().year >= 500 && GameObject.FindGameObjectWithTag("Player").GetComponent<EvolutionControl>().year < 1500)
        {
            GameObject.FindGameObjectWithTag("finishWall").transform.DOMoveY(GameObject.FindGameObjectWithTag("Player").GetComponent<EvolutionControl>().year * 0.042f, 7).OnComplete(() => FinishScene());
        }
        else if (GameObject.FindGameObjectWithTag("Player").GetComponent<EvolutionControl>().year >= 1500)
        {
            GameObject.FindGameObjectWithTag("finishWall").transform.DOMoveY(GameObject.FindGameObjectWithTag("Player").GetComponent<EvolutionControl>().year * 0.042f, 10).OnComplete(() => FinishScene());
        }
        else
        {

        }
        */

        if (GetComponent<EvolutionControl>().currentHeadphoneLevel + 1 == 1)
        {
            GameObject.FindGameObjectWithTag("finishWall").transform.DOMoveY(GameObject.Find("1x").transform.position.y, 1).OnComplete(() => FinishScene());
        }
        else if (GetComponent<EvolutionControl>().currentHeadphoneLevel + 1 == 2)
        {
            GameObject.FindGameObjectWithTag("finishWall").transform.DOMoveY(GameObject.Find("1.5x").transform.position.y, 1).OnComplete(() => FinishScene());
        }
        else if (GetComponent<EvolutionControl>().currentHeadphoneLevel + 1 == 3)
        {
            if (GetComponent<EvolutionControl>().year < 1882)
            {
                GameObject.FindGameObjectWithTag("finishWall").transform.DOMoveY(GameObject.Find("2x").transform.position.y, 1.5f).OnComplete(() => FinishScene());
            }
            else
            {
                GameObject.FindGameObjectWithTag("finishWall").transform.DOMoveY(GameObject.Find("2.5x").transform.position.y, 1.5f).OnComplete(() => FinishScene());
            }
        }
        else if (GetComponent<EvolutionControl>().currentHeadphoneLevel + 1 == 4)
        {
            GameObject.FindGameObjectWithTag("finishWall").transform.DOMoveY(GameObject.Find("3x").transform.position.y, 2).OnComplete(() => FinishScene());
        }
        else if (GetComponent<EvolutionControl>().currentHeadphoneLevel + 1 == 5)
        {
            GameObject.FindGameObjectWithTag("finishWall").transform.DOMoveY(GameObject.Find("3.5x").transform.position.y, 2).OnComplete(() => FinishScene());
        }
        else if (GetComponent<EvolutionControl>().currentHeadphoneLevel + 1 == 6)
        {
            if (GetComponent<EvolutionControl>().year < 1921)
            {
                GameObject.FindGameObjectWithTag("finishWall").transform.DOMoveY(GameObject.Find("4x").transform.position.y, 2.5f).OnComplete(() => FinishScene());
            }
            else
            {
                GameObject.FindGameObjectWithTag("finishWall").transform.DOMoveY(GameObject.Find("4.5x").transform.position.y, 2.5f).OnComplete(() => FinishScene());
            }

        }
        else if (GetComponent<EvolutionControl>().currentHeadphoneLevel + 1 == 7)
        {
            GameObject.FindGameObjectWithTag("finishWall").transform.DOMoveY(GameObject.Find("5x").transform.position.y, 3).OnComplete(() => FinishScene());
        }
        else if (GetComponent<EvolutionControl>().currentHeadphoneLevel + 1 == 8)
        {
            GameObject.FindGameObjectWithTag("finishWall").transform.DOMoveY(GameObject.Find("5.5x").transform.position.y, 3).OnComplete(() => FinishScene());
        }
        else if (GetComponent<EvolutionControl>().currentHeadphoneLevel + 1 == 9)
        {
            if (GetComponent<EvolutionControl>().year < 1960)
            {
                GameObject.FindGameObjectWithTag("finishWall").transform.DOMoveY(GameObject.Find("6x").transform.position.y, 3.5f).OnComplete(() => FinishScene());
            }
            else
            {
                GameObject.FindGameObjectWithTag("finishWall").transform.DOMoveY(GameObject.Find("6.5x").transform.position.y, 3.5f).OnComplete(() => FinishScene());
            }
        }
        else if (GetComponent<EvolutionControl>().currentHeadphoneLevel + 1 == 10)
        {
            GameObject.FindGameObjectWithTag("finishWall").transform.DOMoveY(GameObject.Find("7x").transform.position.y, 4).OnComplete(() => FinishScene());
        }
        else if (GetComponent<EvolutionControl>().currentHeadphoneLevel + 1 == 11)
        {
            GameObject.FindGameObjectWithTag("finishWall").transform.DOMoveY(GameObject.Find("7.5x").transform.position.y, 4).OnComplete(() => FinishScene());
        }
        else if (GetComponent<EvolutionControl>().currentHeadphoneLevel + 1 == 12)
        {
            if (GetComponent<EvolutionControl>().year < 1999)
            {
                GameObject.FindGameObjectWithTag("finishWall").transform.DOMoveY(GameObject.Find("8x").transform.position.y, 4.5f).OnComplete(() => FinishScene());
            }
            else
            {
                GameObject.FindGameObjectWithTag("finishWall").transform.DOMoveY(GameObject.Find("8.5x").transform.position.y, 4.5f).OnComplete(() => FinishScene());
            }
        }
        else if (GetComponent<EvolutionControl>().currentHeadphoneLevel + 1 == 13)
        {
            if (GetComponent<EvolutionControl>().year < 2019)
            {
                GameObject.FindGameObjectWithTag("finishWall").transform.DOMoveY(GameObject.Find("9x").transform.position.y, 5).OnComplete(() => FinishScene());
            }
            else
            {
                GameObject.FindGameObjectWithTag("finishWall").transform.DOMoveY(GameObject.Find("9.5x").transform.position.y, 5).OnComplete(() => FinishScene());
            }
        }
        else if (GetComponent<EvolutionControl>().currentHeadphoneLevel + 1 == 14)
        {
            GameObject.FindGameObjectWithTag("finishWall").transform.DOMoveY(GameObject.Find("10x").transform.position.y, 5).OnComplete(() => FinishScene());
        }

    }
    /// <summary>
    /// Bu fonksiyon her level baslarken cagrilir. 
    /// </summary>
    public void StartingEvents()
    {
        karakterPaketi = GameObject.FindGameObjectWithTag("KarakterPaketi");
        transform.parent = GameObject.FindGameObjectWithTag("UstPaket").transform;
        karakterPaketi.transform.position = Vector3.zero;
        transform.parent.transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.parent.transform.position = Vector3.zero;
        GameController.instance.isContinue = false;
        GameController.instance.isFinish = false;
        GameController.instance.score = 0;
        transform.position = new Vector3(0, 0, 0);
        //GetComponent<Collider>().enabled = true;

        GameObject.FindGameObjectWithTag("Player").GetComponent<EvolutionControl>().Resetle();
        //GameObject.FindGameObjectWithTag("Player").GetComponent<EvolutionControl>().ChangeHeadphone();
        _konfetiPaketi.SetActive(false);

    }

    private void FinishScene()
    {
        MoreMountains.NiceVibrations.MMVibrationManager.Haptic(MoreMountains.NiceVibrations.HapticTypes.MediumImpact);

        _konfetiPaketi.SetActive(true);
        GameController.instance.isContinue = false;
        GameController.instance.SetScore(GameObject.FindGameObjectWithTag("Player").GetComponent<EvolutionControl>().year / 10);
        GameController.instance.ScoreCarp(1);

        Invoke("WinAc", 1f);
    }

    private void WinAc()
    {
        UIController.instance.ActivateWinScreen();
    }


}
