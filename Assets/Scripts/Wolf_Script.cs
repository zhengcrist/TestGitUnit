using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf_Script : MonoBehaviour
{

    [SerializeField] float cooldown = 20f; 
    [SerializeField] private float moveSpeedX = 5f;
    // Visuals
    //[SerializeField] Animator Fireball_animator;
    public SpriteRenderer spriteRenderer;
    // BURN
    [SerializeField] public bool isBurnt = false;
    // FREEZE
    [SerializeField] public bool isFrozen = false;
    [SerializeField] private float FreezeTime;

    // ______________ For player ______________
    [SerializeField] Player_Script1 player;
    [SerializeField] SpriteRenderer playerSR; // player sprite renderer
    // Knockback
    [SerializeField] private float knockbackForceP = 30f;

    // Movement to the right or to the left
    private float currentX = 0;
    private float previousX = 0;
    private float positionX;

    // Audio
    [SerializeField] AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Script1>();
        playerSR = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();

        StartCoroutine(Timer(cooldown));
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFrozen)
            transform.Translate(Vector3.left * moveSpeedX * Time.deltaTime); // move

        currentX = transform.position.x;
        StartCoroutine(posCalculate(currentX));

        if((currentX - previousX) > 0)
        {
            Debug.Log("wolf flip");
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "Player")
        {
            if (!isFrozen && (player.playerImmuneTimer >= player.playerImmuneMax))
            {
                // Knockback
                Vector2 direction = (collision.gameObject.transform.position - transform.position).normalized;
                Debug.Log("direction" + direction);
                Vector2 knockbackP = direction * knockbackForceP * 10;
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(knockbackP, ForceMode2D.Impulse);

                // Immunity timer reset
                player.playerImmuneTimer = 0;
                // Player dmg
                player.life--;
                // audio
                audioManager.PlaySFX(audioManager.SFX_Hurt);
                // Change color feedback
                StartCoroutine(playerDMG());

            }

        }
        // if collision with fireball, mob gets burnt
        if (collision.name == "Fireball(Clone)")
        {
            isBurnt = true;
            // Burn on light_flicker script
            Debug.Log("OnCollision fire");
        }

        // if collision with iceball, mob gets 1 dmg and freeze
        if (collision.name == "Iceball(Clone)")
        {
            // spriteRenderer.color = new Color(0, 0, 1, 1); // change color
            StartCoroutine(Freeze(FreezeTime));

            // anim.SetBool("Freeze", true); // freeze anim
            Debug.Log("OnCollision ice");
        }
    }

    IEnumerator playerDMG()
    {
        // player color
        playerSR.color = new Color(1, 0, 0, 1); // change player to red
        yield return new WaitForSeconds(0.5f);
        playerSR.color = new Color(1, 1, 1, 1); // reset color
    }

    IEnumerator Freeze(float cooldown)
    {
        isFrozen = true;
        yield return new WaitForSeconds(cooldown);
        isFrozen = false;
    }

    IEnumerator Timer(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        Destroy(this.gameObject);
    }

    IEnumerator posCalculate(float currentX)
    {
        yield return new WaitForSeconds(0.1f);
        previousX = currentX;
    }

}
