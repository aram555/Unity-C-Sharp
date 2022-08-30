using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    [Header("Float")]
    public float speed;
    private int WavePointIndex = 0;
    public float rotationSpeed;
    public float HP;
    public float enemyDamage;
    public float range;
    public float EnemyfireRate = 1f;
    private float EnemyfireCount = 0f;
    private Transform target;
    Rigidbody rb;
    Vector3 moveVector;
    [Header("Transform")]
    public Transform firePoint1;
    public Transform firePoint2;
    public Transform Tower;
    private Transform targets;
    public int Money;
    [Header("Bullet")]
    public GameObject EnemyTankBullet;
    private void Start() {
        target = WayPoints.points[0];
        rb = GetComponent<Rigidbody>();
        moveVector = new Vector3(0, 90, 0);
        InvokeRepeating("UpdateTargetTower", 0.0f, 0.5f);
    }

    public void UpdateTargetTower() {
        GameObject[] Enemyes = GameObject.FindGameObjectsWithTag("PlayerTowers");
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

    void FixedUpdate()
    {
        if(HP <= 0) {
            GameObject gameManager = GameObject.FindGameObjectWithTag("GameManager");
            Moneys GM = gameManager.GetComponent<Moneys>();
            GM.moneys += Money;
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, rotationSpeed * Time.fixedDeltaTime);
        
        
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.2f) {
            GetNextPoint();
        }

        if(targets == null) {
            return;
        }
        
        Vector3 towerdirection = targets.position - Tower.position;
        Quaternion towerlookRotation = Quaternion.LookRotation(towerdirection);
        Tower.rotation = Quaternion.Lerp(transform.rotation, towerlookRotation, rotationSpeed * Time.fixedDeltaTime);

        if(EnemyfireCount <= 0) {
            GameObject bull1 = (GameObject) Instantiate(EnemyTankBullet, firePoint1.position, transform.rotation);
            GameObject bull2 = (GameObject) Instantiate(EnemyTankBullet, firePoint2.position, transform.rotation);
            BulletScript b1 = bull1.GetComponent<BulletScript>();
            BulletScript b2 = bull2.GetComponent<BulletScript>();

            if(b1 != null) {
                b1.Seek(targets, enemyDamage);
            }

            if(b2 != null) {
                b2.Seek(targets, enemyDamage);
            }

            EnemyfireCount = 1f / EnemyfireRate;
        }

        EnemyfireCount -= Time.deltaTime;
    }

    void GetNextPoint() {
        if(WavePointIndex >= WayPoints.points.Length - 1) {
            Destroy(gameObject);
        }
        else {
            WavePointIndex++;
            target = WayPoints.points[WavePointIndex];
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, range);
    }
}