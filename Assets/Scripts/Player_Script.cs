using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{

    // [SerializeField] Animator Player_animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] new Rigidbody2D rigidbody;
    // [SerializeField] private float horizontal;
    [SerializeField] private float speed;

    [SerializeField] Transform FireballSpawnPoint;
    // [SerializeField] float FireballSpawnPointX;

    [SerializeField] private GameObject[] potions; // array of potions
    [SerializeField] private GameObject potion;
    [SerializeField] private int currentPotion = 0;

    // private bool Player_Run;
    [SerializeField] private float jump;
    [SerializeField] public int life;
    [SerializeField] private int maxlife;



    // Start is called before the first frame update
    void Start()
    {
        life = maxlife;

        potion = potions[currentPotion];

        rigidbody = GetComponent<Rigidbody2D>();
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        /*if (spriteRenderer.flipX == true)
        {
            FireballSpawnPointX = - (FireballSpawnPoint.position.x);
        }
        else
        {
            FireballSpawnPointX = FireballSpawnPoint.position.x;
        }
        FireballSpawnPoint.position = new Vector3(FireballSpawnPointX, FireballSpawnPoint.position.y, 0);*/
       
        potion = SwitchPotion();
        Throw();
    }

    /* private void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(horizontal * speed, rigidbody.velocity.y);
    } */

    private void Move()
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

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) // when right arrow
        {
            rigidbody.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
        }
    }

    public GameObject SwitchPotion()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow)) // when down arrow
        {
            currentPotion++;
            if (currentPotion >= potions.Length)
            {
                currentPotion = 0;
            }
        }
        return potions[currentPotion];
    }


    public void Throw()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // when right arrow
        {
            if (currentPotion != 0)
            {
                // Player_animator.SetTrigger("TriggerAttack"); // attack animation
                var fireball = Instantiate(potion, FireballSpawnPoint.position, FireballSpawnPoint.rotation);
            }
            else if (life < maxlife)
            {
                life++;
            }
        }
    }
}