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

    [SerializeField] SpriteRenderer sr;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        sr = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();

        if (sr.flipX == false)
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
            Destroy(this.gameObject);
        }
        Debug.Log("OnCollisionEnter2D");
    }



}
