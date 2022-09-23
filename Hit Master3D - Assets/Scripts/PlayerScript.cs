using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    [Header("Point")]
    public Transform targat;
    public int point;
    [Header("EnemyFinder")]
    public bool findEnemyes;
    public GameObject enemyFinder;
    public float radius;
    public List<GameObject> enemyes = new List<GameObject>();
    [Header("Shoot")]
    public GameObject weapon;
    public GameObject bullet;
    public Transform shotPos;
    public float bulletSpeed;

    NavMeshAgent navMesh;
    Animator anim;
    Vector3 oldPos;
    Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        targat = PointsScript.points[point];
        oldPos = this.transform.position;
        findEnemyes = true;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(oldPos != transform.position) {
            anim.Play("Run");
            oldPos = transform.position;
        }
        else if(oldPos == transform.position) anim.Play("Idle");

        if(Vector3.Distance(transform.position, targat.position) >= 1f) 
            navMesh.SetDestination(targat.position);
        else if(Vector3.Distance(transform.position, targat.position) <= 1f) {
            if(findEnemyes) {
                FindEnemyes();
                findEnemyes = false;
            }

            if(enemyes.Count <= 0) {
                point++;
                targat = PointsScript.points[point];
            }
        }

        if(Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit, Mathf.Infinity)) {
                anim.Play("Fire");
                Vector3 targetPos = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                transform.LookAt(targetPos);

                GameObject bull = (GameObject) Instantiate(bullet, shotPos.position, transform.rotation);
                bull.GetComponent<BulletScript>().direction = targetPos;
            }
        }

        if(point >= PointsScript.points.Length - 1) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void FindEnemyes() {
        findEnemyes = false;

        enemyFinder.transform.position = PointsScript.points[point + 1].position;
        Collider[] colliders = Physics.OverlapSphere(enemyFinder.transform.position, radius);
        for(int i = 0; i < colliders.Length; i++) {
            EnemyScript enemy = colliders[i].GetComponent<EnemyScript>();

            if(enemy) {
                if(enemy.HP > 0) enemyes.Add(enemy.gameObject);
                else if(enemy.HP <= 0) enemyes.Remove(enemy.gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.collider.tag == "Target") {
            findEnemyes = true;
        }
    }

    private void OnCollisionExit(Collision other) {
        if(other.collider.tag == "Target")
            findEnemyes = true;
    }
}
