using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobLife_Script : MonoBehaviour, IDamageable
{

    public int mobLife;
    public int mobMaxLife;
    [SerializeField] SpriteRenderer SR; // mob sprite renderer

    // ALICE
    [SerializeField] Alice_Script Alice;
    // PLAYER
    [SerializeField] Player_Script1 player;

    // Audio
    [SerializeField] AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        mobLife = mobMaxLife;
    }

    void Update()
    {
        if (player.life <= 0)
        {
            mobLife = mobMaxLife;
        }
    }

    public void Damage(int damageAmount)
    {
        mobLife -= damageAmount;
        StartCoroutine(mobDMG());
        if(transform.CompareTag("Frog"))
        {
            audioManager.PlaySFX(audioManager.SFX_Frog);
        }
        else if(transform.CompareTag("Alice"))
        {
            audioManager.PlaySFX(audioManager.SFX_Alice);
            if(Alice._currentWaypointIndex < Alice._waypoints.Length-1)
            {
                Alice._currentWaypointIndex++;
            }
            else
            {
                Alice._currentWaypointIndex = 0;
            }
        }
    }

    IEnumerator mobDMG()
    {
        
        // mob color
        SR.color = new Color(1, 0, 0, 1); // change mob to red
        yield return new WaitForSeconds(0.5f);
        SR.color = new Color(1, 1, 1, 1); // reset color
    }
}
