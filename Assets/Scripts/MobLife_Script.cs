using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobLife_Script : MonoBehaviour, IDamageable
{

    [SerializeField] public int mobLife;
    [SerializeField] public int mobMaxLife;
    [SerializeField] SpriteRenderer SR; // mob sprite renderer


    // Start is called before the first frame update
    void Start()
    {
        mobLife = mobMaxLife;
    }

    public void Damage(int damageAmount)
    {
        mobLife -= damageAmount;
        StartCoroutine(mobDMG());
    }

    IEnumerator mobDMG()
    {
        
        // mob color
        SR.color = new Color(1, 0, 0, 1); // change mob to red
        yield return new WaitForSeconds(0.5f);
        SR.color = new Color(1, 1, 1, 1); // reset color
    }
}
