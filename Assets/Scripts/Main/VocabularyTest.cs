// By Hu Jiahui

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class VocabularyTest : MonoBehaviour
{
    public Vocabulary Word = new Vocabulary();
    public TMP_Text TMPBackText;
    public TMP_Text TMPText;
    //public TextMesh TextMesh;
    //public Text UIText;

    private void Start()
    {
        Word.Randomize(VocabularyCategory.Short);
        TMPBackText.text = Word.Answer;
    }

    private void Update()
    {
        if (Word.GetInput())
        {
            TMPText.text = Word.CorrectInputs;
            if (Word.IsCorrect)
            {
                TMPText.color = Color.yellow;
            }
        }
    }
}
