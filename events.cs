using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class events : MonoBehaviour
{
 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Replay()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
        //running.Play();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Pause()
    {
        //PlayerScript.pausepanel.SetActive(true);
        Time.timeScale = 0;
       // paused.Play();
    }
   public void Resume()
    {
       // PlayerScript.pausepanel.SetActive(false);
        Time.timeScale = 1;
       // running.Play();
    }
   public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
