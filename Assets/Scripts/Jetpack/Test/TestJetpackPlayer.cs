using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestJetpackPlayer : MonoBehaviour
{
    Animator animator;
    public List<GameObject> Skins = new List<GameObject>();
    public int SkinIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    animator.SetTrigger("DancingB");
        //}


        for (int i = 0; i < Skins.Count; i++)
        {
            Skins[i].SetActive(SkinIndex == i);
        }
    }
}
