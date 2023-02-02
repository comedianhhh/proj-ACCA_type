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

    //public float accumulatedTimer = 0; // 累加计时器
    //public float offsetTimer = 0; // 差值计时器
    //public bool isScaling = false; // Invoke 延迟调用方法

    void Start()
    {
        // 将自身的组件储存至字段
        boxCollider = GetComponent<BoxCollider>();

        // 查找子对象身上的组件
        //SphereTransform = GetComponentInChildren<Transform>();
        //SphereTransform = transform.Find("Sphere");
        //SphereTransform = transform.GetChild(0);

        // 查找全场景中的组件
        //FindObjectOfType<GameManager>();

        //Debug.Log("The user's name is " + GameManager.Instance.UserName + ".");

        // 差值计时器
        //offsetTimer = Time.time;

        // Invoke 延迟调用方法
        //Invoke("InvokeScaling", 5);

        // 调用协程
        //StartCoroutine(IEnableScaling());

        // Dotween循环移动动态效果
        transform.DOMoveY(5, 1).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }

    void Update()
    {
        Word.GetInput();

        // 累加计时器
        /*
        accumulatedTimer += Time.deltaTime;
        if (accumulatedTimer >= 5)
        {
            transform.localScale += Vector3.one * Time.deltaTime;
        }
        */

        // 差值计时器
        /*
        if (Time.time - offsetTimer >= 5)
        {
            transform.localScale += Vector3.one * Time.deltaTime;
        }
        */

        // Invoke 延迟调用方法

        /*if (isScaling)
        {
            transform.localScale += Vector3.one * Time.deltaTime;
        }*/

    }

    // Invoke 延迟调用方法
    /*
    void InvokeScaling()
    {
        isScaling = true;
    }
    */


    // 协程：等待5秒，进行放大
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
