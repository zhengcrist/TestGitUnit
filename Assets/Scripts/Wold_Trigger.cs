using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wold_Trigger : MonoBehaviour
{
    [SerializeField] private float cooldown = 8f;
    [SerializeField] private bool wolfTrigger = true;
    [SerializeField] private GameObject wolf;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag != "Player" && wolfTrigger)
        {
            StartCoroutine(Cooldown(cooldown));
            Vector3 vectPlayer = col.transform.position;
            Vector3 vectPos = new Vector3(vectPlayer.x + 25f, vectPlayer.y, 0f);
            var wolfSpawn = Instantiate(wolf, vectPos, transform.localRotation);
        }
        Debug.Log("OnCollisionEnter2D");
    }


    IEnumerator Cooldown(float cooldown)
    {
        wolfTrigger = false;
        yield return new WaitForSeconds(cooldown);
        wolfTrigger = true;
    }
}
