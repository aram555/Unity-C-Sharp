using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonScenes : MonoBehaviour
{
    public void ChangeScene(int Membemscene)
    {
        SceneManager.LoadScene(Membemscene);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale += 1;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
