using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider_test : MonoBehaviour
{
    public GameObject TV;
    public GameObject Projection;
    public GameObject VMeetUI;


    private void Awake()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Projection.SetActive(true);
        VMeetUI.SetActive(false);
    }



  
}
