using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class Timeline : MonoBehaviour
{

    [SerializeField] Canvas canvas;
    [SerializeField] PlayableDirector Cinematic;

    // Start is called before the first frame update
    void Start()
    {
        if (MainMenu.firstStart)
        {
            Cinematic.Play();
            Debug.Log(MainMenu.firstStart);
            MainMenu.firstStart = false;
            Debug.Log(MainMenu.firstStart);
        }
        else
        {
            canvas.enabled = false;
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
