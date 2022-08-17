using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;
    public float damage;
    public float minY;
    public float maxY;
    
    void Start()
    {
        transform.rotation *= Quaternion.Euler(Random.Range(-2, 2), Random.Range(minY, maxY), 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Destroy(this.gameObject, 10);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.collider.tag == "Fortrees") {
            Destroy(this.gameObject);
        }
        Destroy(this.gameObject);
    }
}
