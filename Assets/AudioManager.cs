using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------------Audio Source------------")]
    [SerializeField] AudioSource RunSource;
    [SerializeField] AudioSource SFXSource;

    [Header("------------Audio Clip------------")]
    public AudioClip SFX_Run;
    public AudioClip SFX_Land;
    public AudioClip SFX_Attack;
    public AudioClip SFX_Drink;
    public AudioClip SFX_Throw;
    public AudioClip SFX_Glass;
    public AudioClip SFX_Sparkle;
    // Mobs
    public AudioClip SFX_Wolf;
    public AudioClip SFX_Alice;

    public static AudioManager instance;

    // Start is called before the first frame update
    void Start()
    {
        RunSource.clip = SFX_Run;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayRun()
    {
        RunSource.Play();
    }

    public void StopRun()
    {
        RunSource.Stop();
    }


    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
