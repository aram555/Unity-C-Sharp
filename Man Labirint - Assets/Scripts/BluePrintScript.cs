using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BluePrintScript : MonoBehaviour
{
    public NavMeshSurface[] surface;
    public LayerMask ground;
    public GameObject building;
    private GameObject navmesh;
    private NavMeshSurface navMeshSurface;
    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        navmesh = GameObject.Find("NavMeshSurface");
        navMeshSurface = navmesh.GetComponent<NavMeshSurface>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Q)) transform.Rotate(0, -1, 0);
        if(Input.GetKey(KeyCode.E)) transform.Rotate(0, 1, 0);

        RaycastHit hit;
        if(Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, ground)) {
            transform.position = hit.point;
            if(Input.GetMouseButtonDown(0)) {
                Instantiate(building, transform.position, transform.rotation);
                navMeshSurface.BuildNavMesh();
                Destroy(this.gameObject);
            }
        }
    }
}
