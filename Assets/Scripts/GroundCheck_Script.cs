using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GroundCheck_Script : MonoBehaviour
{
    public CinemachineVirtualCamera[] virtualCameras;
    private int defaultPriority = 10;
    private int activeCameraIndex = 0; // keeps track of wich camera is currently active 

    // particles
    [SerializeField] private ParticleSystem RunVFX;
    [SerializeField] Player_Script1 player;
    [SerializeField] GameObject p1;
    public static Vector3 lastCheckpointPosition = new Vector3(0f, 0f, 0f);
    [SerializeField] private Transform LastCheckpoint;

    public ContactFilter2D ContactFilter;

    [SerializeField] Rigidbody2D m_Rigidbody;
    /*public bool IsGrounded1 => m_Rigidbody.IsTouching(ContactFilter);
    private bool first = true;*/
    bool IsGrounded1;
    public bool jumping = false;

    public bool IsGrounded;
    public LayerMask groundLayer;
    public Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;

    [SerializeField] Animator Player_animator;

    // Audio
    [SerializeField] AudioManager audioManager;

    // public bool isGrounded;
    void Awake()
    {
        IsGrounded1 = true;

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

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

        // go to last checkpoint
        if(lastCheckpointPosition ==  Vector3.zero)
        {
            lastCheckpointPosition = LastCheckpoint.position;
        }
        p1.transform.position = lastCheckpointPosition;
    }

    void Update()
    {
        if (player.life <= 0)
        {
            StartCoroutine(Die());


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

       
       // Groundcheck
        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);


        if (!IsGrounded)
        {
            Player_animator.SetBool("Falling", true);
            if(!jumping)
            {
                RunVFX.Stop();
            }
        }
        else
        {
            Player_animator.SetBool("Falling", false);
        }

        // landing sound
        if (!IsGrounded1 && IsGrounded)
        {
            audioManager.PlaySFX(audioManager.SFX_Land);

            // particles
            // jumping = true;
            // RunVFX.Play();
            StartCoroutine(GroundDelay());

            IsGrounded1 = true;
        }
        if (IsGrounded1 && (!IsGrounded))
        {
            IsGrounded1 = false;
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
        lastCheckpointPosition = LastCheckpoint.position;
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(0.2f);
        p1.transform.position = lastCheckpointPosition;
        player.life = player.maxlife;
    }

    IEnumerator GroundDelay()
    {
        yield return new WaitForSeconds(0.2f);
        jumping = false;
        RunVFX.Stop();
    }
}
