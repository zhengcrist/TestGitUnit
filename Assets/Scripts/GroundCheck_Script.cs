using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GroundCheck_Script : MonoBehaviour
{
    public CinemachineVirtualCamera[] virtualCameras;
    private int defaultPriority = 10;
    private int activeCameraIndex = 0; // keeps track of wich camera is currently active 

    [SerializeField] Player_Script1 player;
    [SerializeField] GameObject p1;
    [SerializeField] Transform LastCheckpoint;

    public ContactFilter2D ContactFilter;

    [SerializeField] Rigidbody2D m_Rigidbody;
    public bool IsGrounded1 => m_Rigidbody.IsTouching(ContactFilter);
    private bool first = true;
    public bool IsGrounded;

    [SerializeField] Animator Player_animator;

    // public bool isGrounded;
    void Awake()
    {
        // reset cam
        foreach (var cam in virtualCameras)
        {
            cam.Priority = defaultPriority;
        }

        // Set the first camera as the active camera
        if (virtualCameras.Length > 0)
        {
            virtualCameras[0].Priority = defaultPriority + 2;
        }
    }

    void Update()
    {
        if (player.life <= 0)
        {
            Die();
            player.life = player.maxlife;

            // reset cam
            foreach (var cam in virtualCameras)
            {
                cam.Priority = defaultPriority;
            }

            // Set the first camera as the active camera
            if (virtualCameras.Length > 0)
            {
                virtualCameras[0].Priority = defaultPriority + 2;
            }

        }

        if (IsGrounded1) { IsGrounded = true; }
        
        if (!IsGrounded1 && first) // For more forgiving jump
        {
            StartCoroutine(GroundDelay());
        }
        else if (IsGrounded1 &&  !first)
        {
            first = true;
        }

        if (!IsGrounded)
        {
            Player_animator.SetBool("Falling", true);
        }
        else
        {
            Player_animator.SetBool("Falling", false);
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

    IEnumerator GroundDelay()
    {
        first = false;
        yield return new WaitForSeconds(0.3f);
        IsGrounded = false;
    }
}
