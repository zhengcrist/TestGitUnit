using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Movement_Mob1 : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints; // start the waypoints array
    [SerializeField] private float _speed; // speed of the platforms
    [SerializeField] private float _checkDistance = 0.1f; // current distance waypoint-platform
    Vector3 startPosition = Vector3.zero;

    private Transform _targetWaypoint; // which waypoint to move to
    private int _currentWaypointIndex = 0; // to start the index of the waypoint array

    [SerializeField] Rigidbody2D rigidbody;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Player_Script player;

    [SerializeField] private float BurnTime = 2f;
    [SerializeField] private float FreezeTime = 5f;
    [SerializeField] private float PauseTime = 10f;
    [SerializeField] public int mobLife;
    [SerializeField] public int mobMaxLife = 10;
    [SerializeField] private bool isFrozen = false;
    [SerializeField] private bool isDead = false;
    [SerializeField] private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player_Dino").GetComponent<Player_Script>();
        _targetWaypoint = _waypoints[0];
        startPosition = transform.position;
        mobLife = mobMaxLife;
    }

    // Update is called once per frame
    void Update()
    {
        // freeze movement if dead
        if (isDead)
        {
            Debug.Log("deadead");

            timer += Time.deltaTime;

            if (timer > PauseTime)
            {
                isDead = false;
                timer = 0;
            }
            return; // exit so it doesn't do the rest
        }

        // freeze movement if frozen
        if (isFrozen)
        {
            Debug.Log("frozen");

            timer += Time.deltaTime;

            if (timer > FreezeTime)
            {
                isFrozen = false;
                timer = 0;
            }
            return; // exit so it doesn't do the rest
        }

        // dead condition
        if (mobLife <= 0)
        {
            spriteRenderer.color = new Color(0, 1, 0, 1); // change color
            isDead = true; // to freeze movement
            mobLife = mobMaxLife; // reset life
            spriteRenderer.color = new Color(1, 0, 0, 1); // change color
        }
        else
        {
            // different speed between waypoints
            if (_currentWaypointIndex <= 1)
            {
                _speed = 1f;
            }
            else
            {
                _speed = 0.5f;
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
        // if collision with player, player gets damage
        if (collision.gameObject.name == "Player_Dino")
        {
            player.life--;
        }

        // if collision with fireball, mob gets burnt
        if (collision.gameObject.name == "Fireball(Clone)")
        {
            while (BurnTime >= 0f)
            {
                BurnTime--;
                mobLife--;

                Debug.Log("BurnTime : " + BurnTime + "mobLife : " + mobLife);
                StartCoroutine(WaitCoroutine(2));

            }
            Debug.Log("OnCollision fire");
            BurnTime = 2f;
        }

        // if collision with iceball, mob gets 1 dmg and freeze
        if (collision.gameObject.name == "Iceball(Clone)")
        {
            mobLife--;
            isFrozen = true;
            Debug.Log("OnCollision ice");
        }
    }

    IEnumerator WaitCoroutine(int sec)
    {
        yield return new WaitForSeconds(sec);

    }


}
