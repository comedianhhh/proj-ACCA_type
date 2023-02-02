using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChickScoreDataManager : MonoBehaviour
{

    public Text inGameScore;
    public TMP_Text gameEndScoreText;
    public TMP_Text highestScoreText;

   
    public GameObject WordManager;

    public List<int> charactorPirces;
    public List<int> BGPirces;

    [Header("Data")]
    public int highestScore;
    /*public int gold;
    public List<bool> bgUnlock;
    public List<bool> charactorUnlock;
    public List<int> record;
*/
    //record format
    //  ||
    // _||_
    // \  /
    //  \/
    //charactorUnlock*3(0false or 1true)-bgUnlock*5(0false or 1true)-gold*99999-highestScore*99999
    // 
    //  XXX-XXXXX-XXXXX-XXXXX
    //  3-5-5-5
    //  18
    void Update()
    {
        
       
    }

    public void LoadRecord()
    {
        this.GetComponent<SaveManager>().Load();
        highestScore = this.GetComponent<SaveManager>().Data.SaveLevelDatas[1].Record;
        ChangeHighestScore();
    }
    [ContextMenu("TestSaveRecord")]
    public void SaveRecord()
    {
        /* this.GetComponent<SaveManager>().Data.SaveLevelDatas[1].Record = 0;
         for (int i = 0; i < record.Count; i++)
         {
             long test = (long)(record[i] * Mathf.Pow(10f, record.Count - i));
             this.GetComponent<SaveManager>().Data.SaveLevelDatas[1].Record += (int)(record[i] * Mathf.Pow(10f,record.Count - i));


             Debug.Log("SaveRecord = "+test);
         }

         this.GetComponent<SaveManager>().Save();*/
        LoadRecord();
        this.GetComponent<SaveManager>().Data.SaveLevelDatas[1].Record = highestScore;
        this.GetComponent<SaveManager>().Save();

    }

    public void GameOver()
    {
        

        gameEndScoreText.text = WordManager.GetComponent<ChickWordManager>().score.ToString();
        highestScoreText.text = highestScore.ToString();
        //gold = gold+WordManager.GetComponent<ChickWordManager>().score;//目前是得多少分就有多少金币
        ChangeHighestScore();
        SaveRecord();
    }



    void ChangeHighestScore()
    {
        if (highestScore < WordManager.GetComponent<ChickWordManager>().score)
        {
            highestScore = WordManager.GetComponent<ChickWordManager>().score;
            
        }
    }
}
