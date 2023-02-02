using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


public class ChickSkinManager : MonoBehaviour
{
    public List<ChickSkin> chickSkin = new List<ChickSkin>();
    public List<ChickBGSkin> chickBGSkin = new List<ChickBGSkin>();
    public List<GameObject> playerUISlots = new List<GameObject>();
    public List<GameObject> bgUISlots = new List<GameObject>();


    [Header("OBJ")]
    public GameObject changeSkinPanel;
    public GameObject playerSkinSlot;//prefab
    public GameObject BGSkinSlot;//prefab
    public GameObject Background;
    public GameObject nextBG;
    public Sprite BackgroundSp;
    public Sprite nextBGSp;
    public GameObject rain;
    public Sprite rainSprite;
    public TMP_Text statusText;
    public int rand;
    public GameObject wordManager;
    

    [Header("AutoChangeBG")]
    public bool autoChangeBG;
    public float timer;
    public float BGSwapTime;
    public Animator anim;


    [Header("Transform")]
    public Transform playerSkinTrans;
    public Transform BGSkinTrans;
    public float offsetP;
    public float offsetBG;
    public Transform MoveRight;
    public Transform MoveLeft;
    public Transform Mid;
    public Transform Bot;
    
    public GameObject leftestBG;
    public GameObject rightestBG;
    public GameObject changeBGButton;


    [Header("CharactorSkin")]
    public GameObject basketballFrame;
    public string charactorName;
    public GameObject vegetable;
    public GameObject fighter;
    public GameObject pepper;
    public Image choosenSkin;
    public Image choosenBGSkin;
    public Sprite vegetableSp;
    public Sprite fighterSp;
    public Sprite pepperSp;





    // Start is called before the first frame update


    void Start()
    {
        for (int i = 0; i < chickSkin.Count; i++)
        {
            Vector3 trans = new Vector3(playerSkinTrans.transform.position.x + i* offsetP, playerSkinTrans.transform.position.y, playerSkinTrans.transform.position.z);
            GameObject slot = Instantiate(playerSkinSlot, trans, Quaternion.identity);
            slot.transform.GetChild(0).GetComponent<Image>().sprite = chickSkin[i].sprite;
            slot.transform.GetChild(1).GetComponent<TMP_Text>().text = chickSkin[i].name;
            slot.transform.parent = playerSkinTrans;
            playerUISlots.Add(slot);
        }

        for (int i = 0; i < chickBGSkin.Count; i++)
        {
            Vector3 trans = new Vector3(BGSkinTrans.transform.position.x + i * offsetBG, BGSkinTrans.transform.position.y, BGSkinTrans.transform.position.z);
            GameObject slot = Instantiate(BGSkinSlot, trans, Quaternion.identity);
            slot.transform.GetChild(0).GetComponent<Image>().sprite = chickBGSkin[i].sprite;
            slot.transform.GetChild(1).GetComponent<TMP_Text>().text = chickBGSkin[i].name;
            slot.transform.parent = BGSkinTrans;
            bgUISlots.Add(slot);
        }
        //后面如果角色多了用下面代码
        //playerSkinTrans.transform.position =new Vector3(MoveLeft.position.x, playerUISlots[playerUISlots.Count - 1].transform.position.y,0);
        BGSkinTrans.transform.position=new Vector3(MoveLeft.position.x, bgUISlots[bgUISlots.Count - 1].transform.position.y,0);
       
        leftestBG = BGSkinTrans.GetChild(0).gameObject;
        rightestBG = BGSkinTrans.GetChild(chickBGSkin.Count-1).gameObject;
        ChangeCharacter();
        
    }

