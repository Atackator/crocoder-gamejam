using UnityEngine;

public class CollisionEnemy : EnemyBase
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Assumes the player has a PlayerHealth script with a TakeDamage method.
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(collisionDamage);
            }
        }
    }
}