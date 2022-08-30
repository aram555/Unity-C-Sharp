using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{

    public GameObject Ball;
    public GameObject healthBall;
    public Transform[] Spawners;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
        StartCoroutine(SpawnHealthBall());
    }

    // Update is called once per frame
    private IEnumerator Spawn()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 2f));
            Instantiate(Ball, Spawners[Random.Range(0, Spawners.Length)].position, Quaternion.identity);
        }
    }

    private IEnumerator SpawnHealthBall()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(5f, 10f));
            Instantiate(healthBall, Spawners[Random.Range(0, Spawners.Length)].position, Quaternion.identity);
        }
    }
}
