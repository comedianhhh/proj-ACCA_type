//By Xiang Tianyu ���ϵ���ϵͳ
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsController : MonoBehaviour
{
    [SerializeField] float m_GhostDuration = 3;
    [SerializeField] bool IsDash = false;
    [SerializeField] bool IsGhost = false;
    [SerializeField] float dashTimer = 0;
    float ghostTimer = 0;
    public GameObject dashingSmoke;
    public GameObject normalSmoke;

    //public Material tmMat; //͸������

   // Material[] newTmMatArray;//͸����������

    void Start()
    {
       /*newTmMatArray = new Material[character.GetComponent<MeshRenderer>().materials.Length];//�����ʼ������

        //��ȡȫ������
        for (int i = 0; i < newTmMatArray.Length; i++)
        {
            newTmMatArray[i] = tmMat;
        }*/

    }

    // Update is called once per frame
    void Update()
    {
        Dash();
        Ghost();
    }

    void Dash()
    {
        if (IsDash)
        {
            dashTimer += Time.deltaTime;
            if (dashTimer >= 5)
            {
                Debug.Log("stopDashing");
                IsDash = false;
                normalSmoke.SetActive(true);
                dashingSmoke.SetActive(false);
            
            }
        }
    }

    void Ghost()
    {
        if (IsGhost)
        {
            ghostTimer += Time.deltaTime;
            if (ghostTimer >= m_GhostDuration)
            {
                IsGhost = false;
                //normalCharacter.SetActive(true);
                //ghostCharacter.SetActive(false);
            }
        }
    }
    void OnTriggerEnter(Collider collider)
    {

        if (!IsGhost && collider.tag == "Dash") // Ghost״̬�²���ʰȡ
        {
            IsDash = true;
            dashTimer = 0;
            dashingSmoke.SetActive(true);
            normalSmoke.SetActive(false);//�ı�β����ɫ
            Debug.Log("getDashing");
            Destroy(collider.gameObject);
        }


        if (collider.tag == "Ghost")
        {
            IsGhost = true;
            ghostTimer = 0;
            //GetComponent<MeshRenderer>().material.color = new Color(0, 1, 0);
            //normalCharacter.SetActive(false);
            //ghostCharacter.SetActive(true);
            // character.GetComponent<MeshRenderer>().materials = newTmMatArray;
            Destroy(collider.gameObject);
        }
    }
}
