using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryScript : MonoBehaviour
{
    [Header("Tank and Spawn Position")]
    public GameObject tankPrefab;
    public Transform tankSpawn;
    [Header("Timers")]
    public float timeOne;
    public float timeTwo;
    [Header("Moneys")]
    public int moneyCount;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObjects());
        GameObject gameManager = GameObject.FindGameObjectWithTag("GameManager");
        Moneys GM = gameManager.GetComponent<Moneys>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnObjects()
    {
        while(true) {
            yield return new WaitForSeconds(Random.Range(timeOne, timeTwo));
            Instantiate(tankPrefab, tankSpawn.position, transform.rotation);
        }
    }
}
