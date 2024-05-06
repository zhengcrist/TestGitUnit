using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public bool ShowSettings;
    [SerializeField] private GameObject Settings;

    [SerializeField] private GameObject Menu;

    void Awake()
    {
        Settings.SetActive(false);
        ShowSettings = false;
        Menu.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonStart()
    {
        SceneManager.LoadScene("SCN_GameTuto");
    }

    public void ButtonSettings()
    {
        ShowSettings = true;
        Settings.SetActive(true);
        Menu.SetActive(false);
    }
    public void ButtonBack()
    {
        ShowSettings = false;
        Settings.SetActive(false);
        Menu.SetActive(true);
    }

    public void ButtonExit()
    {
        Application.Quit();
    }

    
}
