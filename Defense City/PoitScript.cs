using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoitScript : MonoBehaviour
{
    public GameObject spawnpositin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Points.points[Points.point].position;
        spawnpositin.transform.position = this.transform.position;
    }
}
