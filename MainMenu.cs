using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject MenuPanel;
    public GameObject OptionsPanel;
    public AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        MenuPanel.SetActive(true);
        OptionsPanel.SetActive(false);
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }
    public void Quitgame()
    {
        Application.Quit();
    }
    public void ToOptions()
    {
        MenuPanel.SetActive(false);
        OptionsPanel.SetActive(true);
    }
    public void FromOptions()
    {
       OptionsPanel.SetActive(false);
        MenuPanel.SetActive(true);
    }
}
