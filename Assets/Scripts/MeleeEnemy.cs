using UnityEngine;

public class MeleeEnemy : EnemyBase
{
    public float attackCooldown = 1.5f;
    private float lastAttackTime = 0f;

    void Update()
    {
        if (target == null)
            return;

        float distance = Vector2.Distance(transform.position, target.position);
        if (distance <= attackRange && Time.time - lastAttackTime >= attackCooldown)
        {
            Attack();
            lastAttackTime = Time.time;
        }
        else
        {
            // Move towards the player
            Vector2 direction = (target.position - transform.position).normalized;
            transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;
        }
    }

    void Attack()
    {
        // Directly damage the player
        PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(collisionDamage);
        }
    }
}
