using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alice_start : MonoBehaviour
{
    [SerializeField] MobLife_Script Mob_1; // for mob life
    private int max;

    // Start is called before the first frame update
    void Awake()
    {
        max = minFunct();
        useMax(max);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int minFunct()
    {
        int min;

        // trouver min entre heal et fire
        if(Inventory_Script.MedNum < Inventory_Script.OilNum)
        {
            min = Inventory_Script.MedNum; 
        }
        else
        {
            min = Inventory_Script.OilNum;
        }

        // trouver le min entre min et ice
        if (min > Inventory_Script.ToadNum)
        {
            min = Inventory_Script.ToadNum;
        }

        return min;
    }

    void useMax(int max)
    {
        Inventory_Script.MedNum -= max;
        Inventory_Script.OilNum -= max;
        Inventory_Script.ToadNum -= max;

        Mob_1.mobLife -= max;
        if (Mob_1.mobLife < 10)
        {
            Mob_1.mobLife = 10;
        }
    }
}
