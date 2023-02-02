// By Hu Jiahui

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] Image m_Blackscreen;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else DestroyImmediate(gameObject);


        SceneManager.sceneLoaded += (scene, mode) => ResetBlackscreen();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void ResetBlackscreen()
    {
        m_Blackscreen.DOFade(0, 1);
    }

    public void LoadScene(string sceneName)
    {
        m_Blackscreen.DOFade(1, 1).OnComplete(() => SceneManager.LoadScene(sceneName));
    }
}

public enum LevelType { None, Chicken, Jepack, Fighter, Dog }
