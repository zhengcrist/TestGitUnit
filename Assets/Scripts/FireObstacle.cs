using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FireObstacle : MonoBehaviour
{
    [SerializeField] public Light2D myLight;
    [SerializeField] private int intens = 4;

    void Awake()
    {
        myLight.intensity = 0;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Fire"))
        {
            StartCoroutine(Burn());
        }
        Destroy(col);
    }

    IEnumerator Burn()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        for(int i = 1; i < intens; i++)
        {
            myLight.intensity = i;
            yield return new WaitForSeconds(1);
        }
        Destroy(this.gameObject);
        // rigidbody.detectCollisions = false;
    }
}
