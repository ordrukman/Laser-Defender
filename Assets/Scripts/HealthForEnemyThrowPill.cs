using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthForEnemyThrowPill : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool applyCameraShake;
    [SerializeField] bool throwPill;
    CameraShake cameraShake;

    int maxHealth;

    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;
    [SerializeField] GameObject healerObject;


    void Awake() {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
        maxHealth = health;
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        HealerObject healer = other.GetComponent<HealerObject>();
        if(damageDealer != null) {
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            audioPlayer.PlayDamageClip();
            ShakeCamera();
            damageDealer.Hit();
        } else if(healer != null) {
            AddHealth(healer.GetHeal());
            healer.Hit();
        }
    }
    
    public int GetHealth() {
        return health;
    }

    void TakeDamage(int damage) {
        health -= damage;
        if(health <= 0) {
            Die();
        }
    }

    void AddHealth(int heal) {
        if(health <= maxHealth - heal) {
           health += heal; 
        } else {
            health = maxHealth;
        }
    }

    void Die() {
        if(!isPlayer) {
            scoreKeeper.ModifyScore(score);
            if(throwPill) {
                GameObject instance =  Instantiate(healerObject,
                        transform.position,
                        Quaternion.identity);
                Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
                if(rb != null) {
                    
                    rb.velocity = transform.up * 5;
                } else {
                    Debug.Log("b");
                }
            }
        } else {
            levelManager.LoadGameOver();
        }
        Destroy(gameObject);
    }

    void PlayHitEffect() {
        if(hitEffect != null) {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
    
    void ShakeCamera() {
         if(cameraShake != null && applyCameraShake) {
             cameraShake.Play();
         }
    }
}
