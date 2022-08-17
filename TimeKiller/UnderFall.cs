using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderFall : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        if(other.collider.tag == "Player") {
            player.transform.position = new Vector3(15, 11, 5);
        }
    }
}
