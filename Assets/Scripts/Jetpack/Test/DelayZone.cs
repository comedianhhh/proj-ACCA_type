//by NianZhi

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class DelayZone : MonoBehaviour
{
    public enum Type { Block, Turn, TCross , Bridge }

    public Type ZoneType = Type.Turn;


    public Transform Point;
    public Transform Point_2;
    public bool HasPassed = false;
    public bool IsRight;
    public bool IsGoUp;
    public Vocabulary word;

    public bool isdash=false;
    public bool Ispass=false;

    [Header("T Cross")]
    public bool IsTCross = false;
    public Vocabulary WordLeft = new Vocabulary();
    public Vocabulary WordRight = new Vocabulary();


    void Start()
    {
        word = new Vocabulary();
        word.Randomize(VocabularyCategory.Short);
    }

}
