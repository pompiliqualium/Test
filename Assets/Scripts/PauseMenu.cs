using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    private bool paused = false;

    private void Start() {
        pauseMenu.SetActive(false);
    }

    private void Update() {


        if(Input.GetButtonDown("Pause")) {
            paused=!paused;
        }

        if(paused) {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }

        if(!paused) {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }


    }

    public void Resume() {
        paused = false;
    }

    public void Quit() {
        Application.Quit();
    }

    public void Restart() {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("TestLevel");
    }

    public void MainMenu() {
        SceneManager.LoadScene(0);
    }


}
