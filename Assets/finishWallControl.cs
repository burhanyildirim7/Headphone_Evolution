using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class finishWallControl : MonoBehaviour
{
     List<GameObject> finishWalls = new List<GameObject>();

    private int changeAgeYear;
     void Start()
    {
        changeAgeYear = GameObject.FindGameObjectWithTag("Player").GetComponent<EvolutionControl>().changeHeadphoneYear;
        for (int i = 0; i < transform.childCount; i++)
        {
            finishWalls.Add(transform.GetChild(i).gameObject);
        }

        for (int i = 0; i < finishWalls.Count; i++)
        {
            finishWalls[i].GetComponent<finishWallText>().finishWallValueText.text = "" + changeAgeYear * i;
        }

       
    }
}
