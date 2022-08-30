using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleGunScript : MonoBehaviour
{
    public float offset;

    public GameObject Bullet;
    public Transform ShotPoint;

    // Update is called once per frame
    void Update()
    {
        Vector3 defference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(defference.y, defference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(Bullet, ShotPoint.position, transform.rotation);
        }
    }
}
