// By Hu Jiahui

using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "VocabularyConfig", menuName = "ScriptableObject/VocabularyConfig")]
public class VocabularyConfig : ScriptableObject
{
    public string CSVResourcesPath = "VocabularyConfig";
    public VocabularyCategory Category = VocabularyCategory.Short;
    public List<string> Words = new List<string>();
    public List<string> WordsChinese = new List<string>();

    [ContextMenu("Load CSV from Resources")]
    void Load()
    {
        var text = Resources.Load<TextAsset>(CSVResourcesPath + "/" + Category.ToString());

        Words.Clear();
        WordsChinese.Clear();

        var raw = text.text;
        var lines = raw.Split('\n');
        foreach (var line in lines)
        {
            var cells = line.Split(',');

            bool isCheckingChinese = false;
            foreach (var cell in cells)
            {
                if (!isCheckingChinese)
                {
                    if (cell.Length != 0 && Regex.IsMatch(cell, @"^[a-zA-Z -]+$"))
                    {
                        Words.Add(CleanWord(cell).ToLower());
                        isCheckingChinese = true;
                    }
                }
                else
                {
                    if (cell.Length != 0 && ContainsChinese(cell))
                    {
                        WordsChinese.Add(CleanWord(cell));
                        break;
                    }
                }
            }
            if (Words.Count > WordsChinese.Count) WordsChinese.Add("");
        }

        /*
        var raw = text.text.Replace('\n', ',');
        raw = raw.Replace("  ", " ");

        var rawWords = raw.Split(',');

        List<string> words = new List<string>();
        foreach (var word in rawWords)
        {
            if (word.Length != 0 && Regex.IsMatch(word, @"^[a-zA-Z -]+$")) words.Add(word.ToLower());
        }
        Words = words;

        //text.name = "VocabularyConfig_" + CategoryName;
        */
    }

    string CleanWord(string word)
    {
        word = word.Trim();

        while (word.Split(new string[] {"  "}, System.StringSplitOptions.None).Length > 1)
            word = word.Replace("  ", " ");

        return word;
    }

    bool ContainsChinese(string word)
    {
        for (int x = 0; x < word.Length; x++)
        {
            if (char.GetUnicodeCategory(word[x]) == UnicodeCategory.OtherLetter)
            {
                return true;
            }
        }
        return false;
    }
}