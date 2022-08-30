using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    RaycastHit hit;

    public GameObject Tower;

    private void Update() {
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)) {
            transform.position = hit.point;

            if(Input.GetMouseButton(0)) {
                Instantiate(Tower, transform.position, transform.rotation);
            }
        }
    }

    public void BuildTower(GameObject Tower) {
        Instantiate(Tower, transform.position, transform.rotation);
    }
}
