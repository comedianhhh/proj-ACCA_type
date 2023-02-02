//By Weiqi Liu and Hongyi Bai
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ChickWordManager : MonoBehaviour
{
    [Header("Vocabulary")]
    public VocabularyConfig easyWord;
    public VocabularyConfig normalWord;
    public VocabularyConfig hardWord;
    public int mode;//easy0,normal,hard2
    [Header("Word")]
    public Vocabulary Word;
    public TMP_Text TMPBackText;
    public TMP_Text TMPBackTextOnBall;
    public Text WordTextChinese;
    public Text WordTextChineseOnBall;
    public TMP_Text TMPText;
    public TMP_Text allInput;

    [Header("Score")]
    public Text scoreText;
    public int score;
    public TMP_Text getScoreText;

    [Header("Timer")]
    public Text timerSecText;
    public Text timerMinText;
    public TMP_Text paulseTimerSecText;
    public TMP_Text paulseTimerMinText;


    public int inputTimeMin;
    public int inputTimeSec;
    

    float timerMin;
    float timerSec;


    [Header("Combo")]
    public Slider combo;

    [Header("Animation")]
    public int playanim;
    public Animator anim;
    public Animator cameraAnim;
    public Animator judgeAnim;
    public Animator GetScoreTextAnim;
    public Animator ultAnim;
    public Animator ultEffectAnim;

    [Header("UI")]
    public GameObject lifeUI;
    public GameObject lifeBarPrefab;

    public int life;
    bool pause;


    public Sprite vegetableIcon;
    public Sprite pepperIcon;
    public Sprite fighterIcon;


    public GameObject BGM;
    public GameObject BGM1;
    public GameObject playerIcon;

    public GameObject titlePanel;
    public GameObject menuPanel;
    public GameObject inGamePanel;
    public GameObject inGamePanelWorld;
    public GameObject EffectZXC;
    public GameObject pausePanel;
    public GameObject changeSkinPanel;
    public GameObject gameOverPanel;
    public GameObject settingPanel;
    public GameObject tutorialPanel;
    public GameObject customPanel;

    public GameObject chickScoreDataManager;

    public TMP_Text tutorialTimerText;
    public float tutorialTimer;
    
    public bool tutorial;
    public GameObject menu;
    public GameObject inGame;

    [Header("Mech")]
    public bool shootBall;
    public float ultTimer;
    public bool progressiveDifficulty;
    [Header("Player")]
    public string playerName;
    [Header("Custom")]
    public TMP_Text lifeNum;
    public Slider lifeNumSlider;
    public TMP_Text timeNum;
    public Slider timeNumSlider;
    public Toggle progressiveDifficultyToggle;
    public TMP_Dropdown wordDifficultyDropdown;




    void Start()
    {
        TitlePage();
        combo.value = 0f;
        tutorialTimer = 5f;
        InitializeLifeBar();
    }

    public void Initialization()
    {
        InitializeLifeBar();
        combo.value = 0f;
        cameraAnim.SetBool("title", false);
        cameraAnim.SetBool("gameOver", false);
        cameraAnim.SetBool("shootBall", false);
        cameraAnim.Play("NormalMode");
        ultAnim.Play("NormalModeUlt");
        score = 0;
        combo.value = 0f;
        ultTimer = 0f;
    }


    public void MenuPage()
    {
        cameraAnim.SetBool("title", false);
        cameraAnim.SetBool("gameOver", false);
        cameraAnim.SetBool("shootBall", false);
        cameraAnim.Play("NormalMode");
        titlePanel.gameObject.SetActive(false);
        menu.gameObject.SetActive(true);
        inGame.gameObject.SetActive(false);
        menuPanel.gameObject.SetActive(true);
        inGamePanel.gameObject.SetActive(false);
        inGamePanelWorld.gameObject.SetActive(false);
        pausePanel.gameObject.SetActive(false);
        changeSkinPanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(false);
        EffectZXC.gameObject.SetActive(false);
        settingPanel.gameObject.SetActive(false);
        tutorialPanel.gameObject.SetActive(false);
        customPanel.gameObject.SetActive(false);
        BGM.gameObject.SetActive(true);
        BGM1.gameObject.SetActive(false);

    }

    public void GameStartPage()
    {
        Initialization();
        chickScoreDataManager.GetComponent<ChickScoreDataManager>().LoadRecord();

        menu.gameObject.SetActive(false);
        titlePanel.gameObject.SetActive(false);
        inGame.gameObject.SetActive(true);
        titlePanel.gameObject.SetActive(false);
        menuPanel.gameObject.SetActive(false);
        inGamePanel.gameObject.SetActive(true);
        pausePanel.gameObject.SetActive(false);
        changeSkinPanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(false);
        
        scoreText.text = score.ToString();
        EffectZXC.gameObject.SetActive(true);
        settingPanel.gameObject.SetActive(false);
        tutorialPanel.gameObject.SetActive(false);
        customPanel.gameObject.SetActive(false);
        BGM.gameObject.SetActive(false);
        BGM1.gameObject.SetActive(true);
    }

    public void PausePage()
    {
        menu.gameObject.SetActive(false);
        titlePanel.gameObject.SetActive(false);

        inGame.gameObject.SetActive(false);
        titlePanel.gameObject.SetActive(false);
        menuPanel.gameObject.SetActive(false);
        inGamePanel.gameObject.SetActive(false);
        inGamePanelWorld.gameObject.SetActive(false);
        pausePanel.gameObject.SetActive(true);
        changeSkinPanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(false);
        EffectZXC.gameObject.SetActive(false);
        settingPanel.gameObject.SetActive(false);
        tutorialPanel.gameObject.SetActive(false);
        customPanel.gameObject.SetActive(false);
        BGM.gameObject.SetActive(false);
        BGM1.gameObject.SetActive(false);

    }

    public void ChangeSkinPage()
    {
        titlePanel.gameObject.SetActive(false);
        menu.gameObject.SetActive(true);
        titlePanel.gameObject.SetActive(false);

        inGame.gameObject.SetActive(false);
        menuPanel.gameObject.SetActive(false);
        inGamePanel.gameObject.SetActive(false);
        inGamePanelWorld.gameObject.SetActive(false);
        pausePanel.gameObject.SetActive(false);
        changeSkinPanel.gameObject.SetActive(true);
        gameOverPanel.gameObject.SetActive(false);
        EffectZXC.gameObject.SetActive(false);
        settingPanel.gameObject.SetActive(false);
        tutorialPanel.gameObject.SetActive(false);
        customPanel.gameObject.SetActive(false);

    }

    public void Continue()
    {
        titlePanel.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
        titlePanel.gameObject.SetActive(false);

        inGame.gameObject.SetActive(true);
        menuPanel.gameObject.SetActive(false);
        inGamePanel.gameObject.SetActive(true);
        inGamePanelWorld.gameObject.SetActive(true);
        pausePanel.gameObject.SetActive(false);
        changeSkinPanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(false);
        EffectZXC.gameObject.SetActive(true);
        pause =false;
        settingPanel.gameObject.SetActive(false);
        tutorialPanel.gameObject.SetActive(false);
        customPanel.gameObject.SetActive(false);
        BGM.gameObject.SetActive(false);
        BGM1.gameObject.SetActive(true);

    }

    void GameOverPage()
    {
        chickScoreDataManager.GetComponent<ChickScoreDataManager>().GameOver();
        titlePanel.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
        titlePanel.gameObject.SetActive(false);

        inGame.gameObject.SetActive(false);
        menuPanel.gameObject.SetActive(false);
        inGamePanel.gameObject.SetActive(false);
        inGamePanelWorld.gameObject.SetActive(false);
        pausePanel.gameObject.SetActive(false);
        changeSkinPanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(true);
        EffectZXC.gameObject.SetActive(false);
        settingPanel.gameObject.SetActive(false);
        tutorialPanel.gameObject.SetActive(false);
        customPanel.gameObject.SetActive(false);

    }

    public void TitlePage()
    {
        cameraAnim.SetBool("title", true);
        settingPanel.gameObject.SetActive(false);
        menu.gameObject.SetActive(false);
        titlePanel.gameObject.SetActive(true);
        inGame.gameObject.SetActive(false);
        menuPanel.gameObject.SetActive(false);
        inGamePanel.gameObject.SetActive(false);
        inGamePanelWorld.gameObject.SetActive(false);
        pausePanel.gameObject.SetActive(false);
        changeSkinPanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(false);
        EffectZXC.gameObject.SetActive(false);
        tutorialPanel.gameObject.SetActive(false);
        customPanel.gameObject.SetActive(false);
        BGM.gameObject.SetActive(true);
        BGM1.gameObject.SetActive(false);

    }

    public void SettingPage()
    {
        menu.gameObject.SetActive(false);
        titlePanel.gameObject.SetActive(false);
        settingPanel.gameObject.SetActive(true);
        inGame.gameObject.SetActive(false);
        titlePanel.gameObject.SetActive(false);
        menuPanel.gameObject.SetActive(false);
        inGamePanel.gameObject.SetActive(false);
        pausePanel.gameObject.SetActive(false);
        changeSkinPanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(false);
        EffectZXC.gameObject.SetActive(true);
        tutorialPanel.gameObject.SetActive(false);
        customPanel.gameObject.SetActive(false);

    }
    public void TutorialPage()
    {
        cameraAnim.SetBool("title", false);
        menu.gameObject.SetActive(false);
        titlePanel.gameObject.SetActive(false);
        settingPanel.gameObject.SetActive(false);
        inGame.gameObject.SetActive(false);
        titlePanel.gameObject.SetActive(false);
        menuPanel.gameObject.SetActive(false);
        inGamePanel.gameObject.SetActive(false);
        pausePanel.gameObject.SetActive(false);
        changeSkinPanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(false);
        EffectZXC.gameObject.SetActive(false);
        tutorialPanel.gameObject.SetActive(true);
        customPanel.gameObject.SetActive(false);

    }

    public void CustomPage()
    {
       
        menu.gameObject.SetActive(false);
        titlePanel.gameObject.SetActive(false);
        settingPanel.gameObject.SetActive(false);
        inGame.gameObject.SetActive(false);
        titlePanel.gameObject.SetActive(false);
        menuPanel.gameObject.SetActive(false);
        inGamePanel.gameObject.SetActive(false);
        pausePanel.gameObject.SetActive(false);
        changeSkinPanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(false);
        EffectZXC.gameObject.SetActive(false);
        tutorialPanel.gameObject.SetActive(false);
        customPanel.gameObject.SetActive(true);
    }

    void ESCPress()
    {
        if (menuPanel.gameObject.active && Input.GetKeyDown(KeyCode.Escape))
        {
            TitlePage();
        }
        if (changeSkinPanel.gameObject.active && Input.GetKeyDown(KeyCode.Escape))
        {
            MenuPage();
        }
        


    }

    void UltControl()
    {
        if (combo.value >= 50f)//大招开关
        {
            if (playerName == "Vegetable")//根据不同的角色大招时间可能不同
            {
                ultTimer = 60;//大招时间
                combo.value = 0f;
                ultAnim.Play("VegetableUlt");
            }
            else if (playerName == "Fighter")
            {
                ultTimer = 60;//大招时间
                combo.value = 0f;
                ultAnim.Play("FighterUlt");
            }
            else if (playerName == "Pepper")
            {
                ultTimer = 60;//大招时间
                combo.value = 0f;
                ultAnim.Play("PepperUlt");
            }
        }

        if (ultTimer >= 0)//大招计时器
        {
            ultTimer -= Time.deltaTime;
            if (playerName == "Vegetable" && ultTimer <= 58)//大招时间-2f
            {
                ultEffectAnim.Play("VegetableUltEffect");
            }
            if (playerName == "Fighter" && ultTimer <= 58)//大招时间-2f
            {
                ultEffectAnim.Play("FighterUltEffect");
            }
            if (playerName == "Pepper" && ultTimer <= 58)//大招时间-2f
            {
                ultEffectAnim.Play("PepperUltEffect");
            }
        }
        else
        {
            ultEffectAnim.Play("NoneEffect");
        }
    }

    void ModeControl()
    {
        if (shootBall)
        {
            cameraAnim.SetBool("shootBall", true);//进入投球模式

            TMPBackText.gameObject.SetActive(false);
            WordTextChinese.gameObject.SetActive(false);

            TMPBackTextOnBall.gameObject.SetActive(true);
            WordTextChineseOnBall.gameObject.SetActive(true);
        }
        else
        {
            cameraAnim.SetBool("shootBall", false);

            TMPBackText.gameObject.SetActive(true);
            WordTextChinese.gameObject.SetActive(true);

            TMPBackTextOnBall.gameObject.SetActive(false);
            WordTextChineseOnBall.gameObject.SetActive(false);
        }

        if (Word.GetInput())//输入
        {
            TMPText.text = Word.CorrectInputs;
            allInput.text = Word.AllInputs;
        }



        if (Input.GetKeyDown(KeyCode.Return))//use enter to submit answer
        {
            if (shootBall)
            {
                ShootBall();//投球模式
            }
            else
            {

                CatchBall();//接球模式
            }
        }
    }


    void Update()
    {
        if(titlePanel.active && Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Escape) && !tutorial)
        {
            TutorialPage();
           
        }else if (titlePanel.active && Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Escape) && tutorial == true)
        {
            MenuPage();


        }



        if (tutorialPanel.active)
        {
            
            if (tutorialTimer <= 0f)
            {
                tutorialTimerText.text = null;
                tutorialTimerText.transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                tutorialTimerText.text = ((int)tutorialTimer).ToString();
                tutorialTimer -= Time.deltaTime;
            }
            if (Input.anyKeyDown&& tutorialTimer<=0f)
                MenuPage();
            
        }

        ESCPress();

        if (!pause)
        {

            UltControl();

            ModeControl();



            JudgeAnimControl();

            SkipWord();

            
            MistakeControl();
            
            lifeUIControl();
            TimeManager();
        }

        if (inGame.gameObject.active == true)
        {
            InstatiateLifeBar();
            PausePageControl();
            IconControl();

        }
        else
        {
            DeleteLifeBar();
        }
            
        if(customPanel.gameObject.active == true)
        {
            CustomUpdate();
        }


    }

    void CustomUpdate()
    {
        lifeNum.text = ((int)(lifeNumSlider.value * 15)).ToString();
        timeNum.text = ((int)(timeNumSlider.value * 15)).ToString();
        if (progressiveDifficultyToggle.isOn)
        {
            progressiveDifficulty = true;
            wordDifficultyDropdown.transform.gameObject.SetActive(false);
        }
        else
        {
            progressiveDifficulty = false;
            wordDifficultyDropdown.transform.gameObject.SetActive(true);
        }
        mode = wordDifficultyDropdown.value;
        
    }

    void IconControl()
    {
        if (playerName == "Vegetable")
        {
            playerIcon.GetComponent<Image>().sprite = vegetableIcon;
        }else if (playerName == "Fighter")
        {
            playerIcon.GetComponent<Image>().sprite = fighterIcon;
        }
        else if (playerName == "Pepper")
        {
            playerIcon.GetComponent<Image>().sprite = pepperIcon;
        }


    }


    void JudgeAnimControl()
    {
        if (Word.HasMistake)
        {
            judgeAnim.Play("Taunt");
           
        }
       
    }

    

    void AnimThrow()
    {
        anim.SetBool("shoot", true);
        
    }


    void CatchBall()
    {
            TMPBackTextOnBall.transform.parent.GetChild(0).gameObject.SetActive(false);//关掉之前投球模式的背景

        //judgeAnim.Play("Throw_Ball");
        if (Word.IsCorrect && !Word.HasMistake)
        {
            
            anim.SetBool("catch", true);
            anim.SetBool("catched", true);
            ChangeToShootMode();
            //Debug.Log("CurrectWord");
            scoreText.text = score.ToString();
            TMPText.color = Color.yellow;
            /*anim.SetBool("shoot", true);
            anim.SetBool("goal", true);*/
            TMPText.text = null;

            TMPText.color = new Color(90f / 255f, 90f / 255f, 90f / 255f);
            allInput.text = null;
            Invoke("AssignWord", 2.5f);

            /*score += 10;//score + 1*/

            /*if (combo.value <= 100f)//increase combo value
            {
                combo.value += 10f;
            }*/

            /*anim.SetBool("catched", true);
            anim.SetBool("catch", true);*/

            
           

        }
        else//接球失败
        {
            
            anim.SetBool("catch", true);
            /*anim.SetBool("shoot", true);
            anim.SetBool("goal", false);*/
            Invoke("AssignWord", 0.5f);

            if (playerName == "Vegetable" && ultTimer >= 0)
            {
                //在vegetable大招时间内
            }
            else
            {
                combo.value -= 10f;
                life -= 1;
            }
            
            

           
            /*anim.SetBool("catch", true);*/
        }
       

    }
    void ShootBall()
    {
        ChangeToCatchMode();
        if (Word.IsCorrect && !Word.HasMistake)
        {
            if (mode == 0)
            {
                score += 5;
                getScoreText.text = "+5";
            }
            else if (mode == 1)
            {
                score += 10;
                getScoreText.text = "+510";

            }
            else
            {
                score += 15;
                getScoreText.text = "+15";

            }
            scoreText.text = score.ToString();
            //Debug.Log("CurrectWord");

            TMPText.color = Color.yellow;
            
            anim.SetBool("goal", true);
            Invoke("AssignWord", 1.2f);


            
           

            if (combo.value <= 50f)//increase combo value
            {
                combo.value += 10f;
            }

            GetScoreTextAnim.Play("GetScore");

        }
        else
        {

            
            anim.SetBool("goal", false);
            Invoke("AssignWord", 1.2f);
            if (playerName == "Vegetable" && ultTimer >= 0)
            {
                //在vegetable大招时间内
            }else if(playerName == "Pepper" && ultTimer >= 0)
            {
                Debug.Log("PepperUlt");
                life -= 1;
                if (mode == 0)
                {
                    score += 2;
                    getScoreText.text = "+2";

                }
                else if (mode == 1)
                {
                    score += 5;
                    getScoreText.text = "+5";

                }
                else
                {
                    score += 7;
                    getScoreText.text = "+7";

                }
                scoreText.text = score.ToString();
                combo.value -= 10f;
                GetScoreTextAnim.Play("GetScore");
            }
            else
            {
                combo.value -= 10f;
                life -= 1;
            }
            
        }
        Invoke("AnimThrow", 0.5f);
    }

    void ChangeToCatchMode()
    {
        shootBall = false;//重置到接球模式
        /*cameraAnim.SetBool("shootBall", false);
        TMPBackText.gameObject.SetActive(true);
        TMPBackTextOnBall.gameObject.SetActive(false);*/
    }

    void ChangeToShootMode()
    {
        shootBall = true;
        /*cameraAnim.SetBool("shootBall", true);//进入投球模式
        TMPBackText.gameObject.SetActive(false);
        TMPBackTextOnBall.gameObject.SetActive(true);*/
    }


    void SkipWord()
    {
        if (Input.GetKeyDown(KeyCode.Tab))//skip current word
        {

            if (shootBall)
            {
                anim.SetBool("skipShoot", true);
                ChangeToCatchMode();
                combo.value -= 10f;
                Invoke("AssignWord", 0.85f);
            }
            else
            {
                combo.value -= 10f;
                AssignWord();
            }
            

            
        }
    }


    void MistakeControl()
    {
        if (Input.GetKey(KeyCode.Backspace) && Word.HasMistake)//if hasmistake press backspace to delete the wrong word
        {
            judgeAnim.Play("Idle");
            Word.AllInputs = Word.CorrectInputs;
            allInput.text = Word.AllInputs;
            Word.HasMistake = false;
        }
        if (Word.HasMistake)//if hasmistake, show the wrong word in red
        {
            allInput.gameObject.SetActive(true);
        }
        else
        {
            allInput.gameObject.SetActive(false);
        }
    }

    void PausePageControl()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
        }
        if (pause == true)
        {
            PausePage();
        }
        else
        {
            Continue();
        }
    }

    public void CustomModeStart()
    {
       

        inputTimeMin = (int)(timeNumSlider.value*15f);
        

        timerMin = inputTimeMin;
        timerSec = inputTimeSec;
        ChangeToCatchMode();
        TMPBackTextOnBall.fontSize = 9;
        TMPBackText.fontSize = 15;
        TMPText.fontSize = 15;
        allInput.fontSize = 15;
        
        GameStartPage();
        mode = 0;
        AssignWord();


        if (playerName == "Pepper")
        {
            life = life = (int)(lifeNumSlider.value * 15f+5);
        }
        else
        {
            life = (int)(lifeNumSlider.value * 15f);
        }

        combo.value = 0f;//initialize combovalue
        pause = false;



        scoreText.text = score.ToString();//initialize timer
    }


    public void OneMinMode()
    {
        progressiveDifficulty = true;

        inputTimeMin = 1;

        timerMin = inputTimeMin;
        timerSec = inputTimeSec;
        ChangeToCatchMode();
        TMPBackTextOnBall.fontSize = 9;
        TMPBackText.fontSize = 15;
        TMPText.fontSize = 15;
        allInput.fontSize = 15;
        
        GameStartPage();
        mode = 0;
        AssignWord();


        if (playerName == "Pepper")
        {
            life = 8;
        }
        else
        {
            life = 3;
        }

        combo.value = 0f;//initialize combovalue
        pause = false;

        

        scoreText.text = score.ToString();//initialize timer
    }

    public void FiveMinMode()
    {
        progressiveDifficulty = true;
        inputTimeMin = 5;
        inputTimeSec = 0;
        timerMin = inputTimeMin;
        timerSec = inputTimeSec;

        ChangeToCatchMode();
        TMPBackTextOnBall.fontSize = 9;
        TMPBackText.fontSize = 15;
        TMPText.fontSize = 15;
        allInput.fontSize = 15;
        
        GameStartPage();
        mode = 0;
        AssignWord();


        if (playerName == "Pepper")
        {
            life = 8;
        }
        else
        {
            life = 3;
        }

        combo.value = 0f;//initialize combovalue
        pause = false;

        
        scoreText.text = score.ToString();//initialize timer
    }
    public void TenMinMode()
    {
        progressiveDifficulty = true;

        inputTimeMin = 10;
        inputTimeSec = 0;
        timerMin = inputTimeMin;
        timerSec = inputTimeSec;
        ChangeToCatchMode();
        TMPBackTextOnBall.fontSize = 9;
        TMPBackText.fontSize = 15;
        TMPText.fontSize = 15;
        allInput.fontSize = 15;
        progressiveDifficulty = true;
        GameStartPage();
        mode = 0;
        AssignWord();


        if (playerName == "Pepper")
        {
            life = 8;
        }
        else
        {
            life = 3;
        }

        combo.value = 0f;//initialize combovalue
        pause = false;

       

        scoreText.text = score.ToString();//initialize timer
    }





    void AssignWord()
    {


        if (progressiveDifficulty)
        {
            if((timerMin * 60 + timerSec) / (inputTimeMin * 60 + inputTimeSec) > 0.6)
            {
                mode = 0;
            }else if ((timerMin * 60 + timerSec) / (inputTimeMin * 60 + inputTimeSec) > 0.3)
            {
                mode = 1;
            }
            else
            {
                mode = 2;
            }
        }

        Word = new Vocabulary();
        Word.Randomize((VocabularyCategory)(mode + 1));


        if (shootBall)
        {
            TMPBackText.text = null;
            WordTextChinese.text = null;

            TMPBackTextOnBall.text = Word.Answer;
            WordTextChineseOnBall.text = Word.AnswerChinese;

            TMPBackTextOnBall.transform.parent.GetChild(0).gameObject.SetActive(true);//打开之前投球模式的背景
        }
        else
        {
            TMPBackTextOnBall.transform.parent.GetChild(0).gameObject.SetActive(false);//关掉之前投球模式的背景
           
            TMPBackTextOnBall.text = null;
            WordTextChineseOnBall.text = null;

            TMPBackText.text = Word.Answer;
            WordTextChinese.text = Word.AnswerChinese;
        }
        TMPText.text = null;

        TMPText.color = new Color(90f / 255f, 90f / 255f, 90f / 255f);

        allInput.text = null;
        
        


    }

   
       



    

    void TimeManager()
    {
       

        int timerSecInt = (int)timerSec;
        if (timerSecInt < 10)
        {
            timerSecText.text = "0"+timerSecInt.ToString();

        }
        else
        {
            timerSecText.text = timerSecInt.ToString();

        }

        int timerMinInt = (int)timerMin;
        if (timerMinInt < 10)
        {
            timerMinText.text = "0" + timerMinInt.ToString()+" :";

        }
        else
        {
            timerMinText.text = timerMinInt.ToString() + " :";

        }

        paulseTimerMinText.text = timerMinText.text;
        paulseTimerSecText.text = timerSecText.text;

        if (timerSec > 0&& timerSec<=60)
        {
            timerSec -= Time.deltaTime;
        }else if (timerSec<=0)
        {
            if (timerMin > 0)
            {
                timerMin--;
                timerSec = 60;
            }
            else if(inGamePanel.gameObject.active)
            {
                cameraAnim.SetBool("gameOver", true);
                Invoke("GameOverPage", 2.5f);
            }
        }
    }

    
    void InstatiateLifeBar()//生成UIlifeBar
    {
        if(lifeUI.GetComponentsInChildren<Transform>(true).Length !=life+1)
        {
            //Debug.Log(lifeUI.GetComponentsInChildren<Transform>(true).Length);
            DeleteLifeBar();
            for (int i = 0; i < life; i++)
            {
                GameObject life = Instantiate(lifeBarPrefab);
                
                life.transform.localScale = new Vector3(1f, 1f, 1f);
                life.GetComponent<RectTransform>().localPosition = new Vector3(playerIcon.GetComponent<RectTransform>().localPosition.x+160f+i*100f, playerIcon.GetComponent<RectTransform>().localPosition.y,0);
                

                life.transform.SetParent(lifeUI.transform,false);
            }
        }
    }

    void DeleteLifeBar()//删掉UIlifebar
    {
        if (lifeUI.GetComponentsInChildren<Transform>(true).Length != 1)
        {

           
           
            GameObject DeleteLifeUI = lifeUI;
            GameObject NewLifeUI = new GameObject("newLifeUI");
            NewLifeUI.transform.position = playerIcon.transform.position;
            NewLifeUI.transform.SetParent(DeleteLifeUI.transform.parent,false);
            //lifeUI = Instantiate(lifeBarPrefab, new Vector3(218 + i * 10, -10, 0), Quaternion.identity);
            lifeUI = NewLifeUI;
            Destroy(DeleteLifeUI);


        }
    }

    void InitializeLifeBar()
    {
        GameObject DeleteLifeUI = lifeUI;
        GameObject NewLifeUI = new GameObject("newLifeUI");
        NewLifeUI.transform.position = playerIcon.transform.position;
        NewLifeUI.transform.SetParent(DeleteLifeUI.transform.parent, false);
       //lifeUI = Instantiate(lifeBarPrefab, new Vector3(218 + i * 10, -10, 0), Quaternion.identity);
       lifeUI = NewLifeUI;
        Destroy(DeleteLifeUI);
    }


    void lifeUIControl()
    {

        if (life <= 0)
        {
            if (inGamePanel.gameObject.active)
            {
                inGame.gameObject.SetActive(false);
                inGamePanel.gameObject.SetActive(false);
                cameraAnim.SetBool("gameOver", true);

                inGamePanel.gameObject.SetActive(false);
                inGamePanelWorld.gameObject.SetActive(false);

                inGame.gameObject.SetActive(false);

                Invoke("GameOverPage", 1.2f);

            }
        }
       

        

        
        
    }

    public void Pause()
    {
        pause = !pause;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackTOGameSelection()
    {
        SceneManager.LoadScene(0);
    }
}
