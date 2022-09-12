using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void LoadGame()
    {
        ScoreKeeper.instance.ResetScore();
        StartCoroutine(WaitAndLoad(1));
    }

    public void LoadMainMenu()
    {
        StartCoroutine(WaitAndLoad(0));
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad(2));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator WaitAndLoad(int index)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(index);
    }

}
