using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Return the current Active Scene in order to get the current Scene name.
        Scene scene = SceneManager.GetActiveScene();

        if (collision.CompareTag("Player"))
        {
            if (scene.name == "Proto1")
            {

                SceneManager.LoadScene("SCN_Game2");
            }
            else if (scene.name == "SCN_Game2")
            {
                SceneManager.LoadScene("SCN_GameFinal");
            }
        }
    }
}
