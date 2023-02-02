using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Spine;
using Spine.Unity;

public class ChickAnimationControl : MonoBehaviour
{

    public Animator anim;
    public Animator Judge_anim;
    public Animator player_anim;
    public string charactorName;
    public Animator fighter;
    public Animator vegetable;
    public Animator pepper;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (charactorName == "Fighter")
        {
            player_anim = fighter;
        }else if(charactorName == "Vegetable")
        {
            player_anim = vegetable;

        }
        else if (charactorName == "Pepper")
        {
            player_anim = pepper;

        }

    }

    void SetShootFalse()
    {
        anim.SetBool("shoot", false);
    }

    void SetGoalFalse()
    {
        anim.SetBool("goal", false);
    }

    void SetThrowFalse()
    {
        anim.SetBool("throw", false);
    }

    void SetCatchFalse()
    {
        anim.SetBool("catch", false);
    }

    void SetCatchedFalse()
    {
        anim.SetBool("catched", false);
    }

    void PlayCatch()
    {
        player_anim.Play("catch");
    }

    void PlayThrow()
    {
        player_anim.Play("throw");
    }

    void PlayJudgeThrow()
    {
        Judge_anim.Play("Throw_Ball");
    }


    void SetSkipShootFalse()
    {
        anim.SetBool("skipShoot", false);
    }

   
}
