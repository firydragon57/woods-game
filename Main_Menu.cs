using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour {

    public AudioSource src;

    public void PlayGame () {
        SceneManager.LoadScene(2);
    }
    
    public void BackToMenu() {
        SceneManager.LoadScene(1);
        src.Play();
    }

    public void QuitGame() {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void SkipButton() {
        SceneManager.LoadScene(3);
        src.Play();
    }
}
