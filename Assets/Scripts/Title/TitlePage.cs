// by Jiahui Hu

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlePage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPage(GameObject pagePrefab)
    {
        TitleManager.Instance.AddPage(pagePrefab);
    }

    public void AddPageInverse(GameObject pagePrefab)
    {
        TitleManager.Instance.AddPage(pagePrefab, true);
    }

    public void RemovePage()
    {
        TitleManager.Instance.RemovePage(gameObject);
    }

    public void RemovePageInverse()
    {
        TitleManager.Instance.RemovePage(gameObject, true);
    }

    public void LoadLevel(string sceneName)
    {
        GameManager.Instance.LoadScene(sceneName);
    }
}
