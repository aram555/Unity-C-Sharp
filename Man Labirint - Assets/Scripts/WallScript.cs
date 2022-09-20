using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public float HP;
    public bool click;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(!click) anim.Play("Idle");
        else {
            anim.Play("Click");
        }
    }

    public void SetFalse() {
        click = false;
    } 
}
