using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turrets : MonoBehaviour
{
    [Header("Transforms")]
    public Transform Base;
    public Transform targets;
    public Transform FirePoint1;
    public Transform FirePoint2;
    [Header("Floats")]
    public float HP;
    public float range;
    public float damage;
    public float rotationSpeed;
    public float fireRate = 1f;
    private float fireCount = 0f;
    public EnemyScript Enemy;
    [Header("Bullet")]
    public GameObject bullet;
    TextScript MoneyText;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0.0f, 0.5f);
        MoneyText = GetComponent<TextScript>();
    }

    public void UpdateTarget() {
        GameObject[] Enemyes = GameObject.FindGameObjectsWithTag("EnemyTanks");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in Enemyes) {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if(distance < shortestDistance) {
                shortestDistance = distance;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range) {
            targets = nearestEnemy.transform;
        }
        else {
            targets = null;
        }
    }

    void Update()
    {
        if(targets == null) {
            return;
        }
        if(HP <= 0) {
            Destroy(gameObject);
        }
        Enemy = targets.GetComponent<EnemyScript>();

        Vector3 direction = targets.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, rotationSpeed * Time.fixedDeltaTime);

        if(fireCount <= 0) {
            GameObject bull1 = (GameObject) Instantiate(bullet, FirePoint1.position, transform.rotation);
            GameObject bull2 = (GameObject) Instantiate(bullet, FirePoint2.position, transform.rotation);
            BulletScript b1 = bull1.GetComponent<BulletScript>();
            BulletScript b2 = bull2.GetComponent<BulletScript>();

            if(b1 != null) {
                b1.Seek(targets, damage);
            }

            if(b2 != null) {
                b2.Seek(targets, damage);
            }

            fireCount = 1f / fireRate;
        }

        fireCount -= Time.deltaTime;
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
