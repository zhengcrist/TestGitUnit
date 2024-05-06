using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck_Script : MonoBehaviour
{
    public bool isGrounded;


    [SerializeField] Player_Script1 player;

    [SerializeField] private Transform LastCheckpoint;
    [SerializeField] private GameObject playerObject;

    void Update()
    {
        if (player.life <= 0)
        {
            Die();
            player.life = player.maxlife;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) //hit different game object
    {
        if (other.gameObject.CompareTag("Ground")) // collide an object with a tag 
        {
            isGrounded = true; // not jumping
        }

        if (other.gameObject.CompareTag("Checkpoint"))
        {
            Transform CurrentCheckpoint = other.gameObject.transform;

            CheckpointUpdate(CurrentCheckpoint);

            // collision.GetComponent<Checkpoint>().CheckpointFeedback();
        }
    }

    private void OnCollisionExit2D(Collision2D other) //leaving the floor 
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; // jumping
        }

    }

    private void CheckpointUpdate(Transform checkpointTransform)
    {
        LastCheckpoint = checkpointTransform;
    }

    private void Die()
    {
        playerObject.transform.position = LastCheckpoint.position;
    }
}
