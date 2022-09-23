using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform Player;

    PlayerScript script;
    // Start is called before the first frame update
    void Start()
    {
        script = Player.GetComponent<PlayerScript>();
    }
    // Update is called once per frame
    private void LateUpdate() {
        transform.position = Player.position;
        transform.LookAt(script.enemyFinder.transform.position);
    }
}
