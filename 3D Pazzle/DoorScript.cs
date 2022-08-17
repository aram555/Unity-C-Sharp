using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject door;
    public float speed;
    private float _speed;
    public Vector3 direction;
    public bool ok;
    // Start is called before the first frame update
    void Start()
    {
        _speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (ok)
        {
            speed -= Time.deltaTime;
            door.transform.Translate(direction * speed * Time.deltaTime);
            transform.position += new Vector3(0, -1, 0);
            if(speed <= 0) {
                ok = false;
                speed = _speed;
                direction = new Vector3(0, 0, 0);
            }
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.collider.tag == "Player") {
            ok = true;
        }
    }
}
