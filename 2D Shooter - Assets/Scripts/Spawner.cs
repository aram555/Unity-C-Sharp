using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemyes;
    public Transform SpawnPoint;

    public float First;
    public float Second;
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(First, Second));
            Instantiate(Enemyes, SpawnPoint.position, transform.rotation);
        }
    }
}
