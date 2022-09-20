using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MenScript : MonoBehaviour
{
    public float HP;
    private float startHP;
    public Transform target;
    public GameObject healthBar;
    Animator anim;
    NavMeshAgent navMesh;
    NavMeshPath path;
    Vector3 oldPos;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
        navMesh = GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
        oldPos = this.transform.position;
        cam = Camera.main;
        startHP = HP;
    }

    // Update is called once per frame
    void Update()
    {
        if(HP <= 0) Destroy(this.gameObject);
        else {
            healthBar.GetComponent<Slider>().maxValue = startHP;
            healthBar.GetComponent<Slider>().value = HP;
        }

        
        if(path.status == NavMeshPathStatus.PathComplete && target != null) {
            anim.Play("Movement");
            oldPos = transform.position;
        }
        else if(path.status != NavMeshPathStatus.PathComplete && target == null) {
            anim.Play("Idle");
        }

        if(Input.GetMouseButton(0)) {
            RaycastHit hit;
            if(Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity)) {
                if(hit.collider.gameObject.tag == "GoHere" || hit.collider.gameObject.tag == "Enviroment" || hit.collider.gameObject.tag == "Finish") {
                    target = null;
                    target = hit.collider.gameObject.transform;
                }
            }
        }

        if(target.gameObject.tag == "Enviroment" && Vector3.Distance(transform.position, target.position) <= 1f) {
            ScriptForResources script = target.GetComponent<ScriptForResources>();
            if(script.woodCount > 0) script.woodCount -= 0.01f;
            else if(script.rockCount > 0) script.rockCount -= 0.01f;
        }

        if(target != null) {
            if(navMesh.CalculatePath(target.position, path) && path.status == NavMeshPathStatus.PathComplete) {
                navMesh.SetPath(path);
            }
            else return;
        }
    }

    private void OnDestroy() {
        FinishScript.mensCount--;
    }

    private void OnCollisionEnter(Collision other) {
        if(other.collider.tag == "Enemy") {
            other.gameObject.GetComponent<EnemyScript>().Explode();
            HP -= other.gameObject.GetComponent<EnemyScript>().damage;
            Destroy(other.gameObject);
        }
        if(other.collider.tag == "GoHere") {
            if(other.collider.gameObject.GetComponent<GoToScript>().goToTarget) target = GameObject.FindGameObjectWithTag("Finish").transform;
            else target = null;
        }
    }
}
