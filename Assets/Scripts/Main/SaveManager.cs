// by Jiahui Hu

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{

    public SaveData Data;
    public static SaveManager Instance;
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

    [ContextMenu("Test Save")]
    public void Save()
    {
        string path = Path.Combine(Application.persistentDataPath, "ACCA_Save.json");
        string json = JsonUtility.ToJson(Data, true);

        if (!File.Exists(path))
        {
            var fs = File.Create(path);
            fs.Close();
        }

        File.WriteAllText(path, json);
    }

    [ContextMenu("Test Load")]
    public SaveData Load()
    {
        string path = Path.Combine(Application.persistentDataPath, "ACCA_Save.json");

        if (!File.Exists(path)) return new SaveData();

        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        Data = data;
        return data;
    }
}

[System.Serializable]
public class SaveData
{
    public string UserName = "Player";
    public List<SaveLevelData> SaveLevelDatas = new List<SaveLevelData>();

    public SaveData()
    {
        for (int i = 1; i < System.Enum.GetValues(typeof(LevelType)).Length; i++)
        {
            SaveLevelData data = new SaveLevelData();
            data.LevelID = i;
            SaveLevelDatas.Add(data);
        }
    }
}

[System.Serializable]
public class SaveLevelData
{
    public int LevelID = 0;
    public int Record = 0;
    public bool IsGold = false;
}

