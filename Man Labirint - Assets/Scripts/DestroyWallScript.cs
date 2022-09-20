using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWallScript : MonoBehaviour
{
    public float damage;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            if(Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity)) {
                if(hit.collider.gameObject.tag == "Wall") {
                    var WallObj = hit.collider.gameObject.GetComponent<WallScript>();
                    WallObj.HP -= damage;
                    WallObj.click = true;

                    if(WallObj.HP <= 0) Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
