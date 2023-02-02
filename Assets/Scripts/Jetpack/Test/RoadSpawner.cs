//NianZhi
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class RoadSpawner : MonoBehaviour
{
    public static RoadSpawner Instance;
    //record roads'number


    [Header("loactionControl")]


    public int RoadsNumber;

    public List<Transform> generatorPoint;
    

    //public LayerMask roadLayer;



    [Header("References")]

    public GameObject[] lRoadPrefabs;
    public GameObject[] rRoadPrefabs;
    public GameObject[] sRoadPrefabs;

    [Header("Weights From0 to 1")]
    public float lRoadWeights; 
    public float rRoadWeights;
    public float sRoadWeights;


    public List<GameObject> Roads = new List<GameObject>();

    private void Awake()
    {
        if (!Instance) Instance = this;
    }

    public void Start()
    {
        
        Rooms[0].roomID = 0;
        Rooms[0].roomWeight = lRoadWeights;
        Rooms[1].roomID = 1;
        Rooms[1].roomWeight = rRoadWeights;
        Rooms[2].roomID = 2;
        Rooms[2].roomWeight = sRoadWeights;

        CreateRoads();

    }

    public void CreateRoads()
    {
        bool hasIntersection = false;

        //RaycastHit hit;

        do
        {
            for (int i = 0; i < Roads.Count; i++)
            {
                Destroy(Roads[i]);
                Debug.Log("destory");
            }

            Roads.Clear();


            for (int i = 0; i < RoadsNumber; i++)
            {

                if (generatorPoint.Count >= 0)

                {


                    Roads.Add(Instantiate(GetLevelPrefab(RandomRoom()), generatorPoint[0].position,
                        generatorPoint[0].rotation));
                    
                    //Debug.Log(hit.collider);

                    generatorPoint.RemoveAt(0);

                }

                ChangePointPos();
            }

            foreach (var Road in Roads)
            {
                //Debug.Log(Road.GetComponent<Road>().checkintersection());

                if (Road.GetComponent<Road>().checkintersection() == true)
                {
                    hasIntersection = true;
                    break;
                }
            }
            

        } while (hasIntersection == true);
    


    }

    public void ChangePointPos()
    {
        //get exits
        GameObject road;
        Roads.Reverse();
        road = Roads[0];
        Roads.Reverse();
        List<Transform> Pos = road.GetComponent<Road>().Exits;
        foreach (var exit in Pos)
        {
            generatorPoint.Add(exit);
        }
        

    }

    //Ëæ»úµÀÂ·
    public struct room
    {
        public int roomID;
        public float roomWeight;
    };
    public static int RoomTypeNum = 3;
    public room[] Rooms = new room[RoomTypeNum];


    int RandomRoom()
    {

        int type = 0;
        int seed = ((int)Random.Range(1000, 2000) % 100) + 1; // 1-100
        int index = 0;
        for (int i = 0; i < RoomTypeNum; i++)
        {
            int l = (int)(Rooms[i].roomWeight * 100f);
            if ((seed > index) && (seed < (index + l)))
            {
                type = Rooms[i].roomID;
            }
            index += l;
        }
        Debug.Log(type);
        return type;
    }
    public GameObject GetLevelPrefab(int dir)
    {
        GameObject[] levelPrefabs = null;

        //return type;

        //1--left;2--right;3--Straight


        if (dir == 0) levelPrefabs = lRoadPrefabs;

        else if (dir == 1) levelPrefabs = rRoadPrefabs;

        else if (dir == 2) levelPrefabs = sRoadPrefabs;

        if (levelPrefabs != null) return levelPrefabs[Random.Range(0, levelPrefabs.Length)];

        else return null;
    }




}
