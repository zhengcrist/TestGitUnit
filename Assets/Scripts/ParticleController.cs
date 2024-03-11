using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{

    [SerializeField] ParticleSystem movementParticle;

    [Range(0, 10)]
    [SerializeField] int occurAfterVelocity;

    [Range(0, 0.2f)]
    [SerializeField] float smokeFormationPeriod;

    [SerializeField] Rigidbody2D playerRb;

    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] SpriteRenderer sr;

    float counter;
    
    void Start()
    {
        sr = GameObject.Find("Player_Dino").GetComponent<SpriteRenderer>();
        if (sr.flipX == true)
        {
            spriteRenderer.flipX = true; // sprite flip
        }
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        
        if (Mathf.Abs(playerRb.velocity.x) > occurAfterVelocity)
        {
            Debug.Log("Velocity >");
            if (counter > smokeFormationPeriod)
            {
                movementParticle.Play();
                counter = 0;
            }
            
        }
        else if (Mathf.Abs(playerRb.velocity.x) < occurAfterVelocity)
        {
            movementParticle.Pause();

        }

    }
}
