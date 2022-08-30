using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletScript : MonoBehaviour
{
    private Transform target;
    private float damage;
    public float speed;
    public GameObject GoParticle;
    public GameObject HitParticle;
    Turrets turet = new Turrets();
    EnemyScript enemy = new EnemyScript();

    public void Seek(Transform _target, float _damage) {
        target = _target;
        damage = _damage;
    }

    void Update() {
        Instantiate(GoParticle, transform.position, transform.rotation);
        if(target == null) {
            Instantiate(HitParticle, transform.position, transform.rotation);
            Destroy(gameObject);
            return;
        }
        
        Vector3 dir = target.position - transform.position;
        float distance = speed * Time.deltaTime;

        if(dir.magnitude <= distance) {
            if(target.tag == "EnemyTanks") {
                Instantiate(HitParticle, transform.position, transform.rotation);
                EnemyScript enemy = target.GetComponent<EnemyScript>();
                enemy.HP -= damage;
                Destroy(gameObject);
                return;
            }
            else if(target.tag == "PlayerTowers") {
                Instantiate(HitParticle, transform.position, transform.rotation);
                Turrets turets = target.GetComponent<Turrets>();
                turets.HP -= turets.damage;
                Destroy(gameObject);
                return;
            }
            
        }

        Vector3 targetpos = target.position;

        transform.position = Vector3.MoveTowards(transform.position, targetpos, speed * Time.deltaTime);
    }
}