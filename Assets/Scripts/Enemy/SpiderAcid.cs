using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAcid : MonoBehaviour {

    Spider spider;

    private void Start()
    {
        spider = FindObjectOfType<Spider>();
        //spider = transform.parent.GetComponent<Spider>(); // alternatywne przypisanie, nie wiem czy lepsze, czy gorsze
    }

    public void Fire()
    {
        Debug.Log("AcidPewPew");
        spider.Attack();
    }
}
