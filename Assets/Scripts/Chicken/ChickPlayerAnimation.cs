// By Siqi Qin

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Spine;
using Spine.Unity;

public class ChickPlayerAnimation : MonoBehaviour
{
    public SkeletonAnimation player_anim;
    bool GetBall = false;
    bool Idle = false;

    //bool skin = false;

    // Start is called before the first frame update
    void Start()
    {
        player_anim = GetComponent<SkeletonAnimation>();

        player_anim.AnimationState.Complete += completeEvent;

        player_anim.AnimationState.SetAnimation(0, "idle", true);
    }

    // Update is called once per frame
    void Update()
    {
        /*
         if(GetBall)
        {
        GetBall = true;
        player_anim.AnimationState.SetAnimation(0, "catch", false);
        player_anim.AnimationState.SetAnimation(0, "get_ball", true);
        }
         */

        if (Input.GetKeyDown(KeyCode.Return)&& Idle==false)
        {
            Idle = true;
            player_anim.AnimationState.SetAnimation(0, "throw", false);
        }
    }

    public void completeEvent(Spine.TrackEntry trackEntry)
    {
        if(Idle)
        {
            Idle = false;
            player_anim.AnimationState.SetAnimation(0, "idle", true);
        }
    }
}
