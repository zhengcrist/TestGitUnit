using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMenu : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    public AudioClip Music_MainMenu;

    // Start is called before the first frame update
    private void Awake()
    {
        musicSource.clip = Music_MainMenu;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
