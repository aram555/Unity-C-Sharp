using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotateMultyPlayer : MonoBehaviour
{
    public Camera playerCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Ground")))
        {
            transform.LookAt(hit.point);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
    }
}
