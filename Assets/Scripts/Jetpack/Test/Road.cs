using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Road : MonoBehaviour
{
    public List<Transform> Exits = new List<Transform>();
    public Collider m_roadarea;
    //public List<Collider> IntersectionaColliders;
    RaycastHit m_Hit;
    bool m_HitDetect;
    private bool overlap=false;
    public Collider[] RoadColliders;
    public LayerMask IgnoreLayerMask;
    void Awake()
    {
        checkintersection();
        //Debug.Log(checkintersection());
    }

    public bool checkintersection()
    {
        //to do


        RoadColliders = Physics.OverlapBox(m_roadarea.bounds.center, m_roadarea.bounds.extents, Quaternion.identity,
            IgnoreLayerMask);
        if (RoadColliders.Length > 1) 
        {
            Debug.Log("overlap");
            return true;
        }

        return false;

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        //Check if there has been a hit yet
        if (m_HitDetect)
        {
            //Draw a Ray forward from GameObject toward the hit
            Gizmos.DrawRay(m_roadarea.bounds.center, transform.forward * m_Hit.distance);
            //Draw a cube that extends to where the hit exists
            Gizmos.DrawWireCube(m_roadarea.bounds.center + transform.forward * m_Hit.distance, m_roadarea.bounds.size);
        }
        //If there hasn't been a hit yet, draw the ray at the maximum distance
        else
        {
            //Draw a Ray forward from GameObject toward the maximum distance
            Gizmos.DrawRay(m_roadarea.bounds.center, new Vector3(0,0,0));
            //Draw a cube at the maximum distance
            Gizmos.DrawWireCube(m_roadarea.bounds.center, m_roadarea.bounds.size);
        }
    }
    void Start()
    {
        if (m_roadarea == null) m_roadarea=GetComponent<Collider>();
    }


}
