using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int  maxHealth = 100;
    public int currentHealth;
    public HealthBar healthbox;
    void Start()
    {
        currentHealth = maxHealth;
        healthbox.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbox.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Handle player death (e.g., restart the level, show game over screen)
        Debug.Log("Player died.");
    }
}
