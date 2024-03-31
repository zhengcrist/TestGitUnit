using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowPV : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI lifeCount;
    [SerializeField] MobLife_Script mob;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeCount.text = mob.mobLife.ToString() + " PV";
    }
}
