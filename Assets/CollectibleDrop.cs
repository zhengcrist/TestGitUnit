using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleDrop : MonoBehaviour
{
    [SerializeField] Inventory_Script inventory;
    [SerializeField] private GameObject Collectible;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory_Script>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Collectible.tag == "Blue")
            {
                inventory.ToadNum++;
            }

            Destroy(this.gameObject);
        }
    }
}
