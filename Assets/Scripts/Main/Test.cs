// By Hu Jiahui

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Test : MonoBehaviour
{
    Transform SphereTransform;
    BoxCollider boxCollider;

    public Vocabulary Word = new Vocabulary();

    //public float accumulatedTimer = 0; // �ۼӼ�ʱ��
    //public float offsetTimer = 0; // ��ֵ��ʱ��
    //public bool isScaling = false; // Invoke �ӳٵ��÷���

    void Start()
    {
        // �����������������ֶ�
        boxCollider = GetComponent<BoxCollider>();

        // �����Ӷ������ϵ����
        //SphereTransform = GetComponentInChildren<Transform>();
        //SphereTransform = transform.Find("Sphere");
        //SphereTransform = transform.GetChild(0);

        // ����ȫ�����е����
        //FindObjectOfType<GameManager>();

        //Debug.Log("The user's name is " + GameManager.Instance.UserName + ".");

        // ��ֵ��ʱ��
        //offsetTimer = Time.time;

        // Invoke �ӳٵ��÷���
        //Invoke("InvokeScaling", 5);

        // ����Э��
        //StartCoroutine(IEnableScaling());

        // Dotweenѭ���ƶ���̬Ч��
        transform.DOMoveY(5, 1).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }

    void Update()
    {
        Word.GetInput();

        // �ۼӼ�ʱ��
        /*
        accumulatedTimer += Time.deltaTime;
        if (accumulatedTimer >= 5)
        {
            transform.localScale += Vector3.one * Time.deltaTime;
        }
        */

        // ��ֵ��ʱ��
        /*
        if (Time.time - offsetTimer >= 5)
        {
            transform.localScale += Vector3.one * Time.deltaTime;
        }
        */

        // Invoke �ӳٵ��÷���

        /*if (isScaling)
        {
            transform.localScale += Vector3.one * Time.deltaTime;
        }*/

    }

    // Invoke �ӳٵ��÷���
    /*
    void InvokeScaling()
    {
        isScaling = true;
    }
    */


    // Э�̣��ȴ�5�룬���зŴ�
    /*
    IEnumerator IEnableScaling()
    {
        yield return new WaitForSeconds(5);
        while (true)
        {
            transform.localScale += Vector3.one * Time.deltaTime;
            yield return null;
        }
    }
    */
}
