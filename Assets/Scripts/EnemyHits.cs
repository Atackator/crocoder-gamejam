// using UnityEngine;

// public class EnemyHit : MonoBehaviour
// {
//     public int damage = 20;

//     void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
//             if (playerHealth != null)
//             {
//                 playerHealth.TakeDamage(damage);
//             }
//         }
//     }
// }

using UnityEngine;

public class EnemyHits : MonoBehaviour
{
    public int damage = 20;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.collider.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    }
}
