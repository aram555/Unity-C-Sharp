using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpScript : MonoBehaviour {
    
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Jump")) {
            
        }
    }
}
