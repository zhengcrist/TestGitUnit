using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<EndAudio>().StopMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndGame()
    {
        ChangeScene.gamend = true;
        SceneManager.LoadScene("SCN_GameMenu");
    }
}
