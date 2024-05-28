using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerAttack_Script : MonoBehaviour
{
    [SerializeField] private Transform attackTransform;
    [SerializeField] private float attackRange = 0.7f;
    [SerializeField] private LayerMask attackableLayer;
    [SerializeField] private int damageAmount = 1;
    [SerializeField] private float cooldown = 0.5f;
    [SerializeField] private float knockbackForceMob = 5f;

    public bool inAction;

    private RaycastHit2D[] hits;

    [SerializeField] Animator Player_animator;
    [SerializeField] Player_Script1 player;

    // Audio
    [SerializeField] AudioManager audioManager;

    private void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        inAction = false;
        Player_animator = GetComponent<Animator>();
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (!inAction) 
        {
            inAction = true;
            player.playerImmuneTimer = 0.8f;
            StartCoroutine(Atk(0.1f));
            StartCoroutine(Cooldown(cooldown));

            //Animator.SetTrigger("AttackTrigger");

            hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, transform.right, 0f, attackableLayer);

            for (int i = 0; i < hits.Length; i++)
            {
                IDamageable iDamageable = hits[i].collider.gameObject.GetComponent<IDamageable>();

                // knockback
                if (hits[i].collider.gameObject.GetComponent<Rigidbody2D>() != null )
                {
                    Vector2 direction = (hits[i].collider.gameObject.transform.position - transform.position).normalized;
                    Vector2 knockbackMob = direction * knockbackForceMob * 10;
                    hits[i].collider.gameObject.GetComponent<Rigidbody2D>().AddForce(knockbackMob, ForceMode2D.Impulse);
                }
                

                // if an iDamageable is found
                if (iDamageable != null)
                {
                    // apply damage
                    iDamageable.Damage(damageAmount);
                }
            }
        }
       
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackTransform.position, attackRange);
    }

    IEnumerator Atk(float cooldown)
    {
        audioManager.PlaySFX(audioManager.SFX_Attack);
        Player_animator.SetBool("Atk", true);
        yield return new WaitForSeconds(cooldown);
        Player_animator.SetBool("Atk", false);
    }

    IEnumerator Cooldown(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        inAction = false;
    }
}
