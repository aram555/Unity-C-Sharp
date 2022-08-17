using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public bool doMoving;
    public float speed;
    public float Border;
    public float scrollSpeed;
    public float maxY;
    public float minY;
    // Update is called once per frame
    void Update()
    {
        if(!doMoving) {
            return;
        }
        if(Input.GetKeyDown(KeyCode.Escape)) {
            doMoving = !doMoving;
        }

        if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - Border) {
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        }
        if(Input.GetKey("s") || Input.mousePosition.y <= Border) {
            transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
        }
        if(Input.GetKey("a") || Input.mousePosition.x >= Screen.width - Border) {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
        if(Input.GetKey("d") || Input.mousePosition.x <= Border) {
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxisRaw("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }
}
