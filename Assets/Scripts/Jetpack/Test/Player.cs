//by NianZhi
// Jetpack

using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class Player : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] float m_GhostDuration = 3;
    [SerializeField] float m_SpeedDownPeriod = 2;

    [Header("Reference")]
    // Words
    public TMP_Text TMPBackText;
    public TMP_Text TMPText;
    // T Cross Words
    public TMP_Text TLTextBack;
    public TMP_Text TLTextFront;
    public TMP_Text TRTextBack;
    public TMP_Text TRTextFront;

    [Header("Data")]
    [SerializeField] DelayZone m_DelayZone;
    [SerializeField] float m_PlayerSpeed = 10;
    [SerializeField] bool m_IsTurnRight;
    bool playError = true;
    [SerializeField] bool m_IsGoUp;
    [SerializeField] float m_StunnedTimer = 0;


    //By Xiang Tianyu
    [SerializeField] bool IsDash = false;
    [SerializeField] bool IsGhost = false;
    [SerializeField] float dashTimer = 0;
    float ghostTimer = 0;
    float SpeedDownTimer = 0;

    // Components
    public static Player Instance;
    private CharacterController character;
    private Animator animator;
    public AudioSource hited;
    public AudioSource bingo;
    //combo
    public int ComboCount = 0;
    public Image ComboBar;
    public float BingoCombo = 50;
    public TMP_Text ComboText;



    private void Awake()
    {
        if (!Instance) Instance = this;
    }

    void Start()
    {
        character = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        GetSkin();

    }
    
    void Update()
    {
        Dash();
        Ghost();
        Move();
        //SpeedDown();
        Debug.Log(playError);
        InputWords();
        //combo by 董明儒
        ComboText.text = ComboCount.ToString();
        ComboBar.fillAmount = (float)ComboCount / BingoCombo;
    }

    public void Move()
    {
        float speed;
        if (IsDash) speed = m_PlayerSpeed * 2;
        else if (IsGhost) speed = m_PlayerSpeed;
        else if (m_StunnedTimer > 0) speed = 0;
        else if (m_DelayZone || SpeedDownTimer > 0) speed = 1;
        else speed = m_PlayerSpeed;

        if (SpeedDownTimer > 0) SpeedDownTimer -= Time.deltaTime;
        if (m_StunnedTimer > 0) m_StunnedTimer -= Time.deltaTime;
        animator.SetBool("IsFlying", true);
        character.Move(speed * Time.deltaTime * transform.forward);
    }

    // by Hu Jiahui
    void Dash()
    {
        if (IsDash)
        {
            dashTimer += Time.deltaTime;
            if (dashTimer >= 5)
            {
                Debug.Log("stopDashing");
                IsDash = false;
            }
        }
    }

    void Ghost()
    {
        if (IsGhost)
        {
            ghostTimer += Time.deltaTime;
            if (ghostTimer >= m_GhostDuration)
            {
                IsGhost = false;
            }
        }
    }

    public void StarTurnR()
    {
        animator.SetBool("IsFlying", false);
        transform.Rotate(Vector3.up, 90f);
        Quaternion endValue = transform.rotation;
        transform.Rotate(Vector3.up, -90f);
        animator.SetTrigger("TurnR");
        Tween tween = transform.DORotateQuaternion(endValue, 1f);
        tween.OnComplete(() => { SetSpeed(10f); animator.SetBool("IsFlying", true); });

    }
    public void StarTurnL()
    {
        animator.SetBool("IsFlying", false);
        transform.Rotate(Vector3.up, -90f);
        Quaternion endValue = transform.rotation;
        transform.Rotate(Vector3.up, 90f);
        animator.SetTrigger("TurnL");
        Tween tween = transform.DORotateQuaternion(endValue, 1f);
        tween.OnComplete(() => { SetSpeed(10f); animator.SetBool("IsFlying", true); });
    }

    //public void StartGoDwon()
    //{
    //    transform.Rotate(Vector3.right, 20f);
    //    Quaternion endValue = transform.rotation;
    //    transform.Rotate(Vector3.right, -20f);
    //    Tween tween = transform.DORotateQuaternion(endValue, 1f);
    //    tween.OnComplete(() => { SetSpeed(10f); animator.SetBool("IsFlying", true); });
    //}
    public void StartGoUp()
    {
        transform.Rotate(Vector3.right, -20f);
        Quaternion endValue = transform.rotation;
        transform.Rotate(Vector3.right, 20f);
        Tween tween = transform.DORotateQuaternion(endValue, 1f);
        tween.OnComplete(() => { SetSpeed(10f); animator.SetBool("IsFlying", true); });
    }


    public void SetSpeed(float a)
    {
        //PlayerSpeed = a;
    }

    public void RestoreSpeed()
    {
        //SetSpeed(10);
    }





    void OnTriggerEnter(Collider collider)
    {
        playError = true;
        if (!IsGhost && collider.tag == "Dash") // Ghost状态下不可拾取
        {
            IsDash = true;
            dashTimer = 0;
            Debug.Log("getDashing");
            Destroy(collider.gameObject);
        }

        if (collider.tag == "Ghost")
        {
            IsGhost = true;
            ghostTimer = 0;
            Destroy(collider.gameObject);
        }
        if (collider.tag == "Building")
        {
            Debug.Log("MeetBuilding");
            SpeedDownTimer = m_SpeedDownPeriod;

            if (collider.GetComponentInChildren<DelayZone>().ZoneType == DelayZone.Type.Block)
            {
                Destroy(collider.gameObject);
                hited.Play(0);
                animator.SetTrigger("IsKnocked");
                animator.SetBool("IsFlying", false);

            }
            ResetInputUI();
        }

        // When knocking to a wall
        if (collider.GetComponent<Decelerate>())
        {
            hited.Play(0);
            m_StunnedTimer = 2;
            animator.SetTrigger("IsKnocked");
            animator.SetBool("IsFlying", false);
            Invoke("Pass", 2);
        }
        
        var delayZone = collider.GetComponent<DelayZone>();
        if (delayZone)
        {
            Debug.LogWarning("In zone: " + delayZone.name);
            m_DelayZone = delayZone;
            m_IsTurnRight = delayZone.IsRight;
            m_IsGoUp = delayZone.IsGoUp;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var delayZone = other.GetComponent<DelayZone>();
        if (delayZone && delayZone == m_DelayZone)
        {
            m_DelayZone = null;
        }
        //combo
        //if (delayZone && other.GetComponent<DelayZone>().IsRight)
        //{
        //    ComboCount += 1;
        //}
        //else
        //{
        //    ComboCount = 0;
        //}
    }



    void Pass()
    {
        ResetInputUI();
        animator.SetBool("IsFlying", true);

        if (m_DelayZone && m_DelayZone.ZoneType == DelayZone.Type.Block)
        {
            Destroy(m_DelayZone.transform.parent.gameObject);
            return;
        }

        Transform point = m_DelayZone.Point;
        Transform point2 = m_DelayZone.Point_2;

        //determine which type
        if (m_DelayZone.ZoneType == DelayZone.Type.Turn&&m_IsTurnRight) 
        {
            Player.Instance.StarTurnR();
            Player.Instance.transform.DOMove(point.position, 1F);
        }

        else if (m_DelayZone.ZoneType == DelayZone.Type.Turn&&m_IsTurnRight != true)
        {

            Player.Instance.StarTurnL();
            Player.Instance.transform.DOMove(point.position, 1F);
        }

        else if (m_DelayZone.ZoneType == DelayZone.Type.Bridge && m_IsGoUp)
        {
            Player.Instance.StartGoUp();
            Tween tween = Player.Instance.transform.DOMove(point.position, 1F);
            tween.OnComplete(() => { Player.Instance.transform.DOMove(point2.position, 1F);
                Player.Instance.transform.DORotate(Vector3.zero, 1);
            });
            SetSpeed(10f);
        }
        else if (m_DelayZone.ZoneType == DelayZone.Type.Bridge && m_IsGoUp!=true)
        {
            //Player.Instance.StartGoDwon();
            Tween tween = Player.Instance.transform.DOMove(point.position, 1F);
            //tween.OnComplete(() => {
            //    Player.Instance.transform.DOMove(point2.position, 1F);
            //    Player.Instance.transform.DORotate(Vector3.zero, 1);
            //});
            SetSpeed(10f);
        }
    }

    void InputWords()
    {

        if (!m_DelayZone || m_DelayZone.HasPassed) return;

        bool isPass = false;

        if (IsGhost || IsDash)
        {
            isPass = true;
            ComboCount += 1;
            bingo.Play(0);
        }

        else if (m_DelayZone.IsTCross)
        {
            TLTextBack.text = m_DelayZone.WordLeft.Answer;
            TRTextBack.text = m_DelayZone.WordRight.Answer;
            if (m_DelayZone.WordLeft.GetInput() || m_DelayZone.WordRight.GetInput())
            {
                TLTextFront.text = m_DelayZone.WordLeft.CorrectInputs;
                TRTextFront.text = m_DelayZone.WordRight.CorrectInputs;
                if (m_DelayZone.WordLeft.IsCorrect)
                {
                    m_DelayZone.IsRight = false;
                    isPass = true;
                    ComboCount += 1;
                    bingo.Play(0);
                }
                else if (m_DelayZone.WordRight.IsCorrect)
                {
                    m_DelayZone.IsRight = true;
                    isPass = true;
                    ComboCount += 1;
                    bingo.Play(0);
                }
            }
        }

        else
        {
           
            TMPBackText.text = m_DelayZone.word.Answer;
            if (m_DelayZone.word.GetInput())
            {
                TMPText.text = m_DelayZone.word.CorrectInputs;
                if (m_DelayZone.word.IsCorrect)
                {
                    isPass = true;
                    ComboCount += 1;
                    bingo.Play(0);
                }

                
            }
            if (m_DelayZone.word.HasMistake)
            {

                TMPText.text = "";
                TMPBackText.text = "";
                m_DelayZone.word.CorrectInputs = null;
                

            }

            if (m_DelayZone.word.HasMistake && playError)
            {
                hited.Play(0);
                playError = false;
            }



        }

        if (isPass)
        {
            m_DelayZone.HasPassed = true;
            Pass();
        }
    }


    void ResetInputUI()
    {
        TMPBackText.text = "";
        TMPText.text = "";
    }

    //by Qin Siqi
    [Header("Game Objects")]
    public GameObject Skin1;
    public GameObject Skin2;
    public GameObject Skin3;

    public void GetSkin()
    { 
        int skin = PlayerPrefs.GetInt("PlaySkin");
        switch (skin)
        {
            case 1:
                {
                    FoxSkin();
                }
                break;

            case 2:
                {
                    CatSkin();
                }
                break;

            case 3:
                {
                    RaccoonSkin();
                }
                break;

            default:
                {
                    CatSkin();
                }
                break;
        }
    }

    public void FoxSkin()
    {
        Skin1.gameObject.SetActive(true);
        Skin2.gameObject.SetActive(false);
        Skin3.gameObject.SetActive(false);
    }
    public void CatSkin()
    {
        Skin1.gameObject.SetActive(false);
        Skin2.gameObject.SetActive(true);
        Skin3.gameObject.SetActive(false);
    }
    public void RaccoonSkin()
    {
        Skin1.gameObject.SetActive(false);
        Skin2.gameObject.SetActive(false);
        Skin3.gameObject.SetActive(true);
    }

}

