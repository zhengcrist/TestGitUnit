using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            Transform CurrentCheckpoint = collision.gameObject.transform;

            CheckpointUpdate(CurrentCheckpoint);

            // collision.GetComponent<Checkpoint>().CheckpointFeedback();
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
