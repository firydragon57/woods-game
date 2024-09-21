using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Player Variables
    private Rigidbody2D rb2D;
    private Transform transform;
    private CapsuleCollider2D capsuleCollider;
    private BoxCollider2D boxCollider;

    // FIX HITBOX!!! - Has to match player when attacking
    public CapsuleCollider2D hitbox;
    
    //Slime Properties
    public GameObject slime;
    private CapsuleCollider2D slimeHitbox;
    private Rigidbody2D slimeRb2D;

    // Movement Variable
    private float moveSpeed;
    private float jumpForce;
    private bool isJumping;
    private float moveHorizontal;
    private float moveVertical;
    private bool facingRight = true;

    // Health Variables
    public int maxHealth = 50;
    public int currentHealth;
    public HealthBarController healthBar;

    // Attack Variables
    public GameObject attackArea;
    private bool attacking = false;
    private float timeToAttack = 0.5f;
    private float timer = 0f;
    
    // Animation Variables 
    public Animator animator;

    // Score Variables
    private GameObject[] texts = new GameObject[1];
    private Text txt;
    public int score;

    // GameOver Label
    public GameObject gameOverTextLabel;
    private Text gameOverText;

    // Wave Label
    public GameObject waveLabel;
    private Text waveText;
    private int currentWave;

    // Back Button
    public GameObject backButton;
    
    // Sound Effects
    public GameSoundFX gameSoundFx;

    // Start is called before the first frame update
    void Start() {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        transform = gameObject.GetComponent<Transform>();
        capsuleCollider = gameObject.GetComponent<CapsuleCollider2D>();
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        moveSpeed = 1.5f;
        jumpForce = 30f;
        isJumping = false;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        //attackArea = transform.GetChild(0).gameObject;
        attackArea.SetActive(attacking);

        slimeHitbox = slime.GetComponent<CapsuleCollider2D>();
        slimeRb2D = slime.GetComponent<Rigidbody2D>();

        texts = GameObject.FindGameObjectsWithTag("Score");
        txt = texts[0].GetComponent<Text>();
        score = 0;

        gameOverText = gameOverTextLabel.GetComponent<Text>();
        gameOverText.enabled = false;

        waveText = waveLabel.GetComponent<Text>();
        currentWave = 1;
        StartCoroutine(DisplayWave());

        backButton.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Speed", Mathf.Abs(moveHorizontal));
        waveCheck();
    }

    void FixedUpdate() {

        // Movement
        if(moveHorizontal > 0.1f || moveHorizontal < -0.1f) {
            rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
        }

        if(moveHorizontal > 0 && !facingRight) {
            Flip();
        }

        if(moveHorizontal < 0 && facingRight) {
            Flip();
        }

        // Jumping
        if(!isJumping && moveVertical > 0.1f) {
            rb2D.AddForce(new Vector2(0f, moveVertical * jumpForce), ForceMode2D.Impulse);
            gameSoundFx.PlayJumpSound();
            animator.SetBool("Jump", true);
        }

        // Attacking
        if(Input.GetKeyDown(KeyCode.Space)) {
            Attack();
            gameSoundFx.PlayAttackSound();
        }

        if(attacking) {
            timer += Time.deltaTime;
            if(timer >= timeToAttack) {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }
        
        if(currentHealth <= 0) {
            gameOverText.enabled = true;
            backButton.SetActive(true);
            gameSoundFx.PlayDeathSound();
            Destroy(gameObject);
        }
    }

    //Checking is player is on the ground
    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Ground") {
            isJumping = false;
            animator.SetBool("Jump", false);
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject.tag == "Ground") {
            isJumping = true;
        }
    }

    // Makes character flip when moving the opposite direction
    void Flip() {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }

    // Triggers the attack animation
    public void Attack() {
        // Transformations to the positions to offset the animation so the sprite
        // doesn't clip through the ground
        attacking = true;
        transform.position += new Vector3(0, 0.343f, 0);
        capsuleCollider.offset += new Vector2(0, 0.343f);
        boxCollider.offset += new Vector2(0, 0.343f);
        animator.SetTrigger("Attack");
        attackArea.SetActive(attacking);
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if(!facingRight) {
            rb2D.AddForce(new Vector2(15f, 15f), ForceMode2D.Impulse);
            gameSoundFx.PlayHitSound();
        }
        else {
            rb2D.AddForce(new Vector2(-15f, 15f), ForceMode2D.Impulse);
            gameSoundFx.PlayHitSound();
        }
    }

    public void IncreaseScore() {
        score++;
        txt.text = "Score: " + score;
    }

    IEnumerator DisplayWave() {
        waveText.enabled = true;
        yield return new WaitForSeconds(2);
        waveText.enabled = false;
    }

    public void waveCheck() {
        if(score >= 20 && currentWave == 1) {
            waveText.text = "Round: 2";
            StartCoroutine(DisplayWave());
            currentWave++;
        }
        
        else if(score >= 30 && currentWave == 2) {
            waveText.text = "Round: 3";
            StartCoroutine(DisplayWave());
            currentWave++;
        }

        else if(score >= 40 && currentWave == 3) {
            waveText.text = "Round: 4";
            StartCoroutine(DisplayWave());
            currentWave++;
        }

        else if(score >= 50 && currentWave == 4) {
            waveText.text = "Round: 5";
            StartCoroutine(DisplayWave());
            currentWave++;
        }

        else if(score >= 60 && currentWave == 5) {
            waveText.text = "Round: 6";
            StartCoroutine(DisplayWave());
            currentWave++;
        }

        else if(score >= 70 && currentWave == 6) {
            waveText.text = "Round: 7";
            StartCoroutine(DisplayWave());
            currentWave++;
        }

        else if(score >= 100 && currentWave == 7) {
            waveText.text = "Round: ∞";
            StartCoroutine(DisplayWave());
            currentWave++;
        }

    }

}
