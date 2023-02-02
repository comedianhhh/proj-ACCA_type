//By Hongyi Bai
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChickBasketballanim : MonoBehaviour
{   public Tweener ballanim1;
    public Tweener ballanim2;
    public GameObject startanim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startanim.GetComponent<ChickWordManager>().playanim == 1)
        {   
            
            
            animation1();
            ballanim1.Play();
            
        
        }
        else if(startanim.GetComponent<ChickWordManager>().playanim == 2)
        {
            animation2();
            ballanim2.Play();
        }
    }
    void animation1()
    {
       
        ballanim1 = transform.DOMove(new Vector3(0, 2.5f, 0), 2.5f);
        //ballanim2 = transform.DOMove(new Vector3(0, -10, 0), 2.5f);
        
        
        
        

    }
    void animation2()
    {
       
        ballanim2 = transform.DOMove(new Vector3(3, 2.5f, 0), 2.5f);
        //ballanim2 = transform.DOMove(new Vector3(0, -10, 0), 2.5f);
        
        
        
        

    }

    
}
