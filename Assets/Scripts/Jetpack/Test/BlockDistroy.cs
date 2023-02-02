//By MingRu
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BlockDistroy : MonoBehaviour
{
    //private bool enterCollide = false;
    //public GameObject MyPlayer;
    //public Transform Point;
    //public bool Blocked = true;

    public bool InZone = false;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            InZone = true;
            Player.Instance.SetSpeed(1);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            InZone = false;
            Player.Instance.SetSpeed(10);
        }
    }
    void Update()
    {
        if (InZone && Input.GetKeyDown((KeyCode.Space)))
        {
            InZone = false;
            Player.Instance.SetSpeed(10);

            Destroy(transform.parent.gameObject);
        }
    }
}