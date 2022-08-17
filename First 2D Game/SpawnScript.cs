using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public float time;
    public GameObject Edem;

    // Update is called once per frame
    void Update()
    {
        time--;
        if(time == 0)
        {
            Instantiate(Edem, transform.position, Quaternion.identity);
            time = 100f;
        }
    }
}
