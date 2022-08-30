using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public GameObject[] turrets;
    public Color renderColor;
    private Color thisColor;
    private Renderer render;
    private GameObject turret;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
        thisColor = render.material.color;
    }
    private void OnMouseEnter() {
        render.material.color = renderColor;
    }
    private void OnMouseExit() {
        render.material.color = thisColor;
    }
}
