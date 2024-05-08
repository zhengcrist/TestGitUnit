using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.Universal;


public class Mob1_Script : MonoBehaviour
{
    // ______________ For mob movement ______________
    [SerializeField] private Transform[] _waypoints; // start the waypoints array
    [SerializeField] private float[] speed; // speed of the mob
    private float _checkDistance = 0.1f; // current distance waypoint-mob
    Vector3 startPosition = Vector3.zero;
    private Transform _targetWaypoint; // which waypoint to move to
    private int _currentWaypointIndex = 0; // to start the index of the waypoint array
    // Knockback
    [SerializeField] private float knockbackForceMob = 5f;
    [SerializeField] private float knockbackForceP = 30f;
    [SerializeField] private Rigidbody2D rb;

    // ______________ For mob effects ______________
    // BURN
    [SerializeField] public bool isBurnt = false;
    // FREEZE
    [SerializeField] public bool isFrozen = false;
    [SerializeField] private float FreezeTime;
    // DEAD
    [SerializeField] public bool isDead = false;
    [SerializeField] private float PauseTime;

    private float timer = 0; // disabled timer
    [SerializeField] SpriteRenderer spriteRenderer; // mob sprite renderer
    [SerializeField] MobLife_Script Mob_1; // for mob life

    // ______________ For player ______________
    [SerializeField] Player_Script1 player;
    [SerializeField] SpriteRenderer playerSR; // player sprite renderer
    // Immunity time
    [SerializeField] private float playerImmuneMax;
    private float playerImmuneTimer;

    // ______________ For drop ______________
    [SerializeField] private GameObject collectible; //prefab drop


    // Start is called before the first frame update
    void Start()
    {
        _targetWaypoint = _waypoints[0];
        startPosition = transform.position;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Script1>();
        playerSR = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();

        playerImmuneTimer = playerImmuneMax;

    }

    // Update is called once per frame
    void Update()
    {
        // ______________ Mob disabled ________________

        if (isDead) // freeze movement if dead
        {
            Debug.Log("deadead");

            timer += Time.deltaTime;

            if (timer > PauseTime)
            {
                isDead = false;
                timer = 0;
                Mob_1.mobLife = Mob_1.mobMaxLife; // reset life
                spriteRenderer.color = new Color(1, 1, 1, 1); // change color
            }
            return; // exit so it doesn't do the rest
        }

        if (isFrozen) // freeze movement if frozen
        {
            Debug.Log("frozen");
            
            timer += Time.deltaTime;

            if (timer > FreezeTime)
            {
                isFrozen = false;
                timer = 0;
                spriteRenderer.color = new Color(1, 1, 1, 1); // change color
            }
            return; // exit so it doesn't do the rest
        }

        // ___________________________________________


        MovingFonct();

        // Player immunity timer set
        playerImmuneTimer += Time.deltaTime;
        

    }


    // ________________________________________________________________________________
    // ___________________________________ MOVEMENT ___________________________________

    private void MovingFonct()
    {
        // dead condition
        if (Mob_1.mobLife <= 0)
        {
            var Blue = Instantiate(collectible, new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z), transform.rotation);
            spriteRenderer.color = new Color(1, 0, 0, 1); // change color
            isDead = true; // to freeze movement
        }
        else
        {
            // movement
            transform.position = Vector2.MoveTowards(transform.position, _targetWaypoint.position, speed[_currentWaypointIndex] * Time.deltaTime); // transform position to move to the target waypoint at _speed speed (mod deltaTime)
            if (Vector2.Distance(transform.position, _targetWaypoint.position) < _checkDistance)
            {
                // if the position hasn't reached the target waypoint yet
                _targetWaypoint = GetNextWaypoint();
            }
        }
    }

    private Transform GetNextWaypoint()
    {
        _currentWaypointIndex++; // inc the index
        if (_currentWaypointIndex >= _waypoints.Length)
        {
            // if the index is larger than the last index in the waypoint array
            _currentWaypointIndex = 0;
        }
        return _waypoints[_currentWaypointIndex];
    }

    // __________________________________ !MOVEMENT ___________________________________
    // ________________________________________________________________________________
    
    // ________________________________________________________________________________
    // _________________________________ COLLISIONS ___________________________________

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isDead)
        {
            _targetWaypoint = GetNextWaypoint();

            // if collision with player, player gets damage
            if (collision.gameObject.tag == "Player")
            {
                // Player receive dmg only when they're out of the immunity time and the mob is not frozen or dead
                if (!isFrozen && (playerImmuneTimer >= playerImmuneMax))
                {
                    // Knockback
                    Vector2 direction = (collision.gameObject.transform.position - transform.position).normalized;
                    Debug.Log("direction" + direction);
                    Vector2 knockbackMob = - direction * knockbackForceMob * 10;
                    Vector2 knockbackP = direction * knockbackForceP * 10;
                    rb.AddForce(knockbackMob, ForceMode2D.Impulse);
                    collision.gameObject.GetComponent<Rigidbody2D>().AddForce(knockbackP, ForceMode2D.Impulse);

                    // Immunity timer reset
                    playerImmuneTimer = 0;
                    // Player dmg
                    player.life--;
                    // Change color feedback
                    StartCoroutine(playerDMG());  
                    
                }
            }

            // if collision with fireball, mob gets burnt
            if (collision.gameObject.name == "Fireball(Clone)")
            {
                isBurnt = true;
                // Burn on light_flicker script
                Debug.Log("OnCollision fire");
            }

            // if collision with iceball, mob gets 1 dmg and freeze
            if (collision.gameObject.name == "Iceball(Clone)")
            {
                Mob_1.mobLife--; // dmg received by mob
                spriteRenderer.color = new Color(0, 0, 1, 1); // change color
                isFrozen = true;
                Debug.Log("OnCollision ice");
            }
        }
        
    }

    // ________________________________ !COLLISIONS ___________________________________
    // ________________________________________________________________________________

    IEnumerator playerDMG()
    {
        playerSR.color = new Color(1, 0, 0, 1); // change player to red
        yield return new WaitForSeconds(0.5f);
        playerSR.color = new Color(1, 1, 1, 1); // reset color
    }
}
