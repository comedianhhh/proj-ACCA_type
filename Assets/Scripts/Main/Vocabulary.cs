// By Hu Jiahui

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Vocabulary
{
    public string Answer = "vocabulary";
    public string AnswerChinese = "�ʻ�";
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
        // û�����룬����
        if (Input.inputString.Length == 0) return false;

        // ��õ�ǰ������ĸ
        char input = Input.inputString.ToLower()[0];

        // �ж��Ƿ�����Ч���루����ĸ�������С��˸�֮�⣩
        bool hasInput = input != '\b' && input != '\r' && input != '\n';

        // �ж��Ƿ��ǵ�һ�������ж�������û����ɵ�������
        if (lastInputTime != Time.time && !IsCorrect)
        {
            // �����ǰ������ĸ��Ŀ��������ĸһ��
            if (Answer[nextInputIndex] == input && !HasMistake)//Ҫ��֮ǰû�д��� ��&&!HasMistake��by weiqi
            {
                // ���桰��ȷ�����롱
                CorrectInputs += input;
                // Ŀ��������ĸλ�ú���
                nextInputIndex++;
            }
            else // �����һ�£����������
            { 
                HasMistake = true;
            }
            
            // ��¼��������ʱ�䣨�ж��Ƿ����״��ж���
            lastInputTime = Time.time;

            // ���桰���е����롱
            AllInputs += input;
        }

        // �ж��Ƿ��������
        IsCorrect = CorrectInputs == Answer;

        return hasInput;
    }
}

public enum VocabularyCategory { Any, Short, Medium, Long }
