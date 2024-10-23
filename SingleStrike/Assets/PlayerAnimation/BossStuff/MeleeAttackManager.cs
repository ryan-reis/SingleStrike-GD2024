using UnityEngine;
using System.Collections;

public class MeleeAttackManager : MonoBehaviour
{
    public Animator bossAnimator; // Reference to the boss's animator
    public float meleeAttackRange = 2f; // Melee attack range
    public float attackCooldown = 1.5f; // Time between consecutive attacks
    public AudioClip swordSound; // Sword sound effect for melee attacks

    private BossAI bossAI; // Reference to the BossAI script
    public SwordHitDetection swordHitDetection; // Reference to the SwordHitDetection script
    private bool canAttack = true; // Tracks if the boss can attack
    private AudioSource audioSource; // Reference to the AudioSource

    void Start()
    {
        // Get the BossAI component
        bossAI = GetComponent<BossAI>();
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            // Add an AudioSource component if not already present
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Log to see if the reference is set correctly
        if (swordHitDetection != null)
        {
            Debug.Log("SwordHitDetection successfully assigned in Start().");
        }
        else
        {
            Debug.LogWarning("SwordHitDetection reference is still null in Start().");
        }
    }

    public void OnDefenseStance()
    {
        if (swordHitDetection != null)
        {
            // Reset hit detection logic if necessary
        }
        else
        {
            Debug.LogWarning("SwordHitDetection reference is missing in OnDefenseStance().");
        }
    }

    void Update()
    {
        if (bossAI == null) return; // Make sure BossAI is present

        float distanceToPlayer = Vector3.Distance(transform.position, bossAI.player.position);

        // Check if the player is within melee attack range and the boss can attack
        if (distanceToPlayer <= meleeAttackRange && canAttack)
        {
            PerformMeleeAttack();
        }
    }

    void PerformMeleeAttack()
    {
        // Trigger the melee attack animation
        int attackType = Random.Range(1, 4); // Randomly choose an attack type
        switch (attackType)
        {
            case 1:
                bossAnimator.SetTrigger("meleeAttack");
                break;
            case 2:
                bossAnimator.SetTrigger("meleeAttack2");
                break;
            case 3:
                bossAnimator.SetTrigger("meleeAttack3");
                break;
        }

        canAttack = false; // Prevent further attacks until the cooldown is over

        // Start the attack cooldown
        StartCoroutine(AttackCooldown());
    }

    IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true; // Allow the boss to attack again after the cooldown
    }

    // This method will be triggered by an animation event to play the sword sound
    public void PlaySwordSound()
    {
        if (swordSound != null)
        {
            audioSource.PlayOneShot(swordSound);
        }
    }
}