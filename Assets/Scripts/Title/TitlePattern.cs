using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitlePattern : MonoBehaviour
{
    public bool IsGold = false;
    [SerializeField] Sprite m_PatternSprite;
    [SerializeField] Sprite m_PatternSpriteGold;

    // Start is called before the first frame update
    void Start()
    {
        var images = GetComponentsInChildren<Image>();
        foreach (var image in images)
            image.sprite = IsGold ? m_PatternSpriteGold : m_PatternSprite;
    }
}
