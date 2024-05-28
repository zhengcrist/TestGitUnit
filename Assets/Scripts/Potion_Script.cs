using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Potion_Script : MonoBehaviour
{

    [SerializeField] private float CurrentTime = 3f;
    [SerializeField] private float moveSpeedX; 
    [SerializeField] private float moveSpeedY;


    [SerializeField] Animator Fireball_animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] new Rigidbody2D rigidbody;

    [SerializeField] Player_Script1 player;

    // Audio
    [SerializeField] AudioManager audioManager;


    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();


        rigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Script1>();

        if (player.flip == true)
        {
            moveSpeedX = -moveSpeedX;
            spriteRenderer.flipX = true; // sprite flip
        }

        rigidbody.AddForce(new Vector2(moveSpeedX, moveSpeedY), ForceMode2D.Impulse);

        Timer();

    }

  

    void Timer()
    {
        CurrentTime -= 1 * Time.deltaTime;
        if (CurrentTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag != "Player" && col.gameObject.tag != "Green" && col.gameObject.tag != "Red" && col.gameObject.tag != "Blue")
        {
            audioManager.PlaySFX(audioManager.SFX_Glass);
            Destroy(this.gameObject);
        }
        Debug.Log("OnCollisionEnter2D");
    }



}
