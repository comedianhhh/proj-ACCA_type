//By NianZhi
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;

public class Decelerate : MonoBehaviour
{
    // Start is called before the first frame update
    public float DebuffSpeed = 5;
    public float duration = 5;
    public float StopTime = 2;
    public Transform Point;
    public Transform Point_2;
    public bool Isright;
    public bool IsUp;
    public bool Isbridge;

    void Start()
    {
        //print(Isright);
        
    }

    public void isbgde()
    {
        if (GetComponentInParent<DelayZone>().ZoneType == DelayZone.Type.Bridge)
        {
            Isbridge = true;
        }
        else Isbridge=false;

    }

    private void OnTriggerEnter(Collider other)
    {
        Animator anim=other.GetComponentInChildren<Animator>();
        if (other.tag == "Player")
        {
            Debug.Log("◊≤…œ¡À");
            StopAllCoroutines();
            anim.SetBool("IsKnocked", true);
            anim.SetBool("IsFlying", false);
            StartCoroutine(StopFunc());
        }
    }



    IEnumerator StopFunc()
    {


        yield return new WaitForSeconds(StopTime);
        Debug.Log("Stop");
        Tween tween=Player.Instance.transform.DOMove(Point.position, 1F);
        if (!Isbridge)
        {
            if (Isright)
            {
                Player.Instance.StarTurnR();
            }

            else if (Isright != true)
            {
                Player.Instance.StarTurnL();
            }
        }


        Player.Instance.SetSpeed(DebuffSpeed);
        Player.Instance.Invoke("RestoreSpeed", duration);
    }

}
