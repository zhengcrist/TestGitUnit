using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack_Script : MonoBehaviour
{
    [SerializeField] private Transform attackTransform;
    [SerializeField] private float attackRange = 0.7f;
    [SerializeField] private LayerMask attackableLayer;
    [SerializeField] private int damageAmount = 1;

    private RaycastHit2D[] hits;


    // Update is called once per frame
    /*void Update()
    {
        // if (UserInput.instance.default_Inputs.P1.Attack.WasPressedThisFrame())
        // {
        //    Attack();
        // }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }*/

    public void Attack()
    {
        hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, transform.right, 0f, attackableLayer);

        for (int i = 0; i < hits.Length; i++)
        {
            IDamageable iDamageable = hits[i].collider.gameObject.GetComponent<IDamageable> ();

            // if an iDamageable is found
            if (iDamageable != null)
            {
                // apply damage
                iDamageable.Damage(damageAmount);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackTransform.position, attackRange);
    }
}
