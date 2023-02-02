using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "ChickBGSkin", menuName = "ScriptableObject/ChickBGSkin")]
public class ChickBGSkin : ScriptableObject
{
    public Sprite sprite;
    public string name;
}
