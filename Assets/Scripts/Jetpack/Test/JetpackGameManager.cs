// By Hu Jiahui

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackGameManager : MonoBehaviour
{
    public static JetpackGameManager Instance;

    private void Awake()
    {
        if (!Instance) Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
