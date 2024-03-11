using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FireballPrefab_Script : MonoBehaviour
{

    [SerializeField] private float CurrentTime = 3f;
    [SerializeField] private float moveSpeed = 1f;

    [SerializeField] Animator Fireball_animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Rigidbody2D rigidbody;

    [SerializeField] SpriteRenderer sr;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        sr = GameObject.Find("Player_Dino").GetComponent<SpriteRenderer>();

        if (sr.flipX == true)
        {
            moveSpeed = -moveSpeed;
            spriteRenderer.flipX = true; // sprite flip
        }

        rigidbody.AddForce(new Vector2(moveSpeed, 2), ForceMode2D.Impulse);

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
        if (col.gameObject.name != "Player_Dino")
        {
            Destroy(gameObject);
        }
        Debug.Log("OnCollisionEnter2D");
    }



}
