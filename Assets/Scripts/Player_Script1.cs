using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Script1 : MonoBehaviour
{
    [SerializeField] private Default_Inputs default_Inputs;

    public int life;
    [SerializeField] private int maxlife;
    [SerializeField] Inventory_Script inventory;
    [SerializeField] new Rigidbody2D rigidbody;


    // [SerializeField] Animator Player_animator;
    // private bool Player_Run;
    [SerializeField] SpriteRenderer spriteRenderer;

    [SerializeField] private Vector2 _moveInput;
    [SerializeField] private float speed;

    [SerializeField] GroundCheck_Script GroundCheck;
    [SerializeField] private float jump;


    [SerializeField] Transform FireballSpawnPoint;
    // [SerializeField] float FireballSpawnPointX;

    [SerializeField] private GameObject[] potions; // array of potions
    [SerializeField] private GameObject potion;
    [SerializeField] private int currentPotion = 0;
    [SerializeField] private float cooldownThrow = 0.3f;
    [SerializeField] private float cooldownDrink = 1f;

    public PlayerAttack_Script player; // for the inaction bool

    void Awake()
    {
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
        _moveInput = default_Inputs.P1.Move.ReadValue<Vector2>();
        _moveInput.y = 0f;
        transform.Translate(_moveInput * speed * Time.deltaTime);

        if (_moveInput.x > 0f)
        {
            spriteRenderer.flipX = true; // sprite flipped
        }
        else if (_moveInput.x < 0f)
        {
            spriteRenderer.flipX = false; // sprite not flip
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (GroundCheck.isGrounded) // when right arrow
        {
            rigidbody.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
        }
    }

    public void Heal(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (player.inAction == false && inventory.MedNum >= 1 && inventory.OilNum >= 1 && inventory.ToadNum >= 1 && life < maxlife)
        {
            player.inAction = true;
            StartCoroutine(Cooldown(cooldownDrink));

            life++;

            inventory.MedNum--;
            inventory.OilNum--;
            inventory.ToadNum--;
        }
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (player.inAction == false && inventory.OilNum >= 2)
        {
            player.inAction = true;
            StartCoroutine(Cooldown(cooldownThrow));

            var fireball = Instantiate(potions[1], FireballSpawnPoint.position, FireballSpawnPoint.rotation);
            inventory.OilNum -= 2;
        }
    }

    public void Ice(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (player.inAction == false && inventory.ToadNum >= 2)
        {
            player.inAction = true;
            StartCoroutine(Cooldown(cooldownThrow));

            var fireball = Instantiate(potions[2], FireballSpawnPoint.position, FireballSpawnPoint.rotation);
            inventory.ToadNum -= 2;
        }
    }

    IEnumerator Cooldown(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        player.inAction = false;
    }
}