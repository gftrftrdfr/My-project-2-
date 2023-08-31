using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int maxHealth = 100;
    public float maxMana = 100;
    public int currentHealth;
    public float currentMana;
    public float timeInvincible = 1.0f;
    bool isInvincible;
    float invincibleTimer;

    public HealthBar healthBar;
    public ManaBar manaBar; 
    public Animator anim;
    public GameObject gameOver;
    public PauseMenu pauseMenu;

    [SerializeField] private AudioSource healEffect;
    [SerializeField] private AudioSource hurtEffect;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);

        currentMana = maxMana;
        manaBar.setMaxMana(maxMana);

    }

    // Update is called once per frame
    void Update()
    {
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
        if (currentHealth <= 0)
        {
            anim.SetTrigger("Death");
            gameOver.SetActive(true);
            pauseMenu.PauseGame();
        }
        else
        {
            pauseMenu.ResumeGame();
        }
        
    }

    private void FixedUpdate()
    {
        if (currentMana < maxMana)
        {
            currentMana += 1 * Time.deltaTime;
            manaBar.setMana(currentMana);
        }
    }

    public void takeDamage(int dmg)
    {
        hurtEffect.Play();
        if (dmg > 0)
        {
            if (isInvincible)
                return;
            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        currentHealth -= dmg;
        healthBar.setHealth(currentHealth);
        anim.SetTrigger("Hurt");
        
    }

    public void spendMana(int mana)
    {
        currentMana -= mana;
        manaBar.setMana(currentMana);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            takeDamage(10);
        }
    }
    public void PlayHealEffect()
    {
        healEffect.Play();
    }

}
