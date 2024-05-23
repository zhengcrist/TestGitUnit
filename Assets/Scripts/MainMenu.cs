using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class MainMenu : MonoBehaviour
{
    public static bool gamepad;
    public static bool firstStart = true;

    // music
    [SerializeField] AudioSource audioSource;
    public AudioClip Music_MainMenu;
    [SerializeField] float duration = 1.0f;
    [SerializeField] float targetVolume = 0f;

    // menu
    [SerializeField] TextMeshProUGUI Start;
    [SerializeField] TextMeshProUGUI Press;
    [SerializeField] float targetOpacity = 0f;
    [SerializeField] GameObject presstostart;

    // RIP
    public bool ShowSettings;
    [SerializeField] private GameObject Settings;
    [SerializeField] private GameObject Menu;

    void Awake()
    {
        // music
        audioSource.clip = Music_MainMenu;
        audioSource.Play();

        // anim = Press.GetComponent<Animator>();

        // RIP
        Settings.SetActive(false);
        ShowSettings = false;
        Menu.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartKeyboard()
    {
        // pass keyboard info
        gamepad = false;
        StartCoroutine(AudioMenu.StartFade(audioSource, duration, targetVolume));
        StartCoroutine(ChangeScene(duration));
        StartCoroutine(ButtonsFade(Start, duration, targetOpacity));
        presstostart.SetActive(false);

    }

    public void StartGamepad()
    {
        // pass gamepad info
        gamepad = true;
        StartCoroutine(AudioMenu.StartFade(audioSource, duration, targetVolume));
        StartCoroutine(ChangeScene(duration));
        StartCoroutine(ButtonsFade(Start, duration, targetOpacity));
        presstostart.SetActive(false);
    }

    IEnumerator ChangeScene(float duration)
    {
        yield return new WaitForSeconds(duration);
        if (GroundCheck_Script.lastCheckpointPosition.x < 252f)
        {
            SceneManager.LoadScene("Proto 1");
        }
        else
        {
            SceneManager.LoadScene("SCN_Game2");
        }

    }

    IEnumerator ButtonsFade(TextMeshProUGUI menu, float duration, float targetOpacity)
    {
        float currentTime = 0;
        Color text = menu.color;
        float alpha = text.a;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            text.a = Mathf.Lerp(alpha, targetOpacity, currentTime / duration);
            menu.color = text;
            yield return null;
        }
        yield break;

    }

    // ____________________ RIP _______________________

    public void ButtonStart()
    {
        SceneManager.LoadScene("Proto 1");
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
    // ___________________ !RIP _______________________

}
