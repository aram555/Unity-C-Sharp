using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    [Header("Floats")]
    public float HP;
    public float speed;
    public float fastSpeed;
    public float damage;
    public float distance;
    public int i = 0;
    [Header("Explosion")]
    public float explosionRadius;
    public float explosionForce;
    public GameObject ExplosionEffect;
    public bool isExplode;
    [Header("Target")]
    public Transform target;
    public Transform pointTarget;
    public LayerMask men;
    Animator anim;
    NavMeshAgent navMesh;
    Ray ray;
    Ray ray1;
    Ray ray2;
    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
        navMesh = GetComponent<NavMeshAgent>();
        pointTarget = PointsScript.points[i];
    }

    public void ExplodeDelay() {
        Invoke("Explode", 0.2f);
    }

    public void Explode() {
        if(isExplode) return;
        isExplode = true;
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        for(int i = 0; i < colliders.Length; i++) {
            Rigidbody rb = colliders[i].GetComponent<Rigidbody>();
            EnemyScript enemy = colliders[i].GetComponent<EnemyScript>();
            MenScript men = colliders[i].GetComponent<MenScript>();

            if(rb) rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);

            if(men) men.HP -= damage;

            if(enemy) {
                if(Vector3.Distance(transform.position, rb.position) < explosionRadius / 2f) {
                    enemy.ExplodeDelay();
                }
            }
        }
        Destroy(this.gameObject);
        Instantiate(ExplosionEffect, transform.position, Quaternion.Euler(-90, 0, 0));
        Destroy(ExplosionEffect, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null || pointTarget != null) anim.Play("Moveent");
        else anim.Play("Idle");

        ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));
        ray1 = new Ray(transform.position, transform.TransformDirection(Vector3.left));
        ray2 = new Ray(transform.position, transform.TransformDirection(Vector3.right));
        RaycastHit hit;
        RaycastHit hit1;
        RaycastHit hit2;

        if(Physics.Raycast(ray, out hit, distance)) {
            if(hit.collider.CompareTag("Men")) {
                target = hit.collider.gameObject.transform;
                pointTarget = null;
            }
        }
        if(Physics.Raycast(ray1, out hit1, distance)) {
            if(hit1.collider.CompareTag("Men")) {
                target = hit1.collider.gameObject.transform;
                pointTarget = null;
            }
        }
        if(Physics.Raycast(ray2, out hit2, distance)) {
            if(hit2.collider.CompareTag("Men")) {
                target = hit2.collider.gameObject.transform;
                pointTarget = null;
            }
        }

        if(pointTarget != null && target == null) {
            navMesh.SetDestination(pointTarget.position);
            if(Vector3.Distance(transform.position, pointTarget.position) <= 0.2f) {
                if(i >= PointsScript.points.Length) {
                    i = 0;
                    pointTarget = PointsScript.points[i];
                }
                else {
                    i++;
                    pointTarget = PointsScript.points[i];
                }
            }
        }

        if(HP <= 0) Destroy(this.gameObject);
        

        if(target != null) {
            navMesh.SetDestination(target.position);
            navMesh.speed = fastSpeed;
        }
        else if(pointTarget == null && target == null) pointTarget = PointsScript.points[i];
        else navMesh.speed = speed;
    }
}
