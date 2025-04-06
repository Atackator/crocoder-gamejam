// using UnityEngine;

// public class PlayerHealth : MonoBehaviour
// {
//     public int  maxHealth = 100;
//     private int currentHealth;

//     void Start()
//     {
//         currentHealth = maxHealth;
//     }

//     public void TakeDamage(int damage)
//     {
//         currentHealth -= damage;
//         if (currentHealth <= 0)
//         {
//             Die();
//         }
//     }

//     void Die()
//     {
//         // Handle player death (e.g., restart the level, show game over screen)
//         Debug.Log("Player died.");
//     }
// }




using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player took damage. Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died!");
        // Add death animation or restart logic here
    }
}



// using UnityEngine;

// public class PlayerHealth : MonoBehaviour
// {
//     public int maxHealth = 100;
//     private int currentHealth;

//     public HealthBar healthBar;

//     void Start()
//     {
//         currentHealth = maxHealth;
//         healthBar.SetMaxHealth(maxHealth);
//     }

//     public void TakeDamage(int damage)
//     {
//         currentHealth -= damage;
//         healthBar.SetHealth(currentHealth);

//         if (currentHealth <= 0)
//         {
//             Die();
//         }
//     }

//     void Die()
//     {
//         Debug.Log("Player died!");
//         // Handle death (animation, respawn, etc.)
//     }
// }
