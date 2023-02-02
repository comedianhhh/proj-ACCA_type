using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextSizer : MonoBehaviour
{
    public TMP_Text ConnectedText;
    TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.fontSize = ConnectedText.fontSize;
    }
}
