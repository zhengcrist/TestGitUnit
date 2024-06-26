using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Light_flicker : MonoBehaviour
{
    // LIGHT
    public Light2D myLight;
    [SerializeField] private float intens = 8;

    // number of burn
    [SerializeField] private int ticksMax = 3;
    [SerializeField] private int ticks;
    private bool attacked = false;
    private bool lighton = false;
    // knockback
    [SerializeField] private float knockback;
    [SerializeField] private float knockbackx;

    // TIMER
    [SerializeField] float StartTime = 3;
    [SerializeField] float CurrentTime = 0f;

    // other scripts
    [SerializeField] Mob1_Script mob;
    [SerializeField] MobLife_Script Mob_1;


    // Start is called before the first frame update
    void Start()
    {
        // GET LIGHT
        myLight = GetComponent<Light2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (mob.isBurnt && CurrentTime <= 0)
        {
            // RESTART TIMER
            CurrentTime = StartTime;
            mob.isBurnt = false;
            ticks = ticksMax;
        }
        else if (CurrentTime <= 0 && ticks > 0)
        {
            // new dmg
            CurrentTime = StartTime;
            ticks--;
        }
        
        Timer();
    }

   
    private void Timer()
    {
        // if ((CurrentTime > 0 && CurrentTime < 0.1) || (CurrentTime > 1 && CurrentTime < 1.1) || (CurrentTime > 2 && CurrentTime < 2.1) )
        if ((CurrentTime > StartTime/2))
        {
            // LIGHT ON
            lighton = true;
            myLight.intensity = intens;
            // color
            mob.spriteRenderer.color = new Color(1, 0, 0, 1);
            

            // if first time on
            if (attacked == false)
            {
                // knockback
                if (mob.spriteRenderer.flipX == true)
                {
                    mob.rb.AddForce(new Vector2(-knockbackx, knockback), ForceMode2D.Impulse);
                }
                else
                {
                    mob.rb.AddForce(new Vector2(knockbackx, knockback), ForceMode2D.Impulse);
                }
               
                attacked = true;
                Mob_1.mobLife--;
            }
        }
        else
        {
            // LIGHT OFF
            if(lighton)
            {
                myLight.intensity = 0;
                mob.spriteRenderer.color = new Color(1, 1, 1, 1);
                attacked = false;
                lighton = false;
            }
            
        }

        // COUNT DOWN TIMER
        CurrentTime -= 1 * Time.deltaTime;

       
    }


}
