using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Enemy took " + damageAmount + " damage. Current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Destroy the enemy GameObject or trigger a death animation
        Debug.Log("Enemy died.");
        LockPosition();
        animator.SetTrigger("IsDead");
        GetComponent<Collider>().enabled = false; // Disable the enemy's collider to prevent further interactions
        this.enabled = false;
        
        Destroy(gameObject, 15f);
    }
    private void LockPosition()
    {
        // Disable any Rigidbody to prevent further movement
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true; // Make Rigidbody kinematic to stop physics from affecting it
        }

        // Optionally, disable other scripts that could affect the transform
        MonoBehaviour[] scripts = GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour script in scripts)
        {
            if (script != this) // Do not disable the current EnemyHealth script
            {
                script.enabled = false;
            }
        }

        // Optionally, freeze the transform by disabling all constraints
        transform.hasChanged = false; // Reset any pending changes to the transform
    }
}
