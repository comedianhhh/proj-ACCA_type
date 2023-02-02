using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChickAudio : MonoBehaviour
{
    [Header("Slider")]
    public GameObject BGMSliderOBJ;
    public GameObject soundEffectSliderOBJ;



    [Header("AudioSource")]
    public GameObject BGM;
    public GameObject keyboard;
    public GameObject mouse;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BGM.GetComponent<AudioSource>().volume = BGMSliderOBJ.GetComponent<Slider>().value;
        keyboard.GetComponent<AudioSource>().volume = soundEffectSliderOBJ.GetComponent<Slider>().value;
        mouse.GetComponent<AudioSource>().volume = soundEffectSliderOBJ.GetComponent<Slider>().value;


        if (Input.anyKeyDown && !Input.GetMouseButton(0)&& !Input.GetMouseButton(1)&& !Input.GetMouseButton(2))
        {
            keyboard.GetComponent<AudioSource>().Play(0);
        }
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
        {
            mouse.GetComponent<AudioSource>().Play(0);
        }
    }
}
