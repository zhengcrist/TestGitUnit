using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lifebar : MonoBehaviour
{
    [SerializeField] Player_Script1 player;

    public Image healthBar;
    public float healthQuantity;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Pourcentage();
    }

    public void Pourcentage()
    {
        healthQuantity = (float)player.life / (float)player.maxlife;
        healthBar.fillAmount = healthQuantity;
    }
    
}
