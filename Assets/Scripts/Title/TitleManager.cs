// by Jiahui Hu

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TitleManager : MonoBehaviour
{
    [Header("Asset References")]
    [SerializeField] GameObject[] m_PatternPrefabs = new GameObject[4];
    [SerializeField] GameObject m_TitlePrefab;

    [Header("Object References")]
    [SerializeField] Transform m_PatternGroup;
    [SerializeField] Transform m_EnterPoint;
    [SerializeField] Transform m_CentrePoint;
    [SerializeField] Transform m_ExitPoint;

    public static TitleManager Instance;

    Canvas m_Canvas;
    private void Awake()
    {
        if (!Instance) Instance = this;

        m_Canvas = FindObjectOfType<Canvas>();
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 12; i++)
        {
            Instantiate(m_PatternPrefabs[i % m_PatternPrefabs.Length], m_PatternGroup);
        }

        AddPage(m_TitlePrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPage(GameObject pagePrefab, bool inverse = false)
    {
        var page = Instantiate(pagePrefab, m_Canvas.transform);
        page.transform.position = inverse ? m_ExitPoint.position : m_EnterPoint.position;
        page.transform.rotation = inverse ? m_ExitPoint.rotation : m_EnterPoint.rotation;
        page.transform.DOMove(m_CentrePoint.position, 0.5f);
        page.transform.DORotateQuaternion(m_CentrePoint.rotation, 0.5f);
    }

    public void RemovePage(GameObject page, bool inverse = false)
    {
        page.transform.DOMove(inverse ? m_EnterPoint.position : m_ExitPoint.position, 0.5f);
        page.transform.DORotateQuaternion(inverse ? m_EnterPoint.rotation : m_ExitPoint.rotation, 0.5f).OnComplete(() => Destroy(page));
    }
}
