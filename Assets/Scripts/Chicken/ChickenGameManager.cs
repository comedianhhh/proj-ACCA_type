// By Hu Jiahui

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenGameManager : MonoBehaviour
{    
    public static ChickenGameManager Instance;
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
