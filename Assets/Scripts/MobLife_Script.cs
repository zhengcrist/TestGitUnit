using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobLife_Script : MonoBehaviour, IDamageable
{

    [SerializeField] public int mobLife;
    [SerializeField] public int mobMaxLife;

    // Start is called before the first frame update
    void Start()
    {
        mobLife = mobMaxLife;
    }

    public void Damage(int damageAmount)
    {
        mobLife -= damageAmount;
    }

}
