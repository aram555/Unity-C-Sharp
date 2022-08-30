using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatScript : MonoBehaviour
{
    public GameObject Defeat;

    private void Start() {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Ball") && this.gameObject.name != "Ball(Clone)") {
            if(other.gameObject.GetComponent<DefeatScript>().enabled == true) {
                Defeat.SetActive(true);
            }
        }
    }
}
