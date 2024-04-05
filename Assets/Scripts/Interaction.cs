using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Interaction : MonoBehaviour
{
    [SerializeField] SpriteRenderer triangle;

    [SerializeField] private Default_Inputs default_Inputs;
    [SerializeField] TextMeshProUGUI interText;

    // Start is called before the first frame update
    void Awake()
    {
        default_Inputs = new Default_Inputs();
    }

    // Update is called once per frame
    void Update()
    {
        if (triangle.color == new Color(1, 1, 1, 1))
        {
            if (default_Inputs.P1.Interaction.WasPressedThisFrame())
            {
                interText.text = "Hello world";
                Debug.Log("Pressed");
                StartCoroutine(interCoroutine());
            }
        }
    }

    public void OnEnable()
    {
        default_Inputs.P1.Enable();
    }

    public void OnDisable()
    {
        default_Inputs.P1.Disable();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if collision with player, player gets damage
        if (collision.gameObject.tag == "Player")
        {
            triangle.color = new Color(1, 1, 1, 1);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        triangle.color = new Color(1, 1, 1, 0);
    }

    IEnumerator interCoroutine()
    {
       
        yield return new WaitForSeconds(4f);
        interText.text = "";
    }
}
