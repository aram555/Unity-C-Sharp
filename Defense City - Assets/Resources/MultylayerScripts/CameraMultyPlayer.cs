using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraMultyPlayer : MonoBehaviour
{
    public GameObject Player;
    public Vector3 Offset;
    public Quaternion newRotation;
    public float rotationAmount;
    public Transform cameraTransform;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Player != null) {
            if(Input.GetKey(KeyCode.Q)) {
                newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);
            }

            if(Input.GetKey(KeyCode.E)) {
                newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
            }

            transform.position = Vector3.Lerp(transform.position, Player.transform.position, 10f * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 10f * 0.01f);
        }
        else {
            return;
        }
    }
}
