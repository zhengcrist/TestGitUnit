using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Wold_Trigger : MonoBehaviour
{
    public float cooldown = 20f;
    [SerializeField] private bool wolfTrigger = true;
    [SerializeField] private GameObject wolf;

    [SerializeField] private UnityEngine.Rendering.Volume volume;
    [SerializeField] float duration = 3.0f;
    [SerializeField] float targetVolume = 1f;

    // Audio
    [SerializeField] AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && wolfTrigger)
        {
            audioManager.PlaySFX(audioManager.SFX_Wolf);
            StartCoroutine(Vignette(duration, targetVolume));
            StartCoroutine(Cooldown(cooldown));
            Vector3 vectPlayer = col.transform.position;
            Vector3 vectPos = new Vector3(vectPlayer.x + 25f, vectPlayer.y - 0.5f, 0f);
            var wolfSpawn = Instantiate(wolf, vectPos, transform.localRotation);
        }
        Debug.Log("OnTriggerEnter2D");
    }


    IEnumerator Cooldown(float cooldown)
    {
        wolfTrigger = false;
        yield return new WaitForSeconds(cooldown);
        wolfTrigger = true;
    }

    IEnumerator Vignette(float duration, float targetOpacity)
    {
        float currentTime = 0;
        while (currentTime < duration*2/3)
        {
            currentTime += Time.deltaTime;
            float alpha = volume.weight;
            volume.weight = Mathf.Lerp(alpha, targetOpacity, currentTime / duration);
            yield return null;
        }
        while ((duration*2/3 < currentTime) && (currentTime < duration))
        {
            currentTime += Time.deltaTime;
            float alpha = volume.weight;
            volume.weight = Mathf.Lerp(alpha, 0, currentTime / duration);
            yield return null;
        }
        yield break;

    }
}
