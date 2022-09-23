using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [Header("Floats")]
    public float speed;
    public float lifeTime;
    public float damage;
    [Header("Direction")]
    public Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(direction);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        Destroy(this.gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.collider.tag == "Enemy") {
            other.gameObject.GetComponent<EnemyScript>().HP -= damage;
            Destroy(this.gameObject);
        }

        Destroy(this.gameObject);

    }
}
