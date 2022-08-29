using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Player;
    public Vector3 Offset;
    public Quaternion newRotation;
    public float rotationAmount;
    public Transform cameraTransform;
    public Vector3 zoom;
    // Start is called before the first frame update
    void Start()
    {
        zoom = Offset;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player == null) {
            GameObject RifleSoldier = GameObject.Find("RifleSoldier(Clone)");
            GameObject MachineGunSoldier = GameObject.Find("MachineGunSoldier(Clone)");
            GameObject SniperSoldier = GameObject.Find("SniperSoldier(Clone)");
            
            if(RifleSoldier) {
                Player = RifleSoldier;
                Offset.y = 15;
            }
            if(MachineGunSoldier) {
                Player = MachineGunSoldier;
                Offset.y = 15;
            }
            if(SniperSoldier) {
                Player = SniperSoldier;
                Offset.y += 5;
            }
        }
        else {
            //this.gameObject.transform.SetParent(Player.transform.GetChild(0));
            //transform.position = Player.transform.position + Offset;
            //transform.parent.Rotate(0, Input.GetAxis("Mouse X") * 4f, 0);

            // transform.position = Vector3.Lerp(transform.position, (Player.transform.position + Offset), Time.deltaTime * 5);
            // Offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 4f, Vector3.up) * Offset;
            // transform.LookAt(Player.transform);

            if(Input.GetKey(KeyCode.Q)) {
                newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);
            }

            if(Input.GetKey(KeyCode.E)) {
                newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
            }

            transform.position = Vector3.Lerp(transform.position, Player.transform.position, 10f * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 10f * Time.deltaTime);
        }
    }
}
