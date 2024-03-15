using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI lifeCount;
    [SerializeField] Player_Script player;
    //[SerializeField] Movement_Mob1 mob = null;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Script>();
        // mob = GameObject.Find("Mob_1").Transform.Find("Mob1").GetComponent<Movement_Mob1>();

    }

    // Update is called once per frame
    void Update()
    {
       lifeCount.text = "Life : " + player.life.ToString();
    }
}
