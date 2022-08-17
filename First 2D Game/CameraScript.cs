using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Transform Player;
    private Vector3 pos;

    void Update()
    {
        pos = Player.position;
        pos.z = -10f;
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime);
    }

}
