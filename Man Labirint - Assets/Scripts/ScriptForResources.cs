using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptForResources : MonoBehaviour
{
    public float woodCount;
    public float rockCount;
    public Slider healthBar;
    public GameObject[] foliage;
    public GameObject[] rocks;
    private float startWoobCount;
    private float startRockCount;
    private GameObject resourceManager;
    private ResourcesScript script;
    // Start is called before the first frame update
    void Start()
    {
        resourceManager = GameObject.FindGameObjectWithTag("GameScripts");
        script = resourceManager.GetComponent<ResourcesScript>();
        startWoobCount = woodCount;
        startRockCount = rockCount;
    }

    // Update is called once per frame
    void Update()
    {
        if(startWoobCount > 0) {
            healthBar.maxValue = startWoobCount;
            healthBar.value = woodCount;
        }
        else if(startRockCount > 0) {
            healthBar.maxValue = startRockCount;
            healthBar.value = rockCount;
        }

        if(woodCount <= 0 && rockCount <= 0) {
            Destroy(this.gameObject);
            if(startWoobCount > 0) Instantiate(foliage[Random.Range(0, foliage.Length - 1)], transform.position, Quaternion.identity);
            else if(startRockCount > 0) Instantiate(rocks[Random.Range(0, rocks.Length - 1)], transform.position, Quaternion.identity);
        }
    }

    private void OnDestroy() {
        script.wood += startWoobCount;
        script.rock += startRockCount;
    }
}
