using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inv_Manage : MonoBehaviour
{
    // [SerializeField] Inventory_Script inventory;


    [SerializeField] TextMeshProUGUI medText;
    [SerializeField] TextMeshProUGUI oilText;
    [SerializeField] TextMeshProUGUI toadText;

    // Update is called once per frame
    void Update()
    {
        // inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory_Script>();

        PrintText();
    }

    void PrintText()
    {
        medText.text = Inventory_Script.MedNum.ToString();
        oilText.text = Inventory_Script.OilNum.ToString();
        toadText.text = Inventory_Script.ToadNum.ToString();
    }
}
