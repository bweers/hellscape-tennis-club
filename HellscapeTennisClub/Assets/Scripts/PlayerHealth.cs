using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 15;
    public int currentHealth;
    public HealthBar healthBar;
    public SimpleFlash flashEffect;
    public GameObject RestartScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        flashEffect.Flash();

        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            GameOver();
        }
    }
    void GameOver()
    {
        RestartScreen.SetActive(true);
        Destroy(gameObject);
        
    }
}
// Brackys tutorial: https://www.youtube.com/watch?v=BLfNP4Sc_iA&t=607s