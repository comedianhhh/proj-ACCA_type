using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEffect : MonoBehaviour
{
    // Start is called before the first frame update

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Ghost")
        {
            Color co = GetComponent<SkinnedMeshRenderer>().material.color;
            co.a = 170f / 255f;
        }
    }
}
