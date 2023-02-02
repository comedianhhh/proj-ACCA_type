//By MingRu
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public float DebuffSpeed = 1;
    public float DebuffDuration = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player.Instance.SetSpeed(DebuffSpeed);
            Player.Instance.Invoke("RestoreSpeed", DebuffDuration);
            
            Destroy(gameObject);
        }

    }
}


