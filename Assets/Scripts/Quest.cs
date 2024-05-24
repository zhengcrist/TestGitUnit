using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quest : MonoBehaviour
{
    // icon
    [SerializeField] SpriteRenderer triangle;

    [SerializeField] private Default_Inputs default_Inputs;
    [SerializeField] TextMeshProUGUI interText;
    
    // showed texts
    [SerializeField] string[] text;
    [SerializeField] string[] quest;

    // necessary items
    [SerializeField] int heal;
    [SerializeField] int fire;
    [SerializeField] int ice;

    //rewards
    [SerializeField] int healreward;
    [SerializeField] int firereward;
    [SerializeField] int icereward;

    private bool available = false;

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
                Debug.Log("Pressed");

                StartCoroutine(interCoroutine());
            }
        }

        // Quest time
        if (available)
        {
            // if at least one needed item
            if ((Inventory_Script.MedNum > 0 || heal == 0) && (Inventory_Script.OilNum > 0 || fire == 0) && (Inventory_Script.ToadNum > 0 || ice == 0))
            {
                if (default_Inputs.P1.Interaction.WasPressedThisFrame())
                {
                    available = false;
                    // sub the quest items
                    Inventory_Script.MedNum -= heal;
                    Inventory_Script.OilNum -= fire;
                    Inventory_Script.ToadNum -= ice;

                    // if less than 0, put it back at 0
                    if (Inventory_Script.MedNum < 0)
                    {
                        Inventory_Script.MedNum = 0;
                    }
                    if (Inventory_Script.OilNum < 0)
                    {
                        Inventory_Script.OilNum = 0;
                    }
                    if (Inventory_Script.ToadNum < 0)
                    {
                        Inventory_Script.ToadNum = 0;
                    }

                    // reward coroutine
                    StartCoroutine(questCoroutine());
                }
                
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
        triangle.enabled = false;

        // first text
        int i = 0;
        while (i < text.Length)
        {
            interText.text = text[i];
            yield return new WaitForSeconds(1.2f);
            i++;
        }

        // QUEST
        if (MainMenu.gamepad)
        {
            interText.text = "Press [ L1 ] to help.";
        }
        else
        {
            interText.text = "Press [ F ] to help";
        }

        available = true;
        yield return new WaitForSeconds(3f);
        available = false;

    }

    IEnumerator questCoroutine()
    {
        // first text
        int i = 0;
        while (i < quest.Length)
        {
            interText.text = quest[i];
            yield return new WaitForSeconds(1.2f);
            i++;
        }

        // add the quest rewards
        Inventory_Script.MedNum += healreward;
        Inventory_Script.OilNum += firereward;
        Inventory_Script.ToadNum += icereward;

        triangle.enabled = true;

    }
}
