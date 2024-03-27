using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantTimer : MonoBehaviour
{
    [SerializeField] private GameObject Plant;

    [SerializeField] PlantCollision plant;

    // Update is called once per frame
    void Update()
    {
        // COUNT DOWN TIMER
        if (plant.CurrentTime > 0)
        {
            plant.CurrentTime -= 1 * Time.deltaTime;
            if (plant.CurrentTime <= 0)
            {
                Plant.SetActive(true);
            }
        }
    }
}
