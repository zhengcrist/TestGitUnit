using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck_Script : MonoBehaviour
{
    public bool isGrounded;

    private void OnCollisionEnter2D(Collision2D other) //hit different game object
    {
        if (other.gameObject.CompareTag("Ground")) // collide an object with a tag 
        {
            isGrounded = true; // not jumping
        }

    }

    private void OnCollisionExit2D(Collision2D other) //leaving the floor 
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; // jumping
        }
    }
}
