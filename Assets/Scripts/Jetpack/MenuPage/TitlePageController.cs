//by Qin Siqi
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitlePageController : MonoBehaviour
{
    public Button Playing;
    public Button Setting;
    public Button Exit;
    public GameObject Camera;

    public float speed;

    private void Update()
    {
        CameraMovement();
    }

    void CameraMovement()
    {
        if (transform.position.z >= -12)
        {
            Camera.transform.position += transform.forward * -speed * Time.deltaTime;
        }
        if (transform.position.z <= -20)
        {
            Camera.transform.position += transform.forward * speed * Time.deltaTime;
        }
        
    }

    public void OnPlay()
    {
        SceneManager.LoadScene("JetPack_MainPage");
    }

    public void OnSetting()
    {

    }
    public void QuitGame()
    {
        SceneManager.LoadScene("Title");
    }
}