    // Update is called once per frame
    void Update()
    {
        nextBGSp = nextBG.GetComponent<SpriteRenderer>().sprite;
        BackgroundSp = Background.GetComponent<SpriteRenderer>().sprite;
        choosenBGSkin.sprite = BackgroundSp;

        if (changeSkinPanel.gameObject.active)
            MoveUI();
        if (autoChangeBG)
        {
            nextBG.gameObject.SetActive(true);
            AutoChangeBG();
        }
        else
        {
            nextBG.gameObject.SetActive(false);
        }


        if (Background.GetComponent<SpriteRenderer>().sprite == rainSprite){
            Background.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            Background.transform.GetChild(0).gameObject.SetActive(false);
        }

        if (charactorName == "Vegetable")
        {
            vegetable.gameObject.SetActive(true);
            fighter.gameObject.SetActive(false);
            pepper.gameObject.SetActive(false);
            choosenSkin.sprite = vegetableSp;
            basketballFrame.GetComponent<ChickAnimationControl>().charactorName = charactorName;
            wordManager.GetComponent<ChickWordManager>().playerName = charactorName;
        }
        else if(charactorName == "Fighter")
        {
            fighter.gameObject.SetActive(true);
            vegetable.gameObject.SetActive(false);
            pepper.gameObject.SetActive(false);
            choosenSkin.sprite = fighterSp;
            basketballFrame.GetComponent<ChickAnimationControl>().charactorName = charactorName;
            wordManager.GetComponent<ChickWordManager>().playerName = charactorName;
        }
        else if (charactorName == "Pepper")
        {
            fighter.gameObject.SetActive(false);
            vegetable.gameObject.SetActive(false);
            pepper.gameObject.SetActive(true);
            choosenSkin.sprite = pepperSp;
            basketballFrame.GetComponent<ChickAnimationControl>().charactorName = charactorName;
            wordManager.GetComponent<ChickWordManager>().playerName = charactorName;
        }

    }

    public void AutoChangeBG()
    {
        timer += Time.deltaTime;
        anim.SetFloat("timer", timer);

        if(timer >= 11f)
        {
            Background.GetComponent<SpriteRenderer>().sprite = nextBG.GetComponent<SpriteRenderer>().sprite;
            
        }

        if (timer >= BGSwapTime)
        {
            timer = -0.5f;
            int pre = rand;
            rand = Random.Range(1, chickBGSkin.Count);

            for(int i = -1; i<0;i--)
            {
                if (rand == pre)
                {
                    rand = Random.Range(1, chickBGSkin.Count);
                }
                else
                {
                    i = 1;
                }
            }

           
            
            nextBG.GetComponent<SpriteRenderer>().sprite = chickBGSkin[rand].sprite;
           
            
        }
    }

    
    public void MoveUI()
    {
       

        if (Input.mousePosition.y <= Mid.position.y&& Input.mousePosition.y >= Bot.position.y)
        {
            if (Input.mousePosition.x >= MoveRight.position.x)
            {
                /*if (bgUISlots[bgUISlots.Count - 1].transform.position.x >= MoveRight.position.x)
                {*/
                    Vector3 pos = new Vector3(BGSkinTrans.position.x - 5f, BGSkinTrans.position.y, BGSkinTrans.position.z);
                    BGSkinTrans.position = pos;
               /* }
*/
            }

            if (Input.mousePosition.x <= MoveLeft.position.x)
            {
               /* if (bgUISlots[0].transform.position.x <= MoveLeft.position.x) //这是限制移动范围
                {*/
                    Vector3 pos = new Vector3(BGSkinTrans.position.x + 5f, BGSkinTrans.position.y, BGSkinTrans.position.z);
                    BGSkinTrans.position = pos;
               /* }*/


            }
        }
        //后面如果角色多了用下面代码

       /* if (Input.mousePosition.y >= Mid.position.y)
        {
            if (Input.mousePosition.x >= MoveRight.position.x)
            {
                if (playerUISlots[playerUISlots.Count - 1].transform.position.x >= MoveRight.position.x)
                {
                    Vector3 pos = new Vector3(playerSkinTrans.position.x - 5f, playerSkinTrans.position.y, playerSkinTrans.position.z);
                    playerSkinTrans.position = pos;
                }

            }

            if (Input.mousePosition.x <= MoveLeft.position.x)
            {
                if (playerUISlots[0].transform.position.x <= MoveLeft.position.x)
                {
                    Vector3 pos = new Vector3(playerSkinTrans.position.x + 5f, playerSkinTrans.position.y, playerSkinTrans.position.z);
                    playerSkinTrans.position = pos;
                }


            }
        }*/
        changeSlotsAlpha();
    }

