using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChickChangeSkinOnClick : MonoBehaviour
{
    public GameObject BG;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void BGOnClick()
    {
        BG = GameObject.Find("/Canvas/SkinManager").gameObject.GetComponent<ChickSkinManager>().Background;


        if (BG != null)
        {
            BG.GetComponent<SpriteRenderer>().sprite = this.transform.GetChild(0).GetComponent<Image>().sprite;
            
        }


    }

    public void SkinOnClick()
    {
        


        if (GameObject.Find("/Canvas/SkinManager").gameObject.GetComponent<ChickSkinManager>().charactorName != null)
        {
            GameObject.Find("/Canvas/SkinManager").gameObject.GetComponent<ChickSkinManager>().charactorName = this.transform.GetChild(1).GetComponent<TMP_Text>().text;

        }


    }
}
