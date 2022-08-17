using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Apollon")) {
            Destroy(gameObject);
            Debug.Log("+1");
            MoneyScript.Coins += 1;
        }
    }
}
