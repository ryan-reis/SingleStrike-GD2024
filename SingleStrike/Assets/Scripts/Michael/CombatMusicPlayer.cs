using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class CombatMusicPlayer : MonoBehaviour
{
    //public AudioClip passiveSound;
    public AudioClip combatSound; 
    public AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        //audioSource.clip = passiveSound;
        //audioSource.loop = true;
        //audioSource.Play();
    }


    void Update()
    {
        
    }

    //Playing

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("EnemyHurtbox"))
        {
            audioSource.clip = combatSound;
            audioSource.loop = true;
            audioSource.Play();

        }
        else
        {

        }
    }

    void OnTriggerStay(Collider other)

    {
        
        if (other.CompareTag("EnemyHurtbox"))
        {

        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("EnemyHurtbox"))
        {
            StartCoroutine(FadeAudioSource.StartFade(audioSource, 2.0f, 0));


            //audioSource.clip = passiveSound;
            //audioSource.loop = true;
            //audioSource.Play();
        }

    }

}


