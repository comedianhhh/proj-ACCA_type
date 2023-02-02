using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCamFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 Offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position+Offset;

        Vector3 rot = new Vector3(90, player.eulerAngles.y, 0);
        transform.rotation = Quaternion.Euler(rot);

    }
}
