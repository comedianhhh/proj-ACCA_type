// By Hu Jiahui

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Vocabulary
{
    public string Answer = "vocabulary";
    public string AnswerChinese = "词汇";
    public string CorrectInputs = "";
    public string AllInputs = "";

    public bool IsCorrect = false;
    public bool HasMistake = false; 

    int nextInputIndex = 0;
    float lastInputTime = 0;

    public Vocabulary()
    {
        Answer = Answer.ToLower();
    }

    public Vocabulary(string answer)
    {
        Answer = answer;
        Answer = Answer.ToLower();
    }

    public void Randomize(VocabularyCategory category)
    {
        var configs = Resources.LoadAll<VocabularyConfig>("VocabularyConfig");
        var config = Array.Find(configs, config => config.Category == category);
        var words = config.Words;
        int randomIndex = UnityEngine.Random.Range(0, words.Count);
        Answer = words[randomIndex];
        AnswerChinese = config.WordsChinese[randomIndex];
    }

    public bool GetInput()
    {
        // 没有输入，跳过
        if (Input.inputString.Length == 0) return false;

        // 获得当前输入字母
        char input = Input.inputString.ToLower()[0];

        // 判断是否是有效输入（仅字母，除换行、退格之外）
        bool hasInput = input != '\b' && input != '\r' && input != '\n';

        // 判断是否是第一次输入判定，并且没有完成单词输入
        if (lastInputTime != Time.time && !IsCorrect)
        {
            // 如果当前输入字母和目标输入字母一致
            if (Answer[nextInputIndex] == input && !HasMistake)//要求之前没有错误 （&&!HasMistake）by weiqi
            {
                // 保存“正确的输入”
                CorrectInputs += input;
                // 目标输入字母位置后移
                nextInputIndex++;
            }
            else // 如果不一致，有输入错误
            { 
                HasMistake = true;
            }
            
            // 记录本次输入时间（判断是否是首次判定）
            lastInputTime = Time.time;

            // 保存“所有的输入”
            AllInputs += input;
        }

        // 判断是否完成输入
        IsCorrect = CorrectInputs == Answer;

        return hasInput;
    }
}

public enum VocabularyCategory { Any, Short, Medium, Long }
