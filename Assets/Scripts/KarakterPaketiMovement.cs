using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class KarakterPaketiMovement : MonoBehaviour
{
    [SerializeField] public float _speed;
    int totalYear;
    void Start()
    {
     
    }


    void FixedUpdate()
    {
        if (GameController.instance.isContinue == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * _speed);
        }
        else
        {

        }
        
    }

    void OnTriggerEnter(Collider other)
    {
      

    }


}