    void changeSlotsAlpha()
    {
        for(int i = 0; i < chickSkin.Count; i++)
        {
            Transform trans = playerSkinTrans.GetChild(i).transform;
            if(trans.transform.position.x< MoveLeft.position.x- 120f || trans.transform.position.x > MoveRight.position.x+ 120f)
            {
                trans.gameObject.SetActive(false);
            }
            else
            {
                trans.gameObject.SetActive(true);
            }
        }

        for (int i = 0; i < chickBGSkin.Count; i++)
        {
           

            Transform trans = BGSkinTrans.GetChild(i).transform;
            /*if (trans.rotation.y>=-0.01f&& trans.rotation.y <= 0.01f)
            {
                trans.gameObject.SetActive(false);
                Debug.Log(trans.rotation.y);
            }
            else
            {
                trans.gameObject.SetActive(true);
            }*/
            if (trans.position.x < Mid.position.x)
            {
                //(Mid.position.x - trans.position.x)*0.1f
                var rotationVector = transform.rotation.eulerAngles;
                rotationVector.y = -(Mid.position.x - trans.position.x) * 0.07f;
                trans.rotation = Quaternion.Euler(rotationVector);


                Image image = trans.GetComponent<Image>();

                Image imagec = trans.GetChild(0).GetComponent<Image>();

                image.color = new Color(image.color.r, image.color.g, image.color.b, (155 - (Mid.position.x - trans.position.x) * 0.3f)/255);
                imagec.color = new Color(image.color.r, image.color.g, image.color.b, (255 - (Mid.position.x - trans.position.x) * 0.3f)/255);

                //Debug.Log(image.color.a);
            }

            if (trans.position.x > Mid.position.x)
            {
                //(Mid.position.x - trans.position.x)*0.1f
                var rotationVector = transform.rotation.eulerAngles;
                rotationVector.y = (trans.position.x- Mid.position.x) * 0.07f;
                trans.rotation = Quaternion.Euler(rotationVector);

                Image image = trans.GetComponent<Image>();

                Image imagec = trans.GetChild(0).GetComponent<Image>();

                image.color = new Color(image.color.r, image.color.g, image.color.b, (155 - (trans.position.x - Mid.position.x) * 0.3f)/255);
                imagec.color = new Color(image.color.r, image.color.g, image.color.b, (255 - (trans.position.x - Mid.position.x) * 0.3f) / 255);
            }


            if (trans.position.x < leftestBG.transform.position.x)
            {
                leftestBG = trans.gameObject;
            }

            if (trans.position.x > rightestBG.transform.position.x)
            {
                rightestBG = trans.gameObject;
            }

        }

        for (int i = 0; i < chickBGSkin.Count; i++)
        {
            Transform trans = BGSkinTrans.GetChild(i).transform;
            if (trans.transform.position.x < MoveLeft.position.x - 65f || trans.transform.position.x > MoveRight.position.x + 65f)
            {
                trans.gameObject.SetActive(false);
            }
            else
            {
                trans.gameObject.SetActive(true);
            }


            if (leftestBG.transform.position.x>MoveLeft.position.x + 50f)
            {
                rightestBG.transform.position = new Vector3(leftestBG.transform.position.x - offsetBG, rightestBG.transform.position.y, rightestBG.transform.position.z);

            }

            if (rightestBG.transform.position.x < MoveRight.position.x - 50f)
            {
                leftestBG.transform.position = new Vector3(rightestBG.transform.position.x + offsetBG, rightestBG.transform.position.y, rightestBG.transform.position.z);

            }
        }
    }

    public void AutoBGChangeToggle()
    {
        autoChangeBG = !autoChangeBG;
        rand = Random.Range(1, chickBGSkin.Count);
        nextBG.GetComponent<SpriteRenderer>().sprite = chickBGSkin[rand].sprite;
        timer = 0f;
        if (autoChangeBG)
        {
            statusText.text = "ON";
        }
        else
        {
            statusText.text = "OFF";
        }

        if (autoChangeBG)
        {
            ChangeCharacter();
            changeBGButton.gameObject.SetActive(false);
        }
        else
        {
            changeBGButton.gameObject.SetActive(true);

        }
    }


    public void ChangeBackGround()
    {
        BGSkinTrans.gameObject.SetActive(true);
        playerSkinTrans.gameObject.SetActive(false);
    }

    public void ChangeCharacter()
    {
        BGSkinTrans.gameObject.SetActive(false);
        playerSkinTrans.gameObject.SetActive(true);
    }

   
}
