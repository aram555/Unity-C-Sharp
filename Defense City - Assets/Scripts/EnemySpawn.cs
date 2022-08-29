using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public Transform[] spawners;
    public GameObject[] enemySoldiers;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator EnemySpawner() {
        while(true) {
            yield return new WaitForSeconds(Random.Range(1f, 5f));
            int randomEnemy = Random.Range(0, enemySoldiers.Length);
            int rnadomPosition = Random.Range(0, spawners.Length);
            Instantiate(enemySoldiers[randomEnemy], spawners[rnadomPosition].position, Quaternion.identity);
        }
    }
}
