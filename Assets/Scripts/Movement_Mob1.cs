using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Movement_Mob1 : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints; // start the waypoints array
    
    private float _speed;
    [SerializeField] private float speed1, speed2; // speed of the platforms

    private float _checkDistance = 0.1f; // current distance waypoint-platform
    Vector3 startPosition = Vector3.zero;

    private Transform _targetWaypoint; // which waypoint to move to
    private int _currentWaypointIndex = 0; // to start the index of the waypoint array

    // [SerializeField] new Rigidbody2D rigidbody;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Player_Script player;

    [SerializeField] List<int> BurnTimes = new List<int>();
    [SerializeField] private int ticks;
    [SerializeField] private float FreezeTime;
    [SerializeField] private float PauseTime;
    [SerializeField] public int mobLife;
    [SerializeField] public int mobMaxLife;
    [SerializeField] public bool isFrozen = false;
    [SerializeField] public bool isDead = false;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        // rigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Script>();
        _targetWaypoint = _waypoints[0];
        startPosition = transform.position;
        mobLife = mobMaxLife;
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
                mobLife = mobMaxLife; // reset life
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
        if (mobLife <= 0)
        {
            spriteRenderer.color = new Color(1, 0, 0, 1); // change color
            isDead = true; // to freeze movement
        }
        else
        {
            // different speed between waypoints
            if (_currentWaypointIndex <= 1)
            {
                _speed = speed1;
            }
            else
            {
                _speed = speed2;
            }

            // movement
            transform.position = Vector2.MoveTowards(transform.position, _targetWaypoint.position, _speed * Time.deltaTime); // transform position to move to the target waypoint at _speed speed (mod deltaTime)
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
                mobLife--;
                spriteRenderer.color = new Color(0, 0, 1, 1); // change color
                isFrozen = true;
                Debug.Log("OnCollision ice");
            }
        }
        
    }

    private void ApplyBurn()
    {
        if (BurnTimes.Count > 0)
        {
            StartCoroutine(BurnCoroutine(2f));
            spriteRenderer.color = new Color(1, 1, 1, 1); // change color
        }
        else
        {
            while(BurnTimes.Count < ticks)
            {
                BurnTimes.Add(ticks);
            }
        }
    }

    IEnumerator BurnCoroutine(float sec)
    {
        while(BurnTimes.Count > 0)
        {
            for (int i = 0; i < BurnTimes.Count; i++)
            {
                BurnTimes[i]--;
            }
        }
        mobLife--;
        BurnTimes.RemoveAll(i => i == 0);
        spriteRenderer.color = new Color(0, 1, 0, 1); // change color
        yield return new WaitForSeconds(sec);

    }


}
