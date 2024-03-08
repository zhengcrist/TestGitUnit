using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{

    // [SerializeField] Animator Player_animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] float speed = 0.7f;

    [SerializeField] Transform FireballSpawnPoint;
    [SerializeField] GameObject FireballPrefab;
    // [SerializeField] float FireballSpeed = 1.5f;

    bool Player_Run;

    // Start is called before the first frame update
    void Start()
    {
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        // Skills();
    }

    void Move()
    { // move


        if (Input.GetKey(KeyCode.RightArrow)) // when right arrow
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);  // movement to the right
            // Player_animator.SetBool("BoolMove", true); // run animation
            spriteRenderer.flipX = true; // sprite not flipped
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            // Player_animator.SetBool("BoolMove", false); // stop run animation
        }

        if (Input.GetKey(KeyCode.LeftArrow)) // when left arrow
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);  // movement to the left
            // Player_animator.SetBool("BoolMove", true); // run animation
            spriteRenderer.flipX = false; // sprite flip
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            // Player_animator.SetBool("BoolMove", false); // stop run animation
        }


    }

    void Skills()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // when keypad 1
        {
            // Player_animator.SetTrigger("TriggerAttack"); // attack animation
            var fireball = Instantiate(FireballPrefab, FireballSpawnPoint.position, FireballSpawnPoint.rotation);
        }


    }
}