using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePrintScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnSoldier(GameObject Soldier) {
        Instantiate(Soldier, transform.position, transform.rotation);
    }
}
