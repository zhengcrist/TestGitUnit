using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInventory_Script : MonoBehaviour
{
    [SerializeField] public bool ShowInventory;
    [SerializeField] private GameObject MainInventory;
    // Start is called before the first frame update
    void Start()
    {
        MainInventory.SetActive(false);
        ShowInventory = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) // when right arrow
        {
            if (!ShowInventory)
            {
                MainInventory.SetActive(false);
                ShowInventory = true;
            }
            else
            {
                MainInventory.SetActive(true);
                ShowInventory = false;
            }
        }
    }
}
