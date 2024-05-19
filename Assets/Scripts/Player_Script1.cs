using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Script1 : MonoBehaviour
{
    [SerializeField] private Default_Inputs default_Inputs;

    public int life;
    public int maxlife;
    // Immunity time
    public float playerImmuneMax;
    public float playerImmuneTimer;

    [SerializeField] Inventory_Script inventory;
    [SerializeField] new Rigidbody2D rigidbody;

    // [SerializeField] SpriteRenderer sr;
    [SerializeField] Animator Player_animator;
    // private bool Player_Run;
    public bool flip = false;
    [SerializeField] private Vector2 _moveInput;
    [SerializeField] private float speed;

    [SerializeField] GroundCheck_Script GroundCheck;
    [SerializeField] private float jump;


    [SerializeField] Transform FireballSpawnPoint;

    [SerializeField] private GameObject[] potions; // array of potions
    [SerializeField] private GameObject potion;
    [SerializeField] private int currentPotion = 0;
    [SerializeField] private float cooldownThrow = 0.3f;
    [SerializeField] private float cooldownDrink = 1f;
    [SerializeField] private float cooldownNoDrink = 0.5f;

    public PlayerAttack_Script player; // for the inaction bool

    void Awake()
    {
        playerImmuneTimer = playerImmuneMax;

        default_Inputs = new Default_Inputs();

        rigidbody = GetComponent<Rigidbody2D>();


        life = maxlife;

        potion = potions[currentPotion];
    }


    public void OnEnable()
    {
        default_Inputs.P1.Enable();
    }

    public void OnDisable()
    {
        default_Inputs.P1.Disable();
    }

    void FixedUpdate()
    {
        // immunity
        if(playerImmuneTimer < playerImmuneMax)
        {
            // Player immunity timer set
            playerImmuneTimer += Time.deltaTime;
        }

        //movement
        _moveInput = default_Inputs.P1.Move.ReadValue<Vector2>();
        _moveInput.y = 0f;
        

        if (player.inAction == false)
        {
            Player_animator.SetBool("Run", true);
            transform.Translate(_moveInput * speed * Time.deltaTime); // move
            

            if ((_moveInput.x < 0f && !flip) || (_moveInput.x > 0f && flip))
            {
                Debug.Log("Flip");
                flip = !flip;
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
                
            }
        }

        if (_moveInput.x == 0)
        {
            Player_animator.SetBool("Run", false);
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (player.inAction == false && GroundCheck.IsGrounded) // when right arrow
        {
            Player_animator.SetBool("Jump", true);
            rigidbody.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
            StartCoroutine(Jump(0.1f));
        }
    }

    public void Heal(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (player.inAction == false && GroundCheck.IsGrounded && inventory.MedNum >= 1 && inventory.OilNum >= 1 && inventory.ToadNum >= 1 && life < maxlife)
        {
            Player_animator.SetBool("Drink", true);
            StartCoroutine(Drink(0.1f));

            player.inAction = true;
            StartCoroutine(Cooldown(cooldownDrink));

            life++;

            inventory.MedNum--;
            inventory.OilNum--;
            inventory.ToadNum--;
        }
        else if (player.inAction == false && GroundCheck.IsGrounded)
        {
            Player_animator.SetBool("No_Drink", true);
            StartCoroutine(No_Drink(0.1f));

            player.inAction = true;
            StartCoroutine(Cooldown(cooldownNoDrink));
        }
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (player.inAction == false && inventory.OilNum >= 2)
        {
            player.inAction = true;
            StartCoroutine(Cooldown(cooldownThrow));

            inventory.OilNum -= 2;

            Player_animator.SetBool("Throw_red", true);
            StartCoroutine(Throw(1));
        }
    }

    public void Ice(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (player.inAction == false && inventory.ToadNum >= 2)
        {
            player.inAction = true;
            StartCoroutine(Cooldown(cooldownThrow));

            inventory.ToadNum -= 2;

            Player_animator.SetBool("Throw_blue", true);
            StartCoroutine(Throw(2));
        }
    }

    IEnumerator Cooldown(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        player.inAction = false;
    }

    IEnumerator Jump(float time)
    {
        yield return new WaitForSeconds(time);
        Player_animator.SetBool("Jump", false);
    }

    IEnumerator Drink(float time)
    {
        yield return new WaitForSeconds(time);
        Player_animator.SetBool("Drink", false);
    }

    IEnumerator No_Drink(float time)
    {
        yield return new WaitForSeconds(time);
        Player_animator.SetBool("No_Drink", false);
    }

    IEnumerator Throw(int potion)
    {
        if (potion == 1)
        {
            yield return new WaitForSeconds(0.2f);
            Player_animator.SetBool("Throw_red", false);
            var fireball = Instantiate(potions[1], FireballSpawnPoint.position, FireballSpawnPoint.rotation);
        }
        else if (potion == 2)
        {
            yield return new WaitForSeconds(0.2f);
            Player_animator.SetBool("Throw_blue", false);
            var fireball = Instantiate(potions[2], FireballSpawnPoint.position, FireballSpawnPoint.rotation);
        }
    }
}