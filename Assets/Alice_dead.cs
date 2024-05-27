using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Alice_dead : MonoBehaviour
{

    // icon
    [SerializeField] SpriteRenderer triangle;
    [SerializeField] private Default_Inputs default_Inputs;
    [SerializeField] TextMeshProUGUI interText;
    private bool available = false;


    // Start is called before the first frame update
    void Awake()
    {
         default_Inputs = new Default_Inputs();
    }
    public void OnEnable()
    {
        default_Inputs.P1.Enable();
    }

    public void OnDisable()
    {
        default_Inputs.P1.Disable();
    }


    // Update is called once per frame
    void Update()
    {
        // INTERACTION
        if (triangle.color == new Color(1, 1, 1, 1))
        {
            if (default_Inputs.P1.Interaction.WasPressedThisFrame())
            {
                Debug.Log("Pressed");

                StartCoroutine(interCoroutine());


            }
        }
        // Quest time
        if (available)
        {
            // if accepted
            if (default_Inputs.P1.Interaction.WasPressedThisFrame())
            {
                available = false;
                interText.text = "";

                // load next scene
                SceneManager.LoadScene("SCN_GameEnd");

            }
        }


     

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       

        if (collision.gameObject.CompareTag("Player"))
        {
             triangle.color = new Color(1, 1, 1, 1);
            
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
       

        if (collision.gameObject.CompareTag("Player"))
        {
            
             triangle.color = new Color(1, 1, 1, 0);
            
        }
    }

    IEnumerator interCoroutine()
    {
        triangle.enabled = false;

       
        if (MainMenu.gamepad)
        {
            interText.text = "Press [ L1 ] to give the final blow.";
        }
        else
        {
            interText.text = "Press [ F ] to give the final blow.";
        }

        available = true;
        yield return new WaitForSeconds(6f);
        available = false;
        interText.text = "";

        yield return new WaitForSeconds(5f);
        triangle.enabled = true;

    }

}
