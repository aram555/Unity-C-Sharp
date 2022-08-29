using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class EnemySpawnPoints : MonoBehaviour
{
    public Transform[] spawners;
    public GameObject[] enemySoldiers;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator EnemySpawn() {
        while(true) {
            yield return new WaitForSeconds(Random.Range(1f, 5f));
            int randomEnemy = Random.Range(0, enemySoldiers.Length);
            int rnadomPosition = Random.Range(0, spawners.Length);
            PhotonNetwork.Instantiate(enemySoldiers[randomEnemy].name, spawners[rnadomPosition].position, Quaternion.identity);
        }
    }
}
