//by Siqi Qin
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject Map;
    public GameObject Player;
    public int MapNum = 10;
    private GameObject[] map;

    void Start()
    {
        SpawnMap();
    }

    void Update()
    {
        ManageMap();
    }

    void SpawnMap() //Spawn the map.
    {
        map = new GameObject[MapNum];
        for (int i = 0; i < MapNum; i++)
        {
            Vector3 pos = new Vector3(0, 0, 0 + i * 90);
            map[i] = Instantiate(Map, pos, Quaternion.identity) as GameObject;
        }
    }

    void ManageMap() //Repeat the map.
    {
        Vector3 newCoord = Player.transform.position;
        for(int i = 0; i < MapNum; i++)
        {
            if((map[i].transform.position.z + 80) < newCoord.z)
            {
                Vector3 pos = new Vector3(map[i].transform.position.x, map[i].transform.position.y, map[i].transform.position.z);
                map[i].transform.position = pos;
            }
        }
    }
}
