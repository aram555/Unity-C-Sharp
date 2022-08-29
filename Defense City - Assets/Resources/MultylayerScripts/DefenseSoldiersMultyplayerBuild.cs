using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DefenseSoldiersMultyplayerBuild : MonoBehaviour
{
    public GameObject defenseSoldier;
    RaycastHit hit;
    GameObject cam;
    PhotonView view;
    Camera myCamera;
    Animator anim;
    Vector3 oldPos;

    // Update is called once per frame
    void Update()
    {
        if(myCamera != null) {
            if(Physics.Raycast(myCamera.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, LayerMask.GetMask("Ground"))) {
                transform.position = hit.point;
            }
            if(Input.GetKeyDown(KeyCode.Mouse0)) {
                PhotonNetwork.Instantiate(defenseSoldier.name, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }
        }
        else {
            cam = GameObject.FindGameObjectWithTag("PlayerCamera");
            view = cam.GetComponent<PhotonView>();
            if(cam != null && view.IsMine) {
                myCamera = cam.GetComponent<Camera>();
            }
        }
    }
}
