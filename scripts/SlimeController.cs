using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeController : MonoBehaviour
{
    //public Rigidbody2D rb2D;
    private Animator animator;
    public float speed = 5f;
    
    public int maxHealth = 10;
    public int currentHealth;

    private CapsuleCollider2D slimeHitbox;

    private GameObject[] players = new GameObject[1];
    private PolygonCollider2D attackAreaCollider;

    private GameObject[] playerControllers = new GameObject[1];
    private PlayerController pc;

    public GameObject slimeDeath;

    // Start is called before the first frame update
    void Start() {
        //rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //animator.SetBool("isRunning", true);
        
        currentHealth = maxHealth;

        slimeHitbox = gameObject.GetComponentInChildren<CapsuleCollider2D>();

        players = GameObject.FindGameObjectsWithTag("Player");
        attackAreaCollider = players[0].GetComponentInChildren<PolygonCollider2D>();

        playerControllers = GameObject.FindGameObjectsWithTag("Player");
        pc = playerControllers[0].GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collider) {       
        if(collider.gameObject.tag == "Player") {
            Instantiate(slimeDeath, transform.position, Quaternion.identity);
            DealDamage();
        }
 
        if(collider.gameObject.tag == "AttackArea") {
            Instantiate(slimeDeath, transform.position, Quaternion.identity);
            TakeDamage();
        }

        if(collider.gameObject.tag == "Slime" || collider.gameObject.tag == "HealthSlime" || collider.gameObject.tag == "ExplosionSlime") {
            if(gameObject.tag == "HealthSlime") {
                Instantiate(slimeDeath, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            
            else if(gameObject.tag == "ExplosionSlime") {
                Instantiate(slimeDeath, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

            else {
                Instantiate(slimeDeath, transform.position, Quaternion.identity);
                Destroy(transform.parent.gameObject);
            }
            
        }
        
    }


    // Damages slime and destroys it once it loses all health
    public void TakeDamage() {
        currentHealth -= 10;
        pc.IncreaseScore();
        if(gameObject.tag == "HealthSlime") {
            pc.currentHealth += 10;
            if(pc.currentHealth > 50) {
                pc.currentHealth = 50;
            }
            pc.healthBar.SetHealth(pc.currentHealth);
            Destroy(gameObject);
        }

        else if(gameObject.tag == "ExplosionSlime") {
            Destroy(gameObject);
        }

        else {
            Destroy(transform.parent.gameObject);
        }
    }

    // Deals Damage to the player
    public void DealDamage() {
        if(gameObject.tag == "ExplosionSlime") {
            pc.TakeDamage(10);
        }
        else {
            pc.TakeDamage(5);
        }
    
        if(gameObject.tag == "HealthSlime") {
            Destroy(gameObject);
        }

        else if(gameObject.tag == "ExplosionSlime") {
            Destroy(gameObject);
        }

        else {
            Destroy(transform.parent.gameObject);
        }
        
    }
    
}
