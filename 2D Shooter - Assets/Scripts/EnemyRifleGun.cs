using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRifleGun : MonoBehaviour
{
    public GameObject player;
    public float offset;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x > transform.position.x)
        {
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }
        
    }
}
