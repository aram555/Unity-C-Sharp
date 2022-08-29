using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using Photon.Pun;

public class PlayerSoldierMultyplayerScript : MonoBehaviour
{[Header("Integers")]
    public float HP;
    public float speed;
    public float timer;
    public float newTimer;
    [Header("Weapon and Bullet")]
    public GameObject bullet;
    public VisualEffect particle;
    public Transform bulletPos;
    public Transform Weapon;
    Vector3 rayPoint;
    RaycastHit hit;
    Animator anim;
    Vector3 oldPos;
    //Photon
    PhotonView view;
    public GameObject camera;
    public Camera playerCamera;
    public PlayerSoldierMultyplayerScript script;
    public WeaponRotateMultyPlayer weaponRotate;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        oldPos = this.transform.position;
        view = GetComponent<PhotonView>();

        if(!view.IsMine) {
            camera.SetActive(false);
            script.enabled = false;
            weaponRotate.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(HP <= 0) {
            PhotonNetwork.Destroy(camera);
            PhotonNetwork.Destroy(this.gameObject.transform.parent.gameObject);
        }

        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Ground")))
        {
            transform.LookAt(hit.point);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }

        if(oldPos != transform.position) {
            if(Input.GetKey(KeyCode.Mouse0)) {
                anim.Play("attack");
            }
            else {
                anim.Play("run");
                oldPos = transform.position;
            }
        }
        else {
            if(Input.GetKey(KeyCode.Mouse0)) {
                anim.Play("attack");
            }
            else {
                anim.Play("Idle");
            }
        }

        if(Input.GetKey(KeyCode.W)) {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.S)) {
            transform.Translate(-Vector3.forward * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.A)) {
            transform.Translate(-Vector3.right * speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D)) {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    public void Timer() {
        timer = newTimer;
    }
    public void Fire() {
        Instantiate(bullet, bulletPos.position, Weapon.rotation);
        if(particle != null) particle.Play();
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.name == "EnemyMachineGunBullet(Clone)" || other.gameObject.name == "EnemyRiflemanBullet(Clone)" || other.gameObject.name == "EnemySniperBullet(Clone)") {
            float damage = other.gameObject.GetComponent<BulletScript>().damage;
            HP -= damage;
        }
    }
}
