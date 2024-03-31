using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Script1 : MonoBehaviour
{
    [SerializeField] Inventory_Script inventory;

    // [SerializeField] Animator Player_animator;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] new Rigidbody2D rigidbody;
    // [SerializeField] private float horizontal;
    [SerializeField] private float speed;
    [SerializeField] GroundCheck_Script GroundCheck;

    [SerializeField] Transform FireballSpawnPoint;
    // [SerializeField] float FireballSpawnPointX;

    [SerializeField] private GameObject[] potions; // array of potions
    [SerializeField] private GameObject potion;
    [SerializeField] private int currentPotion = 0;

    // private bool Player_Run;
    [SerializeField] private float jump;
    [SerializeField] public int life;
    [SerializeField] private int maxlife;

    [SerializeField] private Default_Inputs default_Inputs;
    [SerializeField] private Vector2 _moveInput;

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

    /* void FixedUpdate()
    {
        _moveInput = default_Inputs.P1.Move.ReadValue<Vector2>();
        _moveInput.y = 0f;
        rigidbody.velocity = _moveInput * speed;
    } */

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


    /* if (Input.GetKey(KeyCode.RightArrow)) // when right arrow
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);  // movement to the right
        // Player_animator.SetBool("BoolMove", true); // run animation
        spriteRenderer.flipX = true; // sprite flipped
    }
    else if (Input.GetKeyUp(KeyCode.RightArrow))
    {
        // Player_animator.SetBool("BoolMove", false); // stop run animation
    }

    if (Input.GetKey(KeyCode.LeftArrow)) // when left arrow
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);  // movement to the left
        // Player_animator.SetBool("BoolMove", true); // run animation
        spriteRenderer.flipX = false; // sprite not flip
    }
    else if (Input.GetKeyUp(KeyCode.LeftArrow))
    {
        // Player_animator.SetBool("BoolMove", false); // stop run animation
    } */


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
        if (inventory.MedNum >= 1 && inventory.OilNum >= 1 && inventory.ToadNum >= 1 && life < maxlife)
        {
            life++;
            inventory.MedNum--;
            inventory.OilNum--;
            inventory.ToadNum--;
        }
    }

    public void Fire(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (inventory.OilNum >= 3)
        {
            var fireball = Instantiate(potions[1], FireballSpawnPoint.position, FireballSpawnPoint.rotation);
            inventory.OilNum -= 3;
        }
    }

    public void Ice(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (inventory.ToadNum >= 3)
        {
            var fireball = Instantiate(potions[2], FireballSpawnPoint.position, FireballSpawnPoint.rotation);
            inventory.ToadNum -= 3;
        }
    }

}