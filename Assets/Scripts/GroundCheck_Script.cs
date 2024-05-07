using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck_Script : MonoBehaviour
{
    [SerializeField] Player_Script1 player;
    [SerializeField] GameObject p1;
    [SerializeField] Transform LastCheckpoint;

    public ContactFilter2D ContactFilter;

    [SerializeField] Rigidbody2D m_Rigidbody;
    public bool IsGrounded => m_Rigidbody.IsTouching(ContactFilter);

    // public bool isGrounded;

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
        /* if (other.gameObject.CompareTag("Ground")) // collide an object with a tag 
        {
            isGrounded = true; // not jumping
        }*/

        if (other.gameObject.CompareTag("Checkpoint"))
        {
            Transform CurrentCheckPoint = other.gameObject.transform;
            Checkpoint(CurrentCheckPoint);
            
        }

    }

    /* private void OnCollisionExit2D(Collision2D other) //leaving the floor 
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; // jumping
        }

    }*/

    private void Checkpoint(Transform checkpointTransform)
    {
        LastCheckpoint = checkpointTransform;
    }

    private void Die()
    {
        p1.transform.position = LastCheckpoint.position;
    }
}
