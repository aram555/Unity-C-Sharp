using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] EnemyTanks;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    // Update is called once per frame
    IEnumerator SpawnObjects()
    {
        while(true) {
            yield return new WaitForSeconds(Random.Range(2f, 4f));
            Instantiate(EnemyTanks[Random.Range(0, EnemyTanks.Length - 1)], transform.position, transform.rotation);
        }
    }
}
