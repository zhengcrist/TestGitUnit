using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowPV : MonoBehaviour
{
    [SerializeField] MobLife_Script mob;


    public Image healthBar;
    public float healthQuantity;

    // Start is called before the first frame update
    void Start()
    {
        Pourcentage();
    }

    // Update is called once per frame
    void Update()
    {
        Pourcentage();
    }

    public void Pourcentage()
    {
        healthQuantity = (float)mob.mobLife / (float)mob.mobMaxLife;
        healthBar.fillAmount = healthQuantity;
    }
}
