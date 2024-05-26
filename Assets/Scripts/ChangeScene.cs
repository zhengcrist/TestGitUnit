using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ChangeScene : MonoBehaviour
{
    public static bool gamend = false;

    [SerializeField] TextMeshProUGUI tmptext;
    [SerializeField] bool returnscn = false;

    [SerializeField] private Transform LastCheckpoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Return the current Active Scene in order to get the current Scene name.
        Scene scene = SceneManager.GetActiveScene();

        if (collision.CompareTag("Player"))
        {
            if (scene.name == "Proto 1")
            {

                SceneManager.LoadScene("SCN_Game2");
            }
            else if (scene.name == "SCN_Game2")
            {
                if(returnscn) {
                    GroundCheck_Script.lastCheckpointPosition = LastCheckpoint.position;
                    SceneManager.LoadScene("SCN_Proto 1");
                }
                else
                {
                    if (!gamend)
                    {
                        if ((Inventory_Script.MedNum > 0) && (Inventory_Script.OilNum > 0) && (Inventory_Script.ToadNum > 0))
                        {
                            SceneManager.LoadScene("SCN_GameFinal");
                        }
                        else
                        {
                            tmptext.text = "I should gather enough ingredients before.";
                        }
                    }
                    else { tmptext.text = "Unfortunately, I don't think I can do anything for Vincent..."; }
                    
                }
                
            }
            
        }
    }
}
