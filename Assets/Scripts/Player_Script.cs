using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{

    // [SerializeField] Animator Player_animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] float speed = 0.7f;
    [SerializeField] new Rigidbody2D rigidbody;

    [SerializeField] Transform FireballSpawnPoint;
    // [SerializeField] float FireballSpawnPointX;

    [SerializeField] private GameObject[] potions; // array of potions
    [SerializeField] private GameObject potion;
    [SerializeField] private int currentPotion = 0;

    private bool Player_Run;
    private float jump = 3f;
    public int life;


    // Start is called before the first frame update
    void Start()
    {
        life = 4;
        potion = potions[currentPotion];

        rigidbody = GetComponent<Rigidbody2D>();
        Move();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
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

        if (Input.GetKeyDown(KeyCode.UpArrow)) // when up arrow
        {
            rigidbody.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
        }

    }

    private GameObject SwitchPotion()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow)) // when down arrow
        {
            currentPotion++;
            if(currentPotion >= potions.Length)
            {
                currentPotion = 0;
            }
        }
        return potions[currentPotion];
    }

    void Throw()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // when keypad 1
        {
            if (currentPotion != 0)
            {
                // Player_animator.SetTrigger("TriggerAttack"); // attack animation
                var fireball = Instantiate(potion, FireballSpawnPoint.position, FireballSpawnPoint.rotation);
            }
           else if (life < 4)
            {
                life++;
            }
        }
    }
}