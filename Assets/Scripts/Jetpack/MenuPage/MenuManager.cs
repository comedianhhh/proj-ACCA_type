//by Qin Siqi
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("UI Elements")]
    public Button Back_B;
    public Button Start_B;
    public Button fox_icon;
    public Button cat_icon;
    public Button raccoon_icon;

    [Header("Game Objects")]
    public GameObject Skin1;
    public GameObject Skin2;
    public GameObject Skin3;

    [Header("Effect Setting")]
    public Text UIText;
    public float transSpeed = 10;
    private float colorSpeed = 10;
    Color changeColor;
    private float alpha = 60;

    private void Start()
    {
        GetSkin();
        colorSpeed = transSpeed;
        alpha = 60;
        changeColor = UIText.color;

    }

    // Update is called once per frame
    void Update()
    {
        FlickerText();
    }

    //Interface Jump Control
    public void StartGame()
    {
        //OriginSkin();
        SceneManager.LoadScene("Test_Jetpack");
    }

    public void BacktoTitle()
    {
        SceneManager.LoadScene("Demo_MenuPage");
    }

    //Change Skin Control
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
        PlayerPrefs.SetInt("PlaySkin", 1);
        PlayerPrefs.Save();
    }
    public void CatSkin()
    {
        Skin1.gameObject.SetActive(false);
        Skin2.gameObject.SetActive(true);
        Skin3.gameObject.SetActive(false);
        PlayerPrefs.SetInt("PlaySkin", 2);
        PlayerPrefs.Save();
    }
    public void RaccoonSkin()
    {
        Skin1.gameObject.SetActive(false);
        Skin2.gameObject.SetActive(false);
        Skin3.gameObject.SetActive(true);
        PlayerPrefs.SetInt("PlaySkin", 3);
        PlayerPrefs.Save();
    }

    //Effect
    public void FlickerText()
    {
        alpha += colorSpeed;
        if (alpha < 60)
        {
            alpha = 60;
            colorSpeed = transSpeed;
        }

        if (alpha > 255)
        {
            alpha = 255;
            colorSpeed = -transSpeed;
        }

        changeColor.a = alpha / 255;
        UIText.color = changeColor;

    }

}
