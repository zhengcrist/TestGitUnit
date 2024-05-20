using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantCollision : MonoBehaviour
{
    // [SerializeField] Inventory_Script inventory;
    [SerializeField] private GameObject Plant;

    // TIMER
    [SerializeField] public float StartTime = 4f;
    [SerializeField] public float CurrentTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory_Script>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Plant.tag == "Green")
            {
                Inventory_Script.MedNum++;
            }
            if (Plant.tag == "Red")
            {
                Inventory_Script.OilNum++;
            }
            Plant.SetActive(false);
            CurrentTime = StartTime;
        }
    }
}
