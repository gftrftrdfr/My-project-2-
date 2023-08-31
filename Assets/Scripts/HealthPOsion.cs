using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPOsion : MonoBehaviour
{
    public PlayerController player;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(player.currentHealth<player.maxHealth)
            {
                player.PlayHealEffect();
                player.currentHealth = player.maxHealth;
                healthBar.setHealth(player.currentHealth);
                Destroy(this.gameObject);
            }           
        }
    }
}
