using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{
    public GameObject resourceManager;
    ResourcesScript script;
    // Start is called before the first frame update
    void Start()
    {
        script = resourceManager.GetComponent<ResourcesScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SelectLevel(int level) {
        SceneManager.LoadScene(level);
    }

    public void Quit() {
        Application.Quit();
    }

    public void BuildScript(GameObject building) {
        if(script) {
            if(script.wood >= 30 && script.rock >= 10) {
                script.wood -= 30;
                script.rock -= 10;
                Instantiate(building, transform.position, transform.rotation);
            }
            else return;
        }
    }
}