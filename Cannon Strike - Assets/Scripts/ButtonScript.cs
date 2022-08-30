using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public AudioSource BackGroundMusic;
    public bool isOn;
    // Start is called before the first frame update
    void Start()
    {
        isOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void NextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Menu() {
        SceneManager.LoadScene(0);
    }

    public void LoadLevel(int Level) {
        SceneManager.LoadScene(Level);
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void Music() {
        if(!isOn) {
            BackGroundMusic.Play();
            isOn = true;
        }
        else if(isOn) {
            BackGroundMusic.Stop();
            isOn = false;
        }
    }
}
