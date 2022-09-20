using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishScript : MonoBehaviour
{
    [Header("Integers")]
    public static int mensCount;
    public int finishMenCount;
    [Header("UI")]
    public Text MenCountText;
    public Text MenFinishCountText;
    public GameObject Defeat;
    public GameObject Victory;
    // Start is called before the first frame update
    void Start()
    {
        mensCount = GameObject.FindGameObjectsWithTag("Men").Length;
    }

    // Update is called once per frame
    void Update()
    {
        MenCountText.text = "Man`s Count " + mensCount.ToString();
        MenFinishCountText.text = "Man`s for Finish " + finishMenCount.ToString();

        if(mensCount <= 0 && mensCount < finishMenCount) Defeat.SetActive(true);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.collider.tag == "Men") {
            finishMenCount--;
            mensCount--;
            other.gameObject.SetActive(false);

            if(finishMenCount <= 0) Victory.SetActive(true);
            
        }
    }
}
