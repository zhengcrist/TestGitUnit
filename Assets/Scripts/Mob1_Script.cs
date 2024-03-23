using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Mob1_Script : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints; // start the waypoints array
    
    [SerializeField] private float[] speed; // speed of the mob

    private float _checkDistance = 0.1f; // current distance waypoint-mob
    Vector3 startPosition = Vector3.zero;

    private Transform _targetWaypoint; // which waypoint to move to
    private int _currentWaypointIndex = 0; // to start the index of the waypoint array

    // [SerializeField] new Rigidbody2D rigidbody;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Player_Script player;

    private int BurnTime;
    [SerializeField] private float BurnClock;
    [SerializeField] private int ticks;
    [SerializeField] private float FreezeTime;
    [SerializeField] private float PauseTime;
    [SerializeField] public bool isFrozen = false;
    [SerializeField] public bool isDead = false;
    private float timer = 0;

    //[SerializeField] public int mobLife;
    //[SerializeField] public int mobMaxLife;
    [SerializeField] MobLife_Script Mob_1;

    // Start is called before the first frame update
    void Start()
    {
        // rigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Script>();
        _targetWaypoint = _waypoints[0];
        startPosition = transform.position;
        // mobLife = mobMaxLife;
        BurnTime = ticks;
    }

    // Update is called once per frame
    void Update()
    {
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
       
        MovingFonct();
        

    }


    private void MovingFonct()
    {
        // dead condition
        if (Mob_1.mobLife <= 0)
        {
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isDead)
        {
            // if collision with player, player gets damage
            if (collision.gameObject.tag == "Player")
            {
                player.life--;
            }

            // if collision with fireball, mob gets burnt
            if (collision.gameObject.name == "Fireball(Clone)")
            {
                ApplyBurn();
                Debug.Log("OnCollision fire");
            }

            // if collision with iceball, mob gets 1 dmg and freeze
            if (collision.gameObject.name == "Iceball(Clone)")
            {
                Mob_1.mobLife--;
                spriteRenderer.color = new Color(0, 0, 1, 1); // change color
                isFrozen = true;
                Debug.Log("OnCollision ice");
            }
        }
        
    }

    private void ApplyBurn()
    {
        if (BurnTime <= 0)
        {
            BurnTime = ticks;
        }
        
        StartCoroutine(BurnCoroutine(BurnClock));
        
        spriteRenderer.color = new Color(1, 1, 1, 1); // change color
        
    }

    IEnumerator BurnCoroutine(float BurnClock)
    {
        spriteRenderer.color = new Color(0, 1, 0, 1); // change color
        while (BurnTime > 0)
        {
            Mob_1.mobLife--;
            BurnTime--;
            yield return new WaitForSeconds(BurnClock);
        }

    }


}
