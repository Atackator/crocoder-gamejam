using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public AudioClip attackSound;
    private AudioSource audioSource;
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public int attackDamage = 40;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }
    void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);
        // foreach (Collider2D enemy in hitEnemies)
        // {
        //     // Damage the enemy
        //     Debug.Log("Hit " + enemy.name);
        //     enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        // }

        Debug.Log("Attacking...");
        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Found enemy: " + enemy.name);
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            if (enemyScript != null)
            {
                enemyScript.TakeDamage(attackDamage);
            }
            else
            {
                Debug.LogWarning("Enemy script missing on " + enemy.name);
            }
        }
        audioSource.PlayOneShot(attackSound);

    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
