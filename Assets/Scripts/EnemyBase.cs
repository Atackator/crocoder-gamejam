using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    public int health = 100;
    public float moveSpeed = 2f;
    public float attackRange = 1f;
    public int collisionDamage = 10;

    protected Transform target;
    protected virtual void Start()
    {
        // Look for the player by tag
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            target = playerObj.transform;
        }
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        // Handle enemy death (destroy, play animation, etc.)
        Destroy(gameObject);
    }
}
