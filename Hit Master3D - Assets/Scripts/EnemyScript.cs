using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    [Header("Float")]
    public float HP;
    private float startHP;
    [Header("Ragdoll")]
    public Rigidbody[] rbRagdoll;
    [Header("HealthBar")]
    public Slider healthBar;
    public GameObject HealthBar;

    NavMeshAgent navmesh;
    Animator anim;
    Vector3 oldPos;
    GameObject Player;
    // Start is called before the first frame update

    private void Awake() {
        for(int i = 0; i < rbRagdoll.Length; i++) {
            rbRagdoll[i].isKinematic = true;
        }
    }

    void Start()
    {
        navmesh = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        oldPos = this.transform.position;
        Player = GameObject.FindGameObjectWithTag("Player");
        startHP = HP;
    }

    // Update is called once per frame
    void Update()
    {
        if(oldPos != transform.position) {
            anim.Play("Run");
            oldPos = transform.position;
        }
        else if(oldPos == transform.position) anim.Play("Idle");

        if(HP <= 0) {
            PlayerScript script = Player.GetComponent<PlayerScript>();
            script.enemyes.Remove(this.gameObject);
            HealthBar.SetActive(false);
            Ragdoll();
        }
        else {
            healthBar.maxValue = startHP;
            healthBar.value = HP;
        }
    }

    public void Ragdoll() {
        anim.enabled = false;
        navmesh.enabled = false;
        for(int i = 0; i < rbRagdoll.Length; i++) {
            rbRagdoll[i].isKinematic = false;
        }
    }
}
