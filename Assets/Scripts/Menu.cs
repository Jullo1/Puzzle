using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    AudioSource _audio;

    void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void GameStart()
    {
        SceneManager.LoadScene("Main");
    }

    public void Restart()
    {
        StartCoroutine(CallScene("Menu"));
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator CallScene(string sceneName)
    {
        _audio.Play();
        yield return new WaitForSeconds(0.235f);
        SceneManager.LoadScene(sceneName);
    }
}
