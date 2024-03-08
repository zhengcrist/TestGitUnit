using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FireballPrefab_Script : MonoBehaviour
{

    [SerializeField] float StartTime = 0f;
    [SerializeField] float CurrentTime = 3f;

    [SerializeField] float moveSpeed = 1.5f;
    [SerializeField] Animator Fireball_animator;

    void Start()
    {
        StartTime = CurrentTime;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x + (moveSpeed * Time.deltaTime), transform.position.y, transform.position.z);
        Timer();
    }

    void Timer()
    {
        CurrentTime -= 1 * Time.deltaTime;
        if (CurrentTime <= 0)
        {
            Destroy(gameObject);
        }
    }



}
