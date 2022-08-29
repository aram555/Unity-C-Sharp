using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.AI;
using Photon.Pun;

public class EnemyMultiPlayerScript : MonoBehaviour
{
    [Header("Integers")]
    public float HP;
    public float speed;
    public float range;
    public float timer;
    public float newTimer;
    public float navMeshTimer;
    [Header("Bullet")]
    public Transform bulletPos;
    public GameObject bullet;
    GameObject Player;
    Transform targets;
    Transform points;
    public Transform Weapon;
    public VisualEffect particle;
    public VisualEffect teleportParticle;
    [Header("Fortrees")]
    public Transform fortrees;
    public float fortreesTimer;
    public float newFortreesTimer;
    [Header("Attack or Defense")]
    Transform point;
    bool inFortrees;
    NavMeshAgent navMesh;
    Animator anim;
    Vector3 oldPos;
    PhotonView view;
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        InvokeRepeating("UpdateTarget", 0.0f, 0.5f);
        navMesh = GetComponent<NavMeshAgent>();
        point = Points.points[Points.point];
        teleportParticle.Play();
        anim = GetComponent<Animator>();
        oldPos = this.transform.position;
    }

    public void UpdateTarget() {
        GameObject[] Enemyes = GameObject.FindGameObjectsWithTag("Player");
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

    public void UpdateFortrees() {
        GameObject[] Fortrees = GameObject.FindGameObjectsWithTag("Fortrees");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestFortrees = null;

        foreach(GameObject fortrees in Fortrees) {
            float distance = Vector3.Distance(transform.position, fortrees.transform.position);

            if(distance < shortestDistance) {
                shortestDistance = distance;
                nearestFortrees = fortrees;
            }
        }

        if(nearestFortrees != null && shortestDistance <= range) {
            fortrees = nearestFortrees.transform;
        }
        else {
            fortrees = null;
        }
    }

    public static Vector3 MoveToPoint(NavMeshAgent agent, Vector3 center, float radius) {
        var randDIrection = Random.insideUnitSphere * radius;
        randDIrection += center;
        NavMeshHit hit;
        NavMesh.SamplePosition(randDIrection, out hit, radius, -1);
        return hit.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(HP <= 0) {
            if(view.IsMine) {
                PhotonNetwork.Destroy(this.gameObject);
                return;
            }
        }

        points = Points.points[Points.point];
        
        navMeshTimer -= Time.deltaTime;
        if(navMeshTimer <= 0) {
            Vector3 newPosition = new Vector3(points.position.x, 0, points.position.z);
            navMeshTimer = 5;
            navMesh.SetDestination(MoveToPoint(navMesh, newPosition, 10));
        }

        if(oldPos != transform.position) {
            anim.Play("run");
            oldPos = transform.position;
        }
        else {
            anim.Play("Idle");
        }

        if(targets == null) {
            return;
        }

        if(Vector3.Distance(targets.position, transform.position) < range) {
            Vector3 direction = targets.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            Quaternion lookAtRotationY = Quaternion.Euler(transform.rotation.eulerAngles.x, lookRotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookAtRotationY, 10 * Time.fixedDeltaTime);

            timer -= Time.deltaTime;
            if(timer <= 0) {
                anim.Play("attack");
                timer = newTimer;
            }
        }

        if(targets != null && fortrees == null) {
            UpdateFortrees();
        }

        if(fortrees != null && inFortrees == false) {
            navMesh.SetDestination(fortrees.position);
        }
        else if(inFortrees == true) {
            navMesh.SetDestination(this.transform.position);
        }
    }

    public void Fire() {
        Instantiate(bullet, bulletPos.position, Weapon.rotation);
        if(particle != null) particle.Play();
    }

    public void Timer() {
        timer = newTimer;
    }

    private void OnCollisionEnter(Collision other) {
        if(other.collider.tag == "Fortrees") {
            inFortrees = true;
        }
        if(other.gameObject.name == "PlayerMachineGunBullet(Clone)" || other.gameObject.name == "PlayerRiflemanBullet(Clone)" || other.gameObject.name == "PlayerSniperBullet(Clone)" ||
        other.gameObject.name == "DefenseMachineGunBullet(Clone)" || other.gameObject.name == "DefenseRiflemanBullet(Clone)" || other.gameObject.name == "DefenseSniperBullet(Clone)") {
            float damage = other.gameObject.GetComponent<BulletScript>().damage;
            HP -= damage;
        }
    }
    private void OnCollisionExit(Collision other) {
        if(other.collider.tag == "Fortrees") {
            fortreesTimer -= Time.deltaTime;
            if(fortreesTimer <= 0) {
                fortreesTimer = newFortreesTimer;
                inFortrees = false;
            }
        }
    }
}
