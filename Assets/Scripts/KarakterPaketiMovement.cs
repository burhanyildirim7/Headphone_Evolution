using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class KarakterPaketiMovement : MonoBehaviour
{
    [SerializeField] public float _speed;
    int totalYear;


    void Update()
    {
        if (GameController.instance.isContinue == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        }
        else
        {

        }

    }




}
