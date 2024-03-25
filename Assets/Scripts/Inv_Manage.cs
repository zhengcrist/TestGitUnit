using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inv_Manage : MonoBehaviour
{
    [SerializeField] Inventory_Script inventory;


    [SerializeField] TextMeshProUGUI medText;
    [SerializeField] TextMeshProUGUI oilText;
    [SerializeField] TextMeshProUGUI toadText;

    // Update is called once per frame
    void Update()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory_Script>();

        PrintText();
    }

    void PrintText()
    {
        medText.text = inventory.MedNum.ToString();
        oilText.text = inventory.OilNum.ToString();
        toadText.text = inventory.ToadNum.ToString();
    }
}
