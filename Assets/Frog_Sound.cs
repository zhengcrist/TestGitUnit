using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog_Sound : MonoBehaviour
{
    [SerializeField] AudioSource Source;

    [SerializeField] AudioClip Frog;

    // Start is called before the first frame update
    void Start()
    {
        Source.clip = Frog;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Source.Play();
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Source.Stop();
        }
    }
}
