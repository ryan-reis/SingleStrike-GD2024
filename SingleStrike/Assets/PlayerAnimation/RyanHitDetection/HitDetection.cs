using UnityEngine;

public class HitDetection : MonoBehaviour
{
    public int damage = 10;

    void Start()
    {
        // Disable the hitbox at the start of the scene
        gameObject.SetActive(false);
    }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected with: " + other.name); // Check if anything is detected

        if (other.CompareTag("EnemyHurtbox"))
        {
            Debug.Log("Hit the enemy!");

            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
                Debug.Log("Enemy took damage: " + damage);
            }
        }
    }
}