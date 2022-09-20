using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesScript : MonoBehaviour
{
    public float wood;
    public float rock;
    public Text woodText;
    public Text rockText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        woodText.text = "Woods: " + wood.ToString();
        rockText.text = "Rocks: " + rock.ToString();
    }
}
