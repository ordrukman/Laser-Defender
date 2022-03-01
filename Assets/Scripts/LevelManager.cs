using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float sceneLoadDelay = 2f;
     ScoreKeeper scoreKeeper;

     void Awake() {
     }

    public void LoadGame() {
        // To make sure scoreKeeper will not be null!
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        scoreKeeper.ResetScore();
        SceneManager.LoadScene("Game");
    }

    public void LoadMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGameOver() {
        StartCoroutine(QuitAndLoad("GameOver", sceneLoadDelay));
    }

    public void QuitGame() {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    IEnumerator QuitAndLoad(string sceneName, float delay) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
