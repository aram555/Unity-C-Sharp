using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseSoldiersBuild : MonoBehaviour
{
    public GameObject defenseSoldier;
    public LayerMask ground;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, ground)) {
            transform.position = hit.point;
        }
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            Instantiate(defenseSoldier, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
